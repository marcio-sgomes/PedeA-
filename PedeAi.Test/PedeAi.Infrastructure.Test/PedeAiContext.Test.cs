using Microsoft.EntityFrameworkCore;
using PedeAi.Domain.Enums;
using PedeAi.Infrastructure.Persistence.Contexts;
using PedeAi.Infrastructure.Persistence.PersistenceModels;

namespace PedeAi.Test.PedeAi.Infrastructure.Test;

public class PedeAiContextTests
{
    private static PedeAiContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<PedeAiContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new PedeAiContext(options);
    }

    [Fact]
    public void Context_ShouldContainCustomersDbSet()
    {
        using var context = CreateContext();

        var customers = context.Customers;

        Assert.NotNull(customers);
    }

    [Fact]
    public void Context_ShouldApplyCustomerConfiguration()
    {
        using var context = CreateContext();

        var entityType = context.Model
            .FindEntityType(typeof(CustomerPersistenceModel));

        Assert.NotNull(entityType);

        Assert.Equal(
            "Customers",
            entityType.GetTableName());
    }

    [Fact]
    public void Customer_ShouldHaveIdAsPrimaryKey()
    {
        using var context = CreateContext();

        var entityType = context.Model
            .FindEntityType(typeof(CustomerPersistenceModel));

        var primaryKey = entityType!.FindPrimaryKey();

        Assert.NotNull(primaryKey);

        Assert.Equal(
            nameof(CustomerPersistenceModel.Id),
            primaryKey.Properties.Single().Name);
    }

    [Fact]
    public void Customer_ShouldConfigureNameCorrectly()
    {
        using var context = CreateContext();

        var entityType = context.Model
            .FindEntityType(typeof(CustomerPersistenceModel));

        var property = entityType!.FindProperty(
            nameof(CustomerPersistenceModel.Name));

        Assert.NotNull(property);
        Assert.False(property.IsNullable);
        Assert.Equal(100, property.GetMaxLength());
    }

    [Fact]
    public void Customer_ShouldConfigureEmailCorrectly()
    {
        using var context = CreateContext();

        var entityType = context.Model
            .FindEntityType(typeof(CustomerPersistenceModel));

        var property = entityType!.FindProperty(
            nameof(CustomerPersistenceModel.Email));

        Assert.NotNull(property);
        Assert.False(property.IsNullable);
        Assert.Equal(100, property.GetMaxLength());
    }

    [Fact]
    public void Customer_ShouldConfigureRequiredProperties()
    {
        using var context = CreateContext();

        var entityType = context.Model
            .FindEntityType(typeof(CustomerPersistenceModel));

        Assert.False(
            entityType!
                .FindProperty(nameof(CustomerPersistenceModel.CreatedAt))!
                .IsNullable);

        Assert.False(
            entityType
                .FindProperty(nameof(CustomerPersistenceModel.UpdatedAt))!
                .IsNullable);

        Assert.False(
            entityType
                .FindProperty(nameof(CustomerPersistenceModel.Status))!
                .IsNullable);
    }

    [Fact]
    public async Task Should_Save_And_Retrieve_Customer()
    {
        using var context = CreateContext();

        var customer = new CustomerPersistenceModel
        {
            Id = Guid.NewGuid(),
            Name = "Eli",
            Email = "eli@email.com",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Status = Status.Active
        };

        context.Customers.Add(customer);
        await context.SaveChangesAsync();

        var result = await context.Customers
            .FirstOrDefaultAsync(x => x.Id == customer.Id);

        Assert.NotNull(result);
        Assert.Equal(customer.Id, result.Id);
        Assert.Equal("Eli", result.Name);
        Assert.Equal("eli@email.com", result.Email);
    }
}