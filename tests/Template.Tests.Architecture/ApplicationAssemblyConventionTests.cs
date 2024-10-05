using System.Reflection;
using NetArchTest.Rules;
using Template.Application.Abstract.Requests;
using Template.Tests.Architecture.Extensions;

namespace Template.Tests.Architecture;



public class ApplicationAssemblyConventionTests
{
    private readonly Assembly coreAssembly = typeof(Core.AssemblyMarker).Assembly;
    private readonly Assembly applicationAssembly = typeof(Application.AssemblyMarker).Assembly;
    private readonly Assembly domainAssembly = typeof(Domain.AssemblyMarker).Assembly;
    private readonly Assembly persistenceAssembly = typeof(Persistence.AssemblyMarker).Assembly;

    [Fact]
    public void GivenAClassInheritsIRequest_ThenItShouldHaveAppropriateSuffix()
    {

        var checkSuffixResult = Types.InAssembly(this.applicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequest))
            .Should()
            .HaveNameEndingWith("Command")
            .Or()
            .HaveNameEndingWith("Query")
            .GetResult();

        Assert.True(checkSuffixResult.IsSuccessful, checkSuffixResult.Message());

        var checkInheritanceResult = Types.InAssembly(this.applicationAssembly)
           .That()
           .HaveNameEndingWith("Command")
           .Or()
           .HaveNameEndingWith("Query")
           .Should()
           .ImplementInterface(typeof(IRequest))
           .GetResult();

        Assert.True(checkInheritanceResult.IsSuccessful, checkInheritanceResult.Message());
    }

    [Fact]
    public void GivenAClassInheritsIRequestHandler_ThenItShouldHaveAppropriateSuffix()
    {

        var checkSuffixResult = Types.InAssembly(this.applicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .Or()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        Assert.True(checkSuffixResult.IsSuccessful, checkSuffixResult.Message());

        var checkInheritanceResult = Types.InAssembly(this.applicationAssembly)
           .That()
           .HaveNameEndingWith("CommandHandler")
           .Or()
           .HaveNameEndingWith("QueryHandler")
           .Should()
           .ImplementInterface(typeof(IRequestHandler<,>))
           .GetResult();

        Assert.True(checkInheritanceResult.IsSuccessful, checkInheritanceResult.Message());
    }
}
