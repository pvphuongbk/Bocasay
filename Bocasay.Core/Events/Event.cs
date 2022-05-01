using MediatR;

namespace Bocasay.Core.Events
{
    public abstract class Event : Message, INotification
    {
    }
}
