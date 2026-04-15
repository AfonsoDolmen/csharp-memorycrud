using MemoryCrud.Entities;

namespace MemoryCrud.Repositories
{
    class MemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _memory = new List<T>();
        private int _nextId = 1;

        private int GetIndex(T entity)
        {
            // Captura o indíce da entidade
            return _memory.FindIndex(e => e.Id == entity.Id);
        }

        public void Add(T entity)
        {
            // Atruibui o Id e incrementa
            entity.Id = _nextId++;
            _memory.Add(entity);
        }

        public void Update(T entity)
        {
            // Captura o indíce da entidade
            int index = GetIndex(entity);

            // Atualiza a data de atualização da entidade
            entity.UpdatedAt = DateTime.UtcNow;

            // Atualiza a entidade
            _memory[index] = entity;
        }

        public void Delete(T entity)
        {
            // Captura o indíce da entidade
            int index = GetIndex(entity);

            // Remove a entidade
            _memory.RemoveAt(index);
        }

        public T? GetById(int id)
        {
            return _memory.Find(e => e.Id == id);
        }

        public List<T> GetAll()
        {
            return _memory.ToList();
        }
    }
}
