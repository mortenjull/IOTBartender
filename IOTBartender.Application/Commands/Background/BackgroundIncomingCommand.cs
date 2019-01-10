using IOTBartender.Application.Models;
using IOTBartender.Domain.Entititeis;
using IOTBartender.Domain.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTBartender.Application.Commands.Background
{
    public class BackgroundIncomingCommand
        : IRequest<bool>
    { }

    public class BackgroundIncomingCommandHanlder
        : IRequestHandler<BackgroundIncomingCommand, bool>
    {
        private const string TOPIC_DIAGNOSTICS = "Api/PieStatus";

        private const string TOPIC_ORDER_RESPONSE = "Order/Response";

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

        public BackgroundIncomingCommandHanlder(IUnitOfWork unitOfWork, ILogger<BackgroundIncomingCommandHanlder> logger, IConfiguration configuration)
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

        public async Task<bool> Handle(BackgroundIncomingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Incoming background service is starting");

            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            // Create TCP based options using the builder.
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_configuration["MQTT:Server"], int.Parse(_configuration["MQTT:Port"]))
                .WithCredentials(_configuration["MQTT:Username"], _configuration["MQTT:Password"])
                .Build();

            mqttClient.Connected += async (s, e) =>
            {
                // Subscribe to a topic
                await mqttClient.SubscribeAsync(new TopicFilterBuilder()
                    .WithTopic(TOPIC_DIAGNOSTICS).Build());

                await mqttClient.SubscribeAsync(new TopicFilterBuilder()
                    .WithTopic(TOPIC_ORDER_RESPONSE).Build());
            };

            // Reconnect if disconnected.
            mqttClient.Disconnected += async (s, e) => { await Task.Delay(1000); try { await mqttClient.ConnectAsync(options); } catch { } };

            mqttClient.ApplicationMessageReceived += (s, e) =>
            {
                switch (e.ApplicationMessage.Topic)
                {
                    // Handle diagnostics topic from pie.
                    case TOPIC_DIAGNOSTICS:
                        // Get payload.
                        string diagnosticPayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                        // Convert recevied payload to diagnostic entity.
                        var diagnostic = JsonConvert.DeserializeObject<Domain.Entititeis.Diagnostic>(diagnosticPayload);
                        // Set current time.
                        diagnostic.Time = DateTime.UtcNow;
                        // Save the recevied diagnostic.
                        _unitOfWork.Repository.Add(diagnostic);
                        // Save changes (please be aware Wait() is only for getting it to work.).
                        _unitOfWork.SaveChanges(cancellationToken).Wait();
                        break;
                    case TOPIC_ORDER_RESPONSE:
                        // Get payload.
                        string orderResponsePayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                        // Convert recevied payload to order response.
                        var orderResponse = JsonConvert.DeserializeObject<ProcessOrderResponseModel>(orderResponsePayload);
                        // Create new event status for order.
                        var orderEvent = new Domain.Entititeis.OrderEvent() { Time = DateTime.UtcNow, OrderId = orderResponse.OrderId, Type = (Domain.Entititeis.OrderEvent.OrderEventType)orderResponse.Status };
                        // Save order event.
                        _unitOfWork.Repository.Add(orderEvent);
                        // Save.
                        _unitOfWork.SaveChanges(cancellationToken).Wait();
                        break;
                }
            };

            await mqttClient.ConnectAsync(options);

            _logger.LogInformation($"Incoming background service is stopping.");

            while (!cancellationToken.IsCancellationRequested)
                await Task.Delay(1000);

            return true;
        }
    }
}
