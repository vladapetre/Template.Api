using FluentValidation;

namespace Template.Application.Queries.Template;

internal sealed class GetTemplatesQueryValidator : AbstractValidator<GetTemplatesQuery>
{
    public GetTemplatesQueryValidator()
    {
    }
}
