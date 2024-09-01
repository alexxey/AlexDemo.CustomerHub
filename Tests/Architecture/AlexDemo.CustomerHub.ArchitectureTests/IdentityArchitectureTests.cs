using NetArchTest.Rules;

namespace AlexDemo.CustomerHub.ArchitectureTests
{
    public class IdentityArchitectureTests
    {
        [Fact]
        public void Identity_Should_Not_ReferenceUnderlyingProjects()
        {
            // arrange
            var identityAssembly = typeof(AlexDemo.CustomerHub.Identity.AssemblyReference).Assembly;

            var otherProjectsAssemblies = new[]
            {
                Constants.DataAccessWithEFNamespace,
                Constants.InfrastructureNamespace,
                Constants.WebApiNamespace,
                Constants.WebUINamespace
            };

            // act
            TestResult? testResult = Types
                .InAssembly(identityAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsAssemblies)
                .GetResult();

            // assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}
