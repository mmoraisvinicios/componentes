using MediatR;
using Patterns.Contracts.Response.Entities;

namespace Patterns.MediatRx.Interfaces
{
    public interface ICommand : IRequest<Response>
    {

    }

    public interface ICommand<T> : IRequest<T>
    {

    }
}
