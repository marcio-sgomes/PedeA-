using PedeAi.Domain.Entities;
using PedeAi.Domain.Exceptions;

namespace PedeAi.Test.PedeAi.Domain.Test
{
    public class CustomerTests
    {
        [Fact]
        public void CreateCustomer_ShouldSucceed()
        {
            var name = "John Doe";
            var email = "john.doe@example.com";

            var customer = new Customer(name, email);

            Assert.NotNull(customer);
            Assert.True(customer.Id != Guid.Empty);
            Assert.True(customer.CreatedAt <= DateTime.UtcNow);
            Assert.True(customer.UpdatedAt <= DateTime.UtcNow);
            Assert.Equal(name, customer.Name);
            Assert.Equal(email, customer.Email);
        }

        [Fact]
        public void CreateCustomer_WithInvalidName_ShouldThrowException()
        {
            var name = "";
            var email = "john.doe@example.com";

            var exception = Assert.Throws<BusinessRulesValidationException>(() => new Customer(name, email));
            
            Assert.Equal("Name should be between 3 and 100 characters long. ", exception.Message);
        }

        [Fact]
        public void CreateCustomer_WithInvalidEmail_ShouldThrowException()
        {
            var name = "John Doe";
            var email = "invalid-email";

            var exception = Assert.Throws<BusinessRulesValidationException>(() => new Customer(name, email));

            Assert.Equal("Invalid email format.", exception.Message);
        }

        [Fact]
        public void Should_Update_UpdatedAt()
        {

            var name = "John Doe";
            var email = "john.doe@example.com";

            var customer = new Customer(name, email);

            var oldValue = customer.UpdatedAt;
            customer.SetUpdatedAt();

            Console.WriteLine($"Old UpdatedAt: {oldValue}");
            Console.WriteLine($"New UpdatedAt: {customer.UpdatedAt}");

            Assert.True(oldValue < customer.UpdatedAt);
        }
    }
}
