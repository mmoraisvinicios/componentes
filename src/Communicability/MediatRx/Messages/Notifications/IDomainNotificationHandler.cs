using MediatR;
using System.Collections.Generic;

namespace Patterns.MediatRx.Messages.Notifications
{
    public interface IDomainNotificationHandler<T> : INotificationHandler<T> where T : INotification
    {
        List<DomainNotification> ObterNotificacoes();
        bool ExisteNotificacoes();
        void LimparNotificacoes();
    }
}
