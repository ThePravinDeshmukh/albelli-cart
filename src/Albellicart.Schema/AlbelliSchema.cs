using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace Albellicart.Schema
{
    public class AlbelliSchema : GraphQL.Types.Schema
    {
        public AlbelliSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<AlbelliQuery>();
            Mutation = provider.GetRequiredService<AlbelliMutation>();
        }
    }
}
