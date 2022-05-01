using Bocasay.Core.Base;
using Bocasay.Core.Commands;
using Bocasay.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bocasay.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResult> SendCommand<TRequest, TResult>(TRequest command) where TRequest : ICommand<TResult>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
