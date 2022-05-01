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
	public class DeleteUserCommandHandler : CommandHandler, IRequestHandler<DeleteUserCommand, DeleteUserResponse>
	{
		private IMediatorHandler _bus;
		private readonly ICommonRepository<User> _userRepository;
		private readonly ICommonRepository<Role> _roleRepository;
		private readonly ICommonRepository<UserRoleMap> _userRoleMapRepository;
		private readonly IUserJsonRepository _userJsonRepository;
		private readonly ICommonUoW _commonUoW;
		private readonly IMapper _mapper;
		public DeleteUserCommandHandler(IMediatorHandler bus, ICommonUoW commonUoW, ICommonRepository<User> userRepository,
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
		public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var response = new DeleteUserResponse();
			try
			{
				var success = _userJsonRepository.Delete(request.UserId);
				if (!success)
				{
					response.Code = ErrorCodeMessage.UserNotExisted.Key;
					response.Message = ErrorCodeMessage.UserNotExisted.Value;
					return response;
				}

				// Save to file
				_userJsonRepository.SaveChange();

				// Delete success => delete into redis
				var eventObj = new DeleteUserEvent { UserId = request.UserId };
				await _bus.RaiseEvent(eventObj);
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
