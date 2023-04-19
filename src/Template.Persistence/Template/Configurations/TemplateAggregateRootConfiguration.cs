using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Models.Template;
using Template.Persistence.Template.Configurations.Converters;

namespace Template.Persistence.Template.Configurations;

public sealed class TemplateAggregateRootConfiguration : IEntityTypeConfiguration<TemplateAggregateRoot>
{
    public string TableName => "Template";

    public void Configure(EntityTypeBuilder<TemplateAggregateRoot> builder)
    {
        builder
            .ToTable(TableName);

        builder
            .HasKey(template => template.Id);

        builder
            .Property(template => template.Status)
            .HasConversion<TemplateStatusConverter>();

        builder
            .OwnsOne(template => template.Description);
    }
}
