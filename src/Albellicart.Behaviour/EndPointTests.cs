using System.Net;
using System.Threading.Tasks;
using Albellicart;
using Albellicart.Behaviour;
using GraphQL.SystemTextJson;
using Xunit;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Albellicart.Behaviour
{
    public class EndPointTests : SystemTestBase<Startup>
    {
        [Fact]
        public async Task Get_Order_By_Id_QueryTest()
        {
            await run(scenario =>
            {
                var input = new GraphQLRequest
                {
                    Query = @"{ order(id:1) { id } }"
                };
                scenario.Post.Json(input).ToUrl("/graphql");
                scenario.StatusCodeShouldBe(HttpStatusCode.OK);
                scenario.GraphQL().ShouldBeSuccess(@"{""order"":null}");
            });
        }
        [Fact]
        public async Task Get_Orders_QueryTest()
        {
            await run(scenario =>
            {
                var input = new GraphQLRequest
                {
                    Query = @"{ orders { id } }"
                };
                scenario.Post.Json(input).ToUrl("/graphql");
                scenario.StatusCodeShouldBe(HttpStatusCode.OK);
                scenario.GraphQL().ShouldBeSuccess(@"{""orders"":[]}");
            });
        }
    }
}
