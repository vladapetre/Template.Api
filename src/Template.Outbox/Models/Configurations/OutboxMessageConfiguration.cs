using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Persistence.Example.Configurations.Converters;

namespace Template.Outbox.Models.Configurations;
internal class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder
            .HasKey(message => message.Id);
        builder
            .Property(message => message.Id)
            .ValueGeneratedOnAdd();

        builder
           .Property(template => template.Status)
           .HasConversion<OutboxMessageStatusConverter>();
    }
}
