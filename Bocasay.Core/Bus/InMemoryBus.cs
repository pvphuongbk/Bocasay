using Bocasay.Core.Base;
using Bocasay.Core.Commands;
using Bocasay.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore = null)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _eventStore?.Save(@event);
            }

            return _mediator.Publish(@event);
        }

		public Task<TResult> SendCommand<TRequest, TResult>(TRequest command) where TRequest : ICommand<TResult>
		{
			return _mediator.Send(command);
		}
    }
}
