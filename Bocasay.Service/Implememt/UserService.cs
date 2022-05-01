using AutoMapper;
using Bocasay.Core.Base;
using Bocasay.Core.Bus;
using Bocasay.Data.Dto.User;
using Bocasay.Data.Redis.Interface;
using Bocasay.Data.SqlServer.Etities;
using Bocasay.Domain.Commands.User;
using Bocasay.Domain.Commands.UserCommands;
using Bocasay.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Service.Implememt
{
	public class UserService : IUserService
	{
		private IUserRepositoryRedis _userRepositoryRedis;
		private readonly IMediatorHandler _bus;
		private readonly IMapper _mapper;
		public UserService(IUserRepositoryRedis userRepositoryRedis, IMediatorHandler bus, IMapper mapper)
		{
			_userRepositoryRedis = userRepositoryRedis;
			_bus = bus;
			_mapper = mapper;
		}

		public async Task<CreateUserResponse> Create(CreateUserDto item)
		{
			var createCommand = new CreatedUserCommand { CreateUserDto = item };
			var result = await _bus.SendCommand<CreatedUserCommand, CreateUserResponse>(createCommand);
			return result;
		}

		public async Task<DeleteUserResponse> Delete(Guid id)
		{
			var deleteCommand = new DeleteUserCommand { UserId = id };
			var result = await _bus.SendCommand<DeleteUserCommand, DeleteUserResponse>(deleteCommand);
			return result;
		}

		public async Task<ResponseBase> GetAll()
		{
			var dataAsync = Task.Run(delegate ()
			{
				ResponseBase response = new ResponseBase();
				response.Data = _userRepositoryRedis.GetAll();
				return response;
			});
			var result = await dataAsync;
			return result;
		}

		public async Task<UpdateUserResponse> Update(Guid userId, UpdateUserDto item)
		{
			var updateCommand = new UpdateUserCommand { UserId = userId, UpdateUserDto = item };
			var result = await _bus.SendCommand<UpdateUserCommand, UpdateUserResponse>(updateCommand);
			return result;
		}

		public async Task<ResponseBase> GetDetail(Guid id)
		{
			var dataAsync = Task.Run(delegate ()
			{
				ResponseBase response = new ResponseBase();
				response.Data = _userRepositoryRedis.GetByID(id);
				return response;
			});
			var result = await dataAsync;
			return result;
		}
	}
}
