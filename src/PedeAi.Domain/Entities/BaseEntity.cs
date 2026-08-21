namespace PedeAi.Domain.Entities
{
    public abstract class BaseEntity : BaseBusinessEntity
    {
        public Guid Id { get; protected init; }
        public DateTimeOffset CreatedAt { get; protected init; }
        public DateTimeOffset UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
