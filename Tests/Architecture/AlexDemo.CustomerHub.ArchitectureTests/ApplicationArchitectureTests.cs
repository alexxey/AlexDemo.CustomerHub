using NetArchTest.Rules;

namespace AlexDemo.CustomerHub.ArchitectureTests
{
    public class ApplicationArchitectureTests
    {
        [Fact]
        public void Application_Should_Not_ReferenceUnderlyingProjects()
        {
            // arrange
            var applicationAssembly = typeof(Core.Application.AssemblyReference).Assembly;

            var otherProjectsAssemblies = new[]
            {
                Constants.IdentityNamespace,
                Constants.DataAccessWithEFNamespace,
                Constants.InfrastructureNamespace,
                Constants.WebApiNamespace,
                Constants.WebUINamespace
            };

            // act
            TestResult? testResult = Types
                 .InAssembly(applicationAssembly)
                 .ShouldNot()
                 .HaveDependencyOnAll(otherProjectsAssemblies)
                 .GetResult();

            // assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Application_Should_ReferenceDomainProject()
        {
            // arrange
            var applicationAssembly = typeof(Core.Application.AssemblyReference).Assembly;

            // act
            TestResult? testResult = Types
                .InAssembly(applicationAssembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(Constants.DomainNamespace)
                .GetResult();

            // assert
            Assert.True(testResult.IsSuccessful);
        }
    }
}
