namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;

class FlightItemEntityTypeConfiguration
    : IEntityTypeConfiguration<FlightItem>
{
    public void Configure(EntityTypeBuilder<FlightItem> builder)
    {
        builder.ToTable("FlightItem", schema: "Flight");

        builder.HasKey(x => x.Id);
        builder.Property(ci => ci.Id)
            .UseHiLo("flight_hilo")
            .IsRequired();

        builder.UsePropertyAccessMode(PropertyAccessMode.Field);

        builder.Ignore(b => b.DomainEvents);


        builder
           .Property<string>("_flightNumber")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName("FlightNumber")
            .IsRequired(true)
            .HasMaxLength(150);


        ///todo:refactor builder mode
        builder
               .Property(p => p.Price).HasField("_price")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Price")
               .IsRequired(true);

        builder
               .Property(p => p.Source).HasField("_source")
               .UsePropertyAccessMode(PropertyAccessMode.Field)
               .HasColumnName("Source")
               .IsRequired(true);

        builder
             .Property(p => p.Destination).HasField("_destination")
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("Destination")
             .IsRequired(true);


        builder
     .Property<decimal>("_markup")
     .UsePropertyAccessMode(PropertyAccessMode.Field)
     .HasColumnName("Markup")
      .IsRequired(true);


        builder
     .Property<decimal>("_discount")
     .UsePropertyAccessMode(PropertyAccessMode.Field)
     .HasColumnName("Discount")
      .IsRequired(true);




        builder
   .Property<int>("_flightTypeId")
   .UsePropertyAccessMode(PropertyAccessMode.Field)
   .HasColumnName("FlightTypeId")
    .IsRequired(true);

        builder
   .Property<int>("_remain")
   .UsePropertyAccessMode(PropertyAccessMode.Field)
   .HasColumnName("Remain")
    .IsRequired(true);

        builder
         .Property<int>("_minimumquantity")
         .UsePropertyAccessMode(PropertyAccessMode.Field)
         .HasColumnName("Minimumquantity")
          .IsRequired(true);


        builder.HasOne(ci => ci.flightType)
            .WithMany()
            .HasForeignKey("_flightTypeId");
    }
}
