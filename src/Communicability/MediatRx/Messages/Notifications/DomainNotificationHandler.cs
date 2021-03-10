using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.MediatRx.Messages.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes()
            => _notifications;

        public virtual bool ExisteNotificacoes() =>
            ObterNotificacoes().Any();

        public void LimparNotificacoes() => 
            _notifications.Clear();

        public void Dispose() =>
            _notifications = new List<DomainNotification>();
    }
}