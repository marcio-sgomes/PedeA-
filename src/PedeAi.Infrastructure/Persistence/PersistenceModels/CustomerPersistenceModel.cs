using PedeAi.Domain.Entities;
using PedeAi.Domain.Enums;

namespace PedeAi.Infrastructure.Persistence.PersistenceModels
{
    public class CustomerPersistenceModel : BasePersistenceModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Status Status { get; set; }

        public CustomerPersistenceModel ToPersistence(Customer customer)
            => new CustomerPersistenceModel
                {
                    Id = customer.Id,
                    CreatedAt = customer.CreatedAt,
                    UpdatedAt = customer.UpdatedAt,
                    Name = customer.Name,
                    Email = customer.Email,
                    Status = customer.Status
                };

        public Customer ToEntity(CustomerPersistenceModel persistenceModel)
            => new Customer(
                persistenceModel.Name,
                persistenceModel.Email,
                persistenceModel.Status);
    }
}
