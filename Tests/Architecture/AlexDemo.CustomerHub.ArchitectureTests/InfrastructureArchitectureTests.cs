using NetArchTest.Rules;

namespace AlexDemo.CustomerHub.ArchitectureTests
{
    public class InfrastructureArchitectureTests
    {
        [Fact]
        public void Infrastructure_Should_Not_ReferenceUnderlyingProjects()
        {
            // arrange
            var infreastructureAssembly = typeof(Infrastructure.AssemblyReference).Assembly;

            var otherProjectsAssemblies = new[]
            {
                Constants.DataAccessWithEFNamespace,
                Constants.WebApiNamespace,
                Constants.WebUINamespace
            };

            // act
            TestResult? testResult = Types
                .InAssembly(infreastructureAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsAssemblies)
                .GetResult();

            // assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}
