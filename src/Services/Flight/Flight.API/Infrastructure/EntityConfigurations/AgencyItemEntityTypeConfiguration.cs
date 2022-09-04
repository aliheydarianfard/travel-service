namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;

public class AgencyItemEntityTypeConfiguration : IEntityTypeConfiguration<AgencyItem>
{
    public void Configure(EntityTypeBuilder<AgencyItem> builder)
    {
        builder.ToTable("AgencyItems", schema: "Agency");

        builder.HasKey(x => x.Id);
        builder.Property(ci => ci.Id)
            .UseHiLo("agencyItem_hilo")
            .IsRequired();

        builder.UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Ignore(b => b.DomainEvents);



        builder.Property(p => p.HandlerID).HasField("_handlerId")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName("handlerItemId")
           .IsRequired(true);


        builder.Property(p => p.RequestedNumber).HasField("_requestedNumber")
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("RequestedNumber")
             .IsRequired(true);


        builder.Property(p => p.AgencyId).HasField("_agencyId")
           .UsePropertyAccessMode(PropertyAccessMode.Field)
           .HasColumnName("AgencyId")
           .IsRequired(true);



        builder.HasOne<Handler>()
          .WithMany()
          .HasForeignKey("HandlerId");

        builder.HasOne<Agency>()
         .WithMany(p => p.AgencyItems)
         .HasForeignKey(p => p.AgencyId);

    }
}

