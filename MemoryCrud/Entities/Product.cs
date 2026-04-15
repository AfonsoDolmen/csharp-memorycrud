using System.Globalization;

namespace MemoryCrud.Entities
{
    // Entidade Produto
    class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Product() { } // Construtor padrão

        public Product(string name, decimal price, int amount) : base()
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        // Exibição do Produto
        public override string ToString()
        {
            return Id
                + "- "
                + Name
                + ", R$ "
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Criado em: "
                + CreatedAt.ToString("dd/MM/yyyy HH:mm")
                + ", Atualizado em: "
                + (UpdatedAt.HasValue ? UpdatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "----");
        }
    }
}
