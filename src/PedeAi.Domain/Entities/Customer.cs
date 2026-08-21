using PedeAi.Domain.BusinessRules;
using PedeAi.Domain.Enums;

namespace PedeAi.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Status Status { get; private set; }

        public Customer(string name, string email, Status status) : base()
        {
            Name = name;
            Email = email;
            Status = status;

            AddRule(new CustomerBusinesRules(name, email, status));
            CheckBusinessRules();
        }
    }
}
