using MediatR;
using Patterns.Contracts.Response.Entities;
using Patterns.MediatRx.Services;

namespace Patterns.MediatRx.Messages.Notifications
{
    public class DomainNotification : Message, INotification
    {
        protected DomainNotification() { }

        public DomainNotification(Error error)
        {
            Code = UtilService.RemoveLetras(error.Code);
            Message = error.Message;
        }

        public DomainNotification(string codigo, string mensagem)
        {
            Code = UtilService.RemoveLetras(codigo);
            Message = mensagem;
        }
    }
}
