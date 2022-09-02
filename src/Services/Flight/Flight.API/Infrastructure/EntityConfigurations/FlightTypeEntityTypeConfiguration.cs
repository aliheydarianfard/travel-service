


namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;


class FlightTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<FlightType>
{
    public void Configure(EntityTypeBuilder<FlightType> builder)
    {
        builder.ToTable("FlightType", schema: "Flight");
        builder.HasKey(ci => ci.Id);
        builder.Property(ci => ci.Id)
            .UseHiLo("flightType_hilo")
            .IsRequired();

      
        builder.UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Ignore(b => b.DomainEvents);


        builder
           .Property<string>("_name")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName("Name")
            .IsRequired(true)
            .HasMaxLength(100);

        builder
          .Property<string>("_desc")
          .UsePropertyAccessMode(PropertyAccessMode.Field)
          .HasColumnName("Desc")
           .IsRequired(false)
           .HasMaxLength(500);
    }
}
