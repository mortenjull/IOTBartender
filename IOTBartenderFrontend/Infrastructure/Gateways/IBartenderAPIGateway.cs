using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartender.Domain.Entititeis;

namespace IOTBartenderFrontend.Infrastructure.Gateways
{
    public interface IBartenderAPIGateway
    {
        /// <summary>
        /// Get all the orders from the api.
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetOrders();
        /// <summary>
        /// Gets all Recipies from the api.
        /// </summary>
        /// <returns></returns>
        Task<List<Recipe>> GetRecipies();
        /// <summary>
        /// Sends an order to the api.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<Order> SendOrder(Order order);
    }
}
