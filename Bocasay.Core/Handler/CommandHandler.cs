using Bocasay.Core.Bus;
using Bocasay.Core.Commands;
using Bocasay.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Core.Handler
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;

        public CommandHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }
    }
}
