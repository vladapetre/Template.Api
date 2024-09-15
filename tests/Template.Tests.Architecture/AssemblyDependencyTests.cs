

using System.Reflection;
using NetArchTest.Rules;
using Template.Tests.Architecture.Extensions;

namespace Template.Tests.Architecture;

public class AssemblyDependencyTests
{

    private readonly Assembly _coreAssembly = typeof(Core.AssemblyMarker).Assembly;
    private readonly Assembly _applicationAssembly = typeof(Application.AssemblyMarker).Assembly;
    private readonly Assembly _domainAssembly = typeof(Domain.AssemblyMarker).Assembly;
    private readonly Assembly _persistenceAssembly = typeof(Persistence.AssemblyMarker).Assembly;


    [Fact]
    public void GivenCoreAssembly_ThenShouldNotHaveDependencyOnAnyAssembly()
    {

        var result = Types.InAssembly(_coreAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                _applicationAssembly.GetName().Name,
                _domainAssembly.GetName().Name,
                _persistenceAssembly.GetName().Name
            )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }

    [Fact]
    public void GivenDomainAssembly_ThenShouldOnlyHaveDependencyOnCoreAssembly()
    {

        var result = Types.InAssembly(_domainAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                _applicationAssembly.GetName().Name,
                _persistenceAssembly.GetName().Name
            )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }


    [Fact]
    public void GivenApplicationAssembly_ThenShouldOnlyHaveDependencyOnCoreAssembly()
    {
        var result = Types.InAssembly(_applicationAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                _domainAssembly.GetName().Name,
                _persistenceAssembly.GetName().Name
             )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }

    [Fact]
    public void GivenPersistenceAssembly_ThenShouldOnlyHaveDependencyOnCoreAndDomainAssembly()
    {
        var result = Types.InAssembly(_persistenceAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                _applicationAssembly.GetName().Name
             )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }
}
