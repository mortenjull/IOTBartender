using IOTBartender.Domain.UnitOfWorks;
using IOTBartender.Domain.UnitOfWorks.Repositories;
using IOTBartender.Domain.Entititeis;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MQTTnet.Client;
using Microsoft.Extensions.Configuration;
using MQTTnet;
using Newtonsoft.Json;
using IOTBartender.Application.Models;

namespace IOTBartender.Application.Commands.Background
{
    public class BackgroundOutgoingCommand
        : IRequest<bool>
    { }

    public class BackgroundOutgoingCommandHandler
        : IRequestHandler<BackgroundOutgoingCommand, bool>
    {
        private const string TOPIC_ORDER_REQUEST = "Order/Request";

        /// <summary>
        /// <see cref="IUnitOfWork"/> to use for interaction with data layer.
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Logger for logging.
        /// </summary>
        private readonly ILogger<BackgroundIncomingCommandHanlder> _logger;

        /// <summary>
        /// Configuration to use for config.
        /// </summary>
        private readonly IConfiguration _configuration;

        public BackgroundOutgoingCommandHandler(
            IUnitOfWork unitOfWork, 
            ILogger<BackgroundIncomingCommandHanlder> logger,
            IConfiguration configuration)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(Unit));
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<bool> Handle(BackgroundOutgoingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Outgoing background service is starting");

            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            // Create TCP based options using the builder.
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_configuration["MQTT:Server"], int.Parse(_configuration["MQTT:Port"]))
                .WithCredentials(_configuration["MQTT:Username"], _configuration["MQTT:Password"])
                .Build();

            // Reconnect if disconnected.
            mqttClient.Disconnected += async (s, e) => { await Task.Delay(1000); try { await mqttClient.ConnectAsync(options); } catch { } };

            // Connect to MQTT.
            await mqttClient.ConnectAsync(options);

            while (!cancellationToken.IsCancellationRequested)
            {
                var specification = new ExpSpecification<Domain.Entititeis.Order>(
                    x => !x.Events.Any(y => y.Type != Domain.Entititeis.OrderEvent.OrderEventType.Submitted));

                // Include recipe, components and fluids.   
                specification.Include("Recipe.Components.Fluid");

                // Get orders using specification.
                var orders = await _unitOfWork.Repository.Where(specification, cancellationToken);

                if (orders.Any())
                {
                    var order = orders.First();

                    // Prepare order request.
                    var orderRequest = new ProcessOrderRequestModel()
                    {
                        OrderId = order.Id,
                        Components = order.Recipe.Components.Select(c => new ProcessOrderRequestModel.Component()
                        {
                            FluidId = c.FluidId,
                            Size = c.Size
                        }).ToList()
                    };

                    // Add pending event for the order.
                    _unitOfWork.Repository.Add(new Domain.Entititeis.OrderEvent()
                    {
                        OrderId = order.Id,
                        Time = DateTime.UtcNow,
                        Type = Domain.Entititeis.OrderEvent.OrderEventType.Pending
                    });

                    // Save event changes for order.
                    await _unitOfWork.SaveChanges(cancellationToken);
                    
                    // Build order request message for pie.
                    var message = new MqttApplicationMessageBuilder()
                    .WithTopic(TOPIC_ORDER_REQUEST)
                    .WithPayload(JsonConvert.SerializeObject(orderRequest, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
                    .WithRetainFlag()
                    .Build();

                    // Sender order request.
                    await mqttClient.PublishAsync(message);
                }

                await Task.Delay(1000);
            }

            _logger.LogInformation($"Outgoing background service is stopping.");

            return true;
        }
    }
}
