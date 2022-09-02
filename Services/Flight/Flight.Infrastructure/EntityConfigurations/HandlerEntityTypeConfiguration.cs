using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using travel.Services.Flight.Domain.AggregatesModel.HandlerAggregate;

namespace travel.Services.Flight.Infrastructure.EntityConfigurations;

class HandlerEntityTypeConfiguration
    : IEntityTypeConfiguration<Handler>
{
    public void Configure(EntityTypeBuilder<Handler> builder)
    {
        builder.ToTable("Handler");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("handler_hilo")
            .IsRequired();

        builder.Property(cb => cb.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
