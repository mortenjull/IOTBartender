using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.API.Background
{
    public abstract class ScopedHostedService
        : IHostedService
    {
        /// <summary>
        /// <see cref="IServiceProvider"/> to use for scoping and
        /// depedency injection.
        /// </summary>
        protected readonly IServiceProvider _serviceProvider;

        public ScopedHostedService(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Run the logic for the service with the scope.
                await Run(scope, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public abstract Task Run(IServiceScope scope, CancellationToken cancellationToken);
    }
}
