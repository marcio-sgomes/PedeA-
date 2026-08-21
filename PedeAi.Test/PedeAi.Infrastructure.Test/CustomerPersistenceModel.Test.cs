using PedeAi.Domain.Entities;
using PedeAi.Domain.Enums;
using PedeAi.Infrastructure.Persistence.PersistenceModels;

namespace PedeAi.Test.PedeAi.Infrastructure.Test
{
    public class CustomerPersistenceModelTest
    {
        [Fact]
        public void ToPersistence_ShouldMapCustomerToPersistenceModel()
        {
            var customer = new Customer("John Doe", "john.doe@example.com", Status.Active);

            var persistenceModel = new CustomerPersistenceModel().ToPersistence(customer);

            Assert.Equal(customer.Id, persistenceModel.Id);
            Assert.Equal(customer.Name, persistenceModel.Name);
            Assert.Equal(customer.Email, persistenceModel.Email);
            Assert.Equal(customer.Status, persistenceModel.Status);
        }

        [Fact]
        public void ToDomain_ShouldMapPersistenceModelToCustomer()
        {
            var persistenceModel = new CustomerPersistenceModel
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.Now,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Status = Status.Active
            };

            var customer = new CustomerPersistenceModel().ToEntity(persistenceModel);

            Assert.Equal(persistenceModel.Name, customer.Name);
            Assert.Equal(persistenceModel.Email, customer.Email);
            Assert.Equal(persistenceModel.Status, customer.Status);
        }
    }
}
