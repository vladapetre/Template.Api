using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Components.Customers.Models;
using Template.Persistence.Context.Components.Customers.Converters;
using Template.Persistence.Context.Converters;

namespace Template.Persistence.Context.Components.Customers.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure( EntityTypeBuilder<Customer> builder )
    {
        builder
            .ToTable("Customer");

        builder
            .HasKey(e => e.Id);

        builder
            .Property(c => c.Id)
            .HasConversion(new CustomerIdValueConverter());

        builder
            .ComplexProperty(c => c.ApiKey, builder =>
            {
                builder.Property(p => p.Key).HasColumnName("ApiKey");
                builder.Property(p => p.Expired).HasColumnName("ApiKeyExpired");
            });

        builder
            .ComplexProperty(c => c.Subscription, builder =>
            {
                builder.Property(p => p.Type)
                    .HasColumnName("SubscriptionType")
                    .HasConversion(new EnumerationValueConverter<SubscriptionType>());
            });

        builder
            .ComplexProperty(c => c.Information, builder =>
            {
                builder.Property(p => p.Name).HasColumnName("Name");
            });
    }
}
