using Bocasay.Data.Dto.User;
using Bocasay.Data.Redis.Interface;
using Bocasay.Domain.Events.UserEvents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bocasay.Domain.EventHandlers.UserEventHandlers
{
    public class DeleteUserEventHandler : INotificationHandler<DeleteUserEvent>
    {
        private IUserRepositoryRedis _userRepositoryRedis;
		public DeleteUserEventHandler(IUserRepositoryRedis userRepositoryRedis)
		{
			_userRepositoryRedis = userRepositoryRedis;
		}

		public Task Handle(DeleteUserEvent notification, CancellationToken cancellationToken)
        {
            // Delete in redis
            _userRepositoryRedis.Remove(new UserDto { ID = notification .UserId});
            return Task.FromResult(true);
        }
    }
}
