using NetArchTest.Rules;

namespace Template.Tests.Architecture.Extensions;

public static class TestResultExtensions
{
    public static string Message(this TestResult? result) => string.Join(", ", result?.FailingTypeNames ?? []);
}
