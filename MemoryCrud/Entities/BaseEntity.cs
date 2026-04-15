namespace MemoryCrud.Entities
{
    // Superclasse para entidades
    abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public BaseEntity()
        {
            Id = 0;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = null;
        }
    }
}
