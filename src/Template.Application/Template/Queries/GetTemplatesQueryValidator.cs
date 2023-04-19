using FluentValidation;

namespace Template.Application.Template.Queries;

internal sealed class GetTemplatesQueryValidator : AbstractValidator<GetTemplatesQuery>
{
    public GetTemplatesQueryValidator()
    {
    }
}
