using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Patterns.MediatRx.MediatR;
using Patterns.MediatRx.Messages.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Patterns.MediatRx.Pipeline
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator> _validators; 
        private readonly IMediatorHandler _mediatorHandler;

        public FailFastRequestBehavior(IMediatorHandler mediatorHandler, IEnumerable<IValidator<TRequest>> validadores)
        {
            _mediatorHandler = mediatorHandler;
            _validators = validadores;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var falhas = _validators
                .Select(validador => validador.Validate(request))
                .SelectMany(resultado => resultado.Errors)
                .Where(falha => falha != null)
                .ToList();

            if (falhas.Any())
            {
                await Errors(falhas);
                return default;
            }

            return await next();
        }

        private async Task Errors(IEnumerable<ValidationFailure> failures)
        {
            foreach (var failure in failures)
            { 
                await _mediatorHandler.EnviarNotificacao(new DomainNotification(failure.ErrorCode, failure.ErrorMessage));
            }
        }
    }
}
