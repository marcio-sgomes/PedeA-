namespace PedeAi.Domain.Entities
{
    public abstract class BaseEntity : BaseBusinessEntity
    {
        public Guid Id { get; protected init; }
        public DateTime CreatedAt { get; protected init; }
        public DateTime UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void SetUpdatedAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
