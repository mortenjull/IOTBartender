using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IOTBartender.Domain.Entititeis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IOTBartenderFrontend.Infrastructure.Gateways
{
    public class BartenderAPIGateway
        : IBartenderAPIGateway
    {
        /// <summary>
        /// HttpClient to use for communication with the 
        /// bartender api.
        /// </summary>
        private HttpClient _httpClient;

        /// <summary>
        /// Configuration for application.
        /// </summary>
        private IConfiguration _configuration;

        public BartenderAPIGateway(HttpClient httpClient, IConfiguration configuration)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Order>> GetOrders()
        {
            var httpRequestMessage 
                = new HttpRequestMessage(HttpMethod.Get, new Uri(_configuration["BartenderApi"] + "Order/GetOrders"));
   
            var response = await _httpClient.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
                throw new BartenderAPIGatewayException($"Api gateway responded with {response.StatusCode}.");

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Order>>(body);
        }

        public async Task<List<Recipe>> GetRecipies()
        {
            var httpRequestMessage
                = new HttpRequestMessage(HttpMethod.Get, new Uri(_configuration["BartenderApi"] + "Recipe/GetRecipies"));

            var response = await _httpClient.SendAsync(httpRequestMessage);

            if (!response.IsSuccessStatusCode)
                throw new BartenderAPIGatewayException($"Api gateway responded with {response.StatusCode}.");

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Recipe>>(body);
        }

        public Task<Order> SendOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }

    public class BartenderAPIGatewayException
        : Exception
    {
        public BartenderAPIGatewayException(string message)
            : base(message)
        { }
    }
}
