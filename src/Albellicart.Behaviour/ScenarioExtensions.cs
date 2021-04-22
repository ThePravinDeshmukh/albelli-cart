using Alba;

namespace Albellicart.Behaviour
{
    public static class ScenarioExtensions
    {
        public static GraphQLExpectations GraphQL(this Scenario scenario) => new GraphQLExpectations(scenario);
    }
}
