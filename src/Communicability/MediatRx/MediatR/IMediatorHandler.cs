using Patterns.MediatRx.Interfaces;
using Patterns.MediatRx.Messages.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patterns.MediatRx.MediatR
{
    public interface IMediatorHandler
    {
        Task EnviarComando<T>(T command) where T : ICommand;
        Task<TResponse> EnviarComando<T, TResponse>(T command) where T : ICommand<TResponse>;
        
        Task<TResponse> Obter<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;

        Task EnviarNotificacao(DomainNotification notification);

        IEnumerable<DomainNotification> ObterNotificacoes();
        bool ExistemNotificacoes();
        void LimparNotificacoes();
    }
}
