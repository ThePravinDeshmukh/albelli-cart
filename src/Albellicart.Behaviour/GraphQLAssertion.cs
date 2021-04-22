using Alba;
using GraphQL;
using Microsoft.AspNetCore.Http;

namespace Albellicart.Behaviour
{
    public abstract class GraphQLAssertion : IScenarioAssertion
    {
        public abstract void Assert(Scenario scenario, HttpContext context, ScenarioAssertionException ex);

        protected ExecutionResult CreateQueryResult(string result, ExecutionErrors errors = null)
            => result.ToExecutionResult(errors);
    }
}
