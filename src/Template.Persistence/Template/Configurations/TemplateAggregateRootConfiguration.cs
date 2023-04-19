using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Models.Template;
using Template.Persistence.Template.Configurations.Converters;

namespace Template.Persistence.Template.Configurations;

public sealed class TemplateAggregateRootConfiguration : IEntityTypeConfiguration<TemplateAggregateRoot>
{
    private const string TEMPLATE_TABLE_NAME = "Template";
    private const string TEMPLATE_DESCRIPTION_TABLE_NAME = "TemplateDescription";

    public void Configure(EntityTypeBuilder<TemplateAggregateRoot> builder)
    {
        builder
            .ToTable(TEMPLATE_TABLE_NAME);

        builder
            .HasKey(template => template.Id);

        builder
            .Property(template => template.Status)
            .HasConversion<TemplateStatusConverter>();

        builder
            .OwnsOne(template => template.Description, owned =>
            {
                owned.ToTable(TEMPLATE_DESCRIPTION_TABLE_NAME);
            });
    }
}
