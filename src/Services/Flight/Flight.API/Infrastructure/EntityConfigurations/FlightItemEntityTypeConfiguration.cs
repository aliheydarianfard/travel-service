
namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;

public class FlightItemEntityTypeConfiguration : IEntityTypeConfiguration<FlightItem>
{
    public void Configure(EntityTypeBuilder<FlightItem> builder)
    {
        builder.ToTable("Flight");

        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Id)
            .UseHiLo("handler_hilo")
            .IsRequired();

        builder.Property(cb => cb.FlightNumber)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(cb => cb.Price)
           .IsRequired(true);

        builder.Property(ci => ci.Markup)
     .IsRequired(false);

        builder.Property(ci => ci.Discount)
     .IsRequired(false);

        builder.HasOne(ci => ci.Handler)
         .WithMany()
         .HasForeignKey(ci => ci.HandlerId);
    }
}

