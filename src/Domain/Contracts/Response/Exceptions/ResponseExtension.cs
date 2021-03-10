using Microsoft.Extensions.DependencyInjection;
using System;

namespace Patterns.Contracts.Response.Entities
{
    public static class ResponseExtension
    {
        public static void AddResponse(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
                throw new ArgumentNullException(nameof(serviceCollection));

            serviceCollection.AddScoped(typeof(IResponse), typeof(Response));
        }
    }
}
