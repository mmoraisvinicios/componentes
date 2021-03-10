using MediatR;
using Patterns.MediatRx.Interfaces;
using Patterns.MediatRx.Messages.Notifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.MediatRx.MediatR
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IDomainNotificationHandler<DomainNotification> _notification;

        public MediatorHandler(IMediator mediator, IDomainNotificationHandler<DomainNotification> notification)
        {
            _mediator = mediator;
            _notification = notification;
        }

        public async Task EnviarComando<T>(T command) where T : ICommand
        {
            await _mediator.Send(command);
        }

        public async Task<TResponse> EnviarComando<T, TResponse>(T command) where T : ICommand<TResponse>
        {
            return await _mediator.Send(command);
        }

        public Task<TResponse> Obter<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>
        {
            return _mediator.Send(query);
        }

        public async Task EnviarNotificacao(DomainNotification notification)
        {
            await _notification.Handle(notification, CancellationToken.None);
        }

        public bool ExistemNotificacoes()
        {
            return _notification.ExisteNotificacoes();
        }

        public IEnumerable<DomainNotification> ObterNotificacoes()
        {
            return _notification.ObterNotificacoes();
        }

        public void LimparNotificacoes()
        {
            _notification.LimparNotificacoes();
        }
    }
}
