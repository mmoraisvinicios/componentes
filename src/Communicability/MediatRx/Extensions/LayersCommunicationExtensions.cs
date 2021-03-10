using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Patterns.MediatRx.MediatR;
using Patterns.MediatRx.Messages.Notifications;
using Patterns.MediatRx.Pipeline;
using System.Reflection;

namespace Patterns.MediatRx.Extensions
{
    public static class MediatRxExtensions
    {
        public static IServiceCollection AddMediatRx(this IServiceCollection services, Assembly assemblyToRegister)
        {
            services.AddMediatR(assemblyToRegister);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
    }
}
