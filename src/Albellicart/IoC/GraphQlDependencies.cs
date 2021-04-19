using Albellicart.Schema;
using Albellicart.Schema.Types;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Albellicart.IoC
{
    public class GraphQlDependencies
    {
        public static void Map(IServiceCollection services)
        {
            services.AddScoped<ISchema, AlbelliSchema>();
            services.AddScoped<AlbelliQuery>();
            services.AddScoped<AlbelliMutation>();


            services.AddScoped<OrderType>();
            services.AddScoped<OrderLineType>();
            services.AddScoped<OrderLineInputType>();
            services.AddScoped<ProductTypeEnum>();
        }
    }
}
