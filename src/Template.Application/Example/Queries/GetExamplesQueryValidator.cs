using FluentValidation;

namespace Template.Application.Example.Queries;

internal sealed class GetExamplesQueryValidator : AbstractValidator<GetExamplesQuery>
{
    public GetExamplesQueryValidator()
    {
    }
}
