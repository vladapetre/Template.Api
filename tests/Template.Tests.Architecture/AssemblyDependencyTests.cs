

using System.Reflection;
using NetArchTest.Rules;
using Template.Tests.Architecture.Extensions;

namespace Template.Tests.Architecture;

public class AssemblyDependencyTests
{

    private readonly Assembly coreAssembly = typeof(Core.AssemblyMarker).Assembly;
    private readonly Assembly applicationAssembly = typeof(Application.AssemblyMarker).Assembly;
    private readonly Assembly domainAssembly = typeof(Domain.AssemblyMarker).Assembly;
    private readonly Assembly persistenceAssembly = typeof(Transaction.AssemblyMarker).Assembly;
    private readonly Assembly presentationAssembly = typeof(Presentation.AssemblyMarker).Assembly;



    [Fact]
    public void GivenCoreAssembly_ThenShouldNotHaveDependencyOnAnyAssembly()
    {

        var result = Types.InAssembly(this.coreAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                applicationAssembly.GetName().Name,
                domainAssembly.GetName().Name,
                persistenceAssembly.GetName().Name,
                presentationAssembly.GetName().Name
            )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }

    [Fact]
    public void GivenDomainAssembly_ThenShouldOnlyHaveDependencyOnCoreAssembly()
    {

        var result = Types.InAssembly(this.domainAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                applicationAssembly.GetName().Name,
                persistenceAssembly.GetName().Name,
                presentationAssembly.GetName().Name
            )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }


    [Fact]
    public void GivenApplicationAssembly_ThenShouldOnlyHaveDependencyOnCoreAndDomainAssembly()
    {
        var result = Types.InAssembly(applicationAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                persistenceAssembly.GetName().Name,
                presentationAssembly.GetName().Name
             )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }

    [Fact]
    public void GivenPersistenceAssembly_ThenShouldOnlyHaveDependencyOnCoreAndApplicationAndDomainAssembly()
    {
        var result = Types.InAssembly(persistenceAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                presentationAssembly.GetName().Name
             )
            .GetResult();

        Assert.True(result.IsSuccessful, result.Message());
    }
}
