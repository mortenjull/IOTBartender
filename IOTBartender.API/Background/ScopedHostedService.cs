using IOTBartender.Application.Commands.Background;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.API.Background
{
    public class ScopedHostedService
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

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var incomingScope = _serviceProvider.CreateScope())
            using (var outgoingScope = _serviceProvider.CreateScope())
            {
                // Execute incoming background command.
                Task incomingTask = incomingScope
                    .ServiceProvider
                    .GetRequiredService<IMediator>()
                    .Send(new BackgroundIncomingCommand());

                // Execute outgoing background command.
                Task outgoingTask = outgoingScope
                    .ServiceProvider
                    .GetRequiredService<IMediator>()
                    .Send(new BackgroundOutgoingCommand());

                Task.WaitAll(incomingTask, outgoingTask);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
