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
    public class CreatedUserEventHandler : INotificationHandler<CreatedUserEvent>
    {
        private IUserRepositoryRedis _userRepositoryRedis;
		public CreatedUserEventHandler(IUserRepositoryRedis userRepositoryRedis)
		{
			_userRepositoryRedis = userRepositoryRedis;
		}

		public Task Handle(CreatedUserEvent notification, CancellationToken cancellationToken)
        {
            // Save to redis
            _userRepositoryRedis.Save(notification.UserDto);
            return Task.FromResult(true);
        }
    }
}
