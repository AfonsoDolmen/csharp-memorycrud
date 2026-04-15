using System.Globalization;

using MemoryCrud.Entities;
using MemoryCrud.Services;
using MemoryCrud.Exceptions;

namespace MemoryCrud.CLI
{
    class Menu
    {
        private readonly IService<Product> _service;

        public Menu(IService<Product> service)
        {
            // Instancia o serviço
            _service = service;
        }

        public void Run()
        {
            // Menu principal
            while (true)
            {
                ShowMenu();
                try
                {
                    Console.Write("\nEscolha uma opção: ");
                    string input = Console.ReadLine();

                    Console.Clear();

                    switch (input)
                    {
                        case "1": ListProducts(); break;
                        case "2": GetProduct(); break;
                        case "3": AddProduct(); break;
                        case "4": UpdateProduct(); break;
                        case "5": DeleteProduct(); break;
                        case "0": return;
                        default: Console.WriteLine("Opção inválida."); break;
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (EntityNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("=== MemoryCrud ===\n");
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Retornar Produto por Id");
            Console.WriteLine("3 - Adicionar Produto");
            Console.WriteLine("4 - Atualizar Produto");
            Console.WriteLine("5 - Remover Produto");
            Console.WriteLine("0 - Sair");
        }

        private void ListProducts()
        {
            // Lista todos os produtos
            List<Product> products = _service.GetAll();

            if (products.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("=== Produtos ===\n");
            products.ForEach(p => Console.WriteLine(p));
        }

        private void GetProduct()
        {
            // Retorna um produto por Id
            Console.Write("Id do produto: ");
            int id = Convert.ToInt16(Console.ReadLine());

            Product product = _service.Get(id);
            Console.WriteLine(product);
        }

        private void AddProduct()
        {
            // Adiciona um novo produto
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço: ");
            decimal price = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantidade: ");
            int amount = Convert.ToInt16(Console.ReadLine());

            _service.Create(new Product(name, price, amount));
            Console.WriteLine("+ Produto adicionado com sucesso!");
        }

        private void UpdateProduct()
        {
            // Atualiza um produto por Id
            Console.Write("Id do produto: ");
            int id = Convert.ToInt16(Console.ReadLine());

            Product product = _service.Get(id);

            Console.Write($"Nome ({product.Name}): ");
            string name = Console.ReadLine();

            Console.Write($"Preço ({product.Price.ToString("F2", CultureInfo.InvariantCulture)}): ");
            decimal price = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write($"Quantidade ({product.Amount}): ");
            int amount = Convert.ToInt16(Console.ReadLine());

            product.Name = name;
            product.Price = price;
            product.Amount = amount;

            _service.Update(product);
            Console.WriteLine("Produto atualizado com sucesso!");
        }

        private void DeleteProduct()
        {
            // Deleta um produto por Id
            Console.Write("Id do produto: ");
            int id = Convert.ToInt16(Console.ReadLine());

            Product product = _service.Get(id);
            _service.Delete(product);
            Console.WriteLine("Produto removido com sucesso!");
        }
    }
}