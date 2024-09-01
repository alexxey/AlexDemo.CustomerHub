using NetArchTest.Rules;

namespace AlexDemo.CustomerHub.ArchitectureTests
{
    public class DomainArchitectureTests
    {
        [Fact]
        public void Domain_Should_Not_ReferenceOtherProjects()
        {
            // arrange
            var domainAssembly = typeof(Core.AssemblyReference).Assembly;

            var otherProjectsAssemblies = new[]
            {
                Constants.ApplicationNamespace,
                Constants.IdentityNamespace,
                Constants.DataAccessWithEFNamespace,
                Constants.InfrastructureNamespace,
                Constants.WebApiNamespace,
                Constants.WebUINamespace
            };

            // act
            TestResult? testResult = Types
                .InAssembly(domainAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjectsAssemblies)
                .GetResult();

            // assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}