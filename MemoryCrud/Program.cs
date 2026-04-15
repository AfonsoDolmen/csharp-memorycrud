using MemoryCrud.Entities;
using MemoryCrud.Repositories;
using MemoryCrud.Services;
using MemoryCrud.CLI;

namespace MemoryCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicio
            Menu menu = new Menu(new ProductService(new MemoryRepository<Product>()));

            menu.Run();
        }
    }
}