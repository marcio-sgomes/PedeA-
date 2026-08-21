using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedeAi.Infrastructure.Persistence.PersistenceModels;

namespace PedeAi.Infrastructure.Persistence.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<CustomerPersistenceModel>
    {
        public void Configure(EntityTypeBuilder<CustomerPersistenceModel> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdatedAt).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Status).IsRequired();
        }
    }
}
