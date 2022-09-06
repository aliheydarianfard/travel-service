namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;

public class AgencyEntityTypeConfiguration
    : IEntityTypeConfiguration<Agency>
{
    public void Configure(EntityTypeBuilder<Agency> builder)
    {

        builder.ToTable("Agency", schema: "Agency");
        builder.HasKey(x => x.Id);
        builder.Property(ci => ci.Id)
            .UseHiLo("agency_hilo")
            .IsRequired();

        builder.UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.Ignore(b => b.DomainEvents);

        builder
       .Property(p => p.HandlerId)
       .HasField("_handlerId")
       .UsePropertyAccessMode(PropertyAccessMode.Field)
       .HasColumnName("HandlerId")
       .IsRequired(true);


        builder.Property(p => p.AgencyName).HasField("_agencyName")
         .UsePropertyAccessMode(PropertyAccessMode.Field)
         .HasColumnName("AgencyName")
         .IsRequired(true);


        var navigation = builder.Metadata.FindNavigation(nameof(Agency.AgencyItems));
        navigation.SetPropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

   

        builder.HasOne<Handler>()
            .WithMany()
            .HasForeignKey("HandlerId").OnDelete(DeleteBehavior.NoAction);

    }
}

