namespace Covid19.Web.Data
{
    using Covid19.Web.Data.Entities;
    using Covid19.Web.Helper;
    using Microsoft.AspNetCore.Identity;
    using System;
    
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDB
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            random = new Random();
        }

        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("prgazure@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Pedro",
                    LastName = "Gonzalez",
                    Email = "prgazure@gmail.com",
                    UserName = "prgazure@gmail.com",
                    PhoneNumber = "3884884432"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

           
            if (!context.Products.Any())
            {
                AddProduct("iPhone X", user);
                AddProduct("Magic Mouse", user);
                AddProduct("iWatch Series", user);
                await context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            context.Products.Add(new Product
            {
                Name = name,
                Price = random.Next(1000),
                IsAvailabe = true,
                Stock = random.Next(100),
                User = user
            });
        }

    }
}
