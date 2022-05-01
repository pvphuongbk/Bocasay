using AutoMapper;
using Bocasay.Core.Base;
using Bocasay.Core.Bus;
using Bocasay.Core.Handler;
using Bocasay.Data.Dto.User;
using Bocasay.Data.JsonFile.User;
using Bocasay.Data.SqlServer.Etities;
using Bocasay.Data.SqlServer.Interfaces;
using Bocasay.Domain.Commands.User;
using Bocasay.Domain.Commands.UserCommands;
using Bocasay.Domain.Events.UserEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bocasay.Domain.CommandHandlers.UserHanlders
{
	public class CreateUserCommandHandler : CommandHandler, IRequestHandler<CreatedUserCommand, CreateUserResponse>
	{
		private IMediatorHandler _bus;
		private readonly ICommonRepository<User> _userRepository;
		private readonly ICommonRepository<Role> _roleRepository;
		private readonly ICommonRepository<UserRoleMap> _userRoleMapRepository;
		private readonly IUserJsonRepository _userJsonRepository;
		private readonly ICommonUoW _commonUoW;
		private readonly IMapper _mapper;
		public CreateUserCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, ICommonRepository<User> userRepository,
			ICommonRepository<Role> roleRepository, ICommonRepository<UserRoleMap> userRoleMapRepository, IMapper mapper, IUserJsonRepository userJsonRepository = null) : base(bus)
		{
			_bus = bus;
			_commonUoW = commonUoW;
			_userRepository = userRepository;
			_roleRepository = roleRepository;
			_userRoleMapRepository = userRoleMapRepository;
			_mapper = mapper;
			_userJsonRepository = userJsonRepository;
		}

		/// <summary>
		/// Handle command
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<CreateUserResponse> Handle(CreatedUserCommand request, CancellationToken cancellationToken)
		{
			var response = new CreateUserResponse();
			try
			{
				var user = _userJsonRepository.GetAll()?.Where(x=> x.Email.Equals(request.CreateUserDto.Email)).FirstOrDefault();
				if (user != null)
				{
					response.Code = ErrorCodeMessage.UserExisted.Key;
					response.Message = ErrorCodeMessage.UserExisted.Value;
					return response;
				}

				// Create new user
				var NewUser = new UserDto
				{
					ID = Guid.NewGuid(),
					Address = request.CreateUserDto.Address,
					Email = request.CreateUserDto.Email,
					FullName = request.CreateUserDto.FullName,
					Company = request.CreateUserDto.Company,
					CreatedDate = DateTime.Now
				};

				_userJsonRepository.Add(NewUser);
				var result = _userJsonRepository.SaveChange();

				// Insert success => insert into redis
				if (result)
				{
					var userDto = _mapper.Map<CreateUserDto, UserDto>(request.CreateUserDto);
					userDto.ID = NewUser.ID;
					userDto.CreatedDate = NewUser.CreatedDate;
					var eventObj = new CreatedUserEvent { UserDto = userDto };
					await _bus.RaiseEvent(eventObj);
				}
			}
			catch (Exception ex)
			{
				_commonUoW.RollBack();
				response.Code = ErrorCodeMessage.IncorrectFunction.Key;
				response.Message = ErrorCodeMessage.IncorrectFunction.Value;
				response.ErrorDetail = ex.ToString();
			}
			return response;
		}
	}
}
