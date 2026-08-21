using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PedeAi.Infrastructure.Persistence.Contexts;
using PedeAi.Infrastructure.Persistence.Mappings;
using PedeAi.Infrastructure.Persistence.PersistenceModels;

namespace PedeAi.Test.PedeAi.Infrastructure.Test
{
    public class CustomerMapTest
    {
        private static ModelBuilder CreateModelBuilder()
        {
            var options = new DbContextOptionsBuilder<PedeAiContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PedeAiContext(options);

            return new ModelBuilder(
                new ConventionSet());
        }

        [Fact]
        public void Configure_ShouldMapCustomerCorrectly()
        {
            var modelBuilder = CreateModelBuilder();
            var map = new CustomerMap();

            map.Configure(modelBuilder.Entity<CustomerPersistenceModel>());

            var entityType = modelBuilder.Model
                .FindEntityType(typeof(CustomerPersistenceModel));

            Assert.NotNull(entityType);

            Assert.Equal("Customers", entityType.GetTableName());

            var primaryKey = entityType.FindPrimaryKey();

            Assert.NotNull(primaryKey);
            Assert.Single(primaryKey.Properties);
            Assert.Equal(nameof(CustomerPersistenceModel.Id), primaryKey.Properties[0].Name);

            var nameProperty = entityType.FindProperty(nameof(CustomerPersistenceModel.Name));
            Assert.NotNull(nameProperty);
            Assert.False(nameProperty.IsNullable);
            Assert.Equal(100, nameProperty.GetMaxLength());

            var emailProperty = entityType.FindProperty(nameof(CustomerPersistenceModel.Email));
            Assert.NotNull(emailProperty);
            Assert.False(emailProperty.IsNullable);
            Assert.Equal(100, emailProperty.GetMaxLength());

            var createdAtProperty = entityType.FindProperty(nameof(CustomerPersistenceModel.CreatedAt));
            Assert.NotNull(createdAtProperty);
            Assert.False(createdAtProperty.IsNullable);

            var updatedAtProperty = entityType.FindProperty(nameof(CustomerPersistenceModel.UpdatedAt));
            Assert.NotNull(updatedAtProperty);
            Assert.False(updatedAtProperty.IsNullable);

            var statusProperty = entityType.FindProperty(nameof(CustomerPersistenceModel.Status));
            Assert.NotNull(statusProperty);
            Assert.False(statusProperty.IsNullable);
        }
    }
}
