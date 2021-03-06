using Alba;
using GraphQL;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Http;

namespace Albellicart.Behaviour
{
    public class SuccessResultAssertion : GraphQLAssertion
    {
        private static readonly string extensionsKey = nameof(ExecutionResult.Extensions).ToLower();
        private readonly string _result;
        private readonly bool _ignoreExtensions;
        private readonly IDocumentWriter _writer = new DocumentWriter();

        public SuccessResultAssertion(string result, bool ignoreExtensions)
        {
            _result = result;
            _ignoreExtensions = ignoreExtensions;
        }

        public override void Assert(Scenario scenario, HttpContext context, ScenarioAssertionException ex)
        {
            var expectedResult = CreateQueryResult(_result);
            var actualResultJson = ex.ReadBody(context);

            if (_ignoreExtensions)
            {
                expectedResult.Extensions = null;

                var actualResult = actualResultJson.ToDictionary();
                if (actualResult.ContainsKey(extensionsKey))
                {
                    actualResult.Remove(extensionsKey);
                }
                actualResultJson = _writer.WriteToStringAsync(actualResult).GetAwaiter().GetResult();
            }

            var expectedResultJson = _writer.WriteToStringAsync(expectedResult).GetAwaiter().GetResult();

            if (!actualResultJson.Equals(expectedResultJson))
            {
                ex.Add($"Expected '{expectedResult}' but got '{actualResultJson}'");
            }
        }
    }
}
