using PedeAi.Domain.BusinessRules;
using PedeAi.Domain.Enums;

namespace PedeAi.Domain.Entities
{
    public sealed class Customer : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Status Status { get; private set; }

        private Customer() { }

        public Customer(string name, string email) : base()
        {
            Name = name;
            Email = email;
            Status = Status.Active;

            AddRule(new CustomerBusinesRules(name, email));
            CheckBusinessRules();
        }
    }
}
