using MemoryCrud.Entities;
using MemoryCrud.Repositories;
using MemoryCrud.Exceptions;

namespace MemoryCrud.Services
{
    class ProductService : IService<Product>
    {
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            // Injeção de dependência via parâmetro
            _productRepository = productRepository;
        }

        public void Create(Product product)
        {
            // Verifica se o nome é nulo
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Argument Error: product name cannot be empty.");

            if (product.Price <= 0)
                throw new ArgumentException("Argument Error: product price must be greater than 0.");

            // Cria um novo produto
            _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            Get(product.Id);
            // Deleta um produto
            _productRepository.Delete(product);
        }

        public Product Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Argument Error: the id cannot be less or equal then 0.");

            Product? product = _productRepository.GetById(id);

            // Verifica se a entidade é nula
            if (product == null)
                throw new EntityNotFoundException(id);

            return product;
        }

        public List<Product> GetAll()
        {
            // Retorna todo o conteúdo
            return _productRepository.GetAll();
        }

        public void Update(Product product)
        {
            Get(product.Id);
            // Atualiza uma entidade
            _productRepository.Update(product);
        }
    }
}
