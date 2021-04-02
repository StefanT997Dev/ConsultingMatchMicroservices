using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Categories.Any()) return;
            
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Depression Consulting",
                    NumberOfClients = 0
                },
                new Category
                {
                    Name = "UI/UX Consulting",
                    NumberOfClients = 0
                },
                new Category
                {
                    Name = "Business Consulting",
                    NumberOfClients = 0
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}