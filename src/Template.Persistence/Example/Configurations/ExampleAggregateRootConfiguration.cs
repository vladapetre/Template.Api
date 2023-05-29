using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Models.Example;
using Template.Persistence.Example.Configurations.Converters;

namespace Template.Persistence.Example.Configurations;

public sealed class ExampleAggregateRootConfiguration : IEntityTypeConfiguration<ExampleAggregateRoot>
{
    private const string TEMPLATE_TABLE_NAME = "Example";
    private const string TEMPLATE_DESCRIPTION_TABLE_NAME = "ExampleDescription";

    public void Configure(EntityTypeBuilder<ExampleAggregateRoot> builder)
    {
        builder
            .ToTable(TEMPLATE_TABLE_NAME);

        builder
            .HasKey(template => template.Id);

        builder
            .Property(template => template.Status)
            .HasConversion<ExampleStatusConverter>();

        builder
            .OwnsOne(template => template.Description, owned =>
            {
                owned.ToTable(TEMPLATE_DESCRIPTION_TABLE_NAME);
            });
    }
}
