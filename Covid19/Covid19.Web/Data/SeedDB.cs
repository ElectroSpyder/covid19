namespace Covid19.Web.Data
{
    using Covid19.Web.Data.Entities;
    using System;
    
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDB
    {
        private readonly DataContext context;
        private readonly Random random;

        public SeedDB(DataContext context)
        {
            this.context = context;
            random = new Random();
        }

        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Products.Any())
            {
                AddProduct("iPhone X");
                AddProduct("Magic Mouse");
                AddProduct("iWatch Series");
                await context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            context.Products.Add(new Product
            {
                Name = name,
                Price = random.Next(1000),
                IsAvailabe = true,
                Stock = random.Next(100)
            });
        }

    }
}
