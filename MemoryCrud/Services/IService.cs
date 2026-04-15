using MemoryCrud.Entities;

namespace MemoryCrud.Services
{
    interface IService<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
