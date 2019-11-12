namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;


        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            if(!context.Products.Any())
            {
                this.AddProduct("Iphone X");
                this.AddProduct("MAgic Mouse");
                this.AddProduct("Iwatch Series 4");
                await context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Products.Add(new Entities.Product() { 
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable =true,
                Stock= random.Next(100)
            });
        }
    }
}
