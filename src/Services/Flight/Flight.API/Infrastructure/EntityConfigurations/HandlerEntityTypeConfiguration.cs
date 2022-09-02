


namespace travel.Services.FlightAPI.Infrastructure.EntityConfigurations;


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
