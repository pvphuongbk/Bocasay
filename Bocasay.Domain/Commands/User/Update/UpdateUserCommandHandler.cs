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
	public class UpdateUserCommandHandler : CommandHandler, IRequestHandler<UpdateUserCommand, UpdateUserResponse>
	{
		private IMediatorHandler _bus;
		private readonly ICommonRepository<User> _userRepository;
		private readonly ICommonRepository<Role> _roleRepository;
		private readonly ICommonRepository<UserRoleMap> _userRoleMapRepository;
		private readonly IUserJsonRepository _userJsonRepository;
		private readonly ICommonUoW _commonUoW;
		private readonly IMapper _mapper;
		public UpdateUserCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, ICommonRepository<User> userRepository,
			ICommonRepository<Role> roleRepository, ICommonRepository<UserRoleMap> userRoleMapRepository, IMapper mapper, IUserJsonRepository userJsonRepository) : base(bus)
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
		public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var response = new UpdateUserResponse();
			try
			{
				// Check Role empty
				if(request.UpdateUserDto.RoleCategorys == null || request.UpdateUserDto.RoleCategorys.Count == 0)
				{
					response.Code = ErrorCodeMessage.RoleEmpty.Key;
					response.Message = ErrorCodeMessage.RoleEmpty.Value;
					return response;
				}
				var user = _userJsonRepository.GetbyId(request.UserId);
				// Check user exist
				if(user == null)
				{
					response.Code = ErrorCodeMessage.UserNotExisted.Key;
					response.Message = ErrorCodeMessage.UserNotExisted.Value;
					return response;
				}

				// Check email exist
				var userEmail = _userJsonRepository.GetAll()?.Where(x=> x.Email.Equals(request.UpdateUserDto.Email)).FirstOrDefault();
				if (userEmail != null && userEmail.ID != request.UserId)
				{
					response.Code = ErrorCodeMessage.UserExisted.Key;
					response.Message = ErrorCodeMessage.UserExisted.Value;
					return response;
				}

				// Update this user
				user.Address = request.UpdateUserDto.Address;
				user.Email = request.UpdateUserDto.Email;
				user.FullName = request.UpdateUserDto.FullName;
				user.Company = request.UpdateUserDto.Company;
				user.ModifiedDate = DateTime.Now;
				user.RoleCategorys = request.UpdateUserDto.RoleCategorys;

				var success = _userJsonRepository.Update(user);
				_userJsonRepository.SaveChange();
				// Update success => update into redis
				//var userDto = _mapper.Map<UpdateUserDto, UserDto>(request.UpdateUserDto);
				if (success)
				{
					var eventObj = new UpdateUserEvent { UserDto = user };
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
