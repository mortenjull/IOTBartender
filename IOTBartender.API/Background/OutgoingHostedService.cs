//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using IOTBartender.Application.Commands.Background;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;

//namespace IOTBartender.API.Background
//{
//    public class OutgoingHostedService
//        : ScopedHostedService
//    {
//        public OutgoingHostedService(IServiceProvider serviceProvider) 
//            : base(serviceProvider)
//        { }

//        public override async Task Run(IServiceScope scope, CancellationToken cancellationToken)
//        {
//            // Get the mediator for using mediator.
//            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

//            // Execute outgoing background command.
//            await mediator.Send(new BackgroundOutgoingCommand());
//        }
//    }
//}
