using Bocasay.Core.Base;
using MediatR;

namespace Bocasay.Core.Commands
{
    public interface ICommand<TResult> : IRequest<TResult>
    {

    }
}
