using Albellicart.BusinessLogic;
using Albellicart.Models;
using Albellicart.Models.Repository;
using Albellicart.Schema;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albellicart.IoC
{
    public static class AlbelliDependencies
    {
        public static void Map(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderLogic, OrderLogic>();
            services.AddScoped<IOrder, Order>();
        }
    }
}
