using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOTBartenderDomain.Entities;

namespace IOTBartenderFrontend.Infrastructure.Gateways
{
    public interface IBartenderAPIGateway
    {
        /// <summary>
        /// Get all the orders from the api.
        /// </summary>
        /// <returns></returns>
        Task<List<Order>> GetOrders();
    }
}
