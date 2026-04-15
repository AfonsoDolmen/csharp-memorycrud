using MemoryCrud.Entities;

namespace MemoryCrud.Repositories
{
    // Repositório Genérico
    interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetById(int id);
        List<T> GetAll();
    }
}
