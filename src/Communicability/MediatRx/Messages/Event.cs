using MediatR;

namespace Patterns.MediatRx.Messages
{
    public abstract class Event : Message, INotification
    {
        protected Event() { }
    }
}
