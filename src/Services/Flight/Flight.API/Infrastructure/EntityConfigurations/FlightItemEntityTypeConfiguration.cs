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
   .Property<int>("_handlerId")
   .UsePropertyAccessMode(PropertyAccessMode.Field)
   .HasColumnName("HandlerId")
    .IsRequired(true);

        builder
   .Property<int>("_remain")
   .UsePropertyAccessMode(PropertyAccessMode.Field)
   .HasColumnName("Remain")
    .IsRequired(true);

        builder
         .Property<int>("_stockThreshold")
         .UsePropertyAccessMode(PropertyAccessMode.Field)
         .HasColumnName("StockThreshold")
          .IsRequired(true);


        builder.HasOne(ci => ci.Handler)
            .WithMany()
            .HasForeignKey("_handlerId");
    }
}
