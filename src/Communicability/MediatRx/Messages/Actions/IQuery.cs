using MediatR;

namespace Patterns.MediatRx.Interfaces
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}
