using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var users=new List<AppUser>
                {
                    new AppUser{
                        DisplayName="Bob", UserName="bob",Email="bob@test.com",Bio="I am Bob and I'm a software engineer"
                    },
                    new AppUser{
                        DisplayName="Tom", UserName="tom",Email="tom@test.com",Bio="I am Tom and I'm a software engineer"
                    },
                    new AppUser{
                        DisplayName="John", UserName="john",Email="john@test.com",Bio="I am John and I'm a software engineer"
                    }
                };

                foreach(var user in users)
                {
                    await userManager.CreateAsync(user,"Pa$$w0rd");
                }
            }

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
            {
                new Category
                {
                    Name = "Web Development"
                },
                new Category
                {
                    Name = "Mobile Development"
                },
                new Category
                {
                    Name = "Game Development"
                },
                new Category
                {
                    Name = "Blockchain Development"
                },
                new Category
                {
                    Name = "Data Science/Machine Learning"
                }
            };
                context.Categories.AddRange(categories);
            }

            if (!context.Skills.Any())
            {
                var skills = new List<Skill>
            {
                new Skill
                {
                    Name = "Backend"
                },
                new Skill
                {
                    Name = ".NET Core"
                },
                new Skill
                {
                    Name = "Vue"
                },
                new Skill
                {
                    Name = "Java"
                },
                new Skill
                {
                    Name = "C#"
                },
                new Skill
                {
                    Name = "Laravel"
                },
                new Skill
                {
                    Name = "Axios"
                },
                new Skill
                {
                    Name = "Redux"
                },
                new Skill
                {
                    Name = "React"
                },
                new Skill
                {
                    Name = "Spring"
                },
                new Skill
                {
                    Name = "PHP"
                },
                new Skill
                {
                    Name = "CSS"
                },
                new Skill
                {
                    Name = "HTML"
                },
                new Skill
                {
                    Name = "WEB Api"
                },
                new Skill
                {
                    Name = "Angular"
                },
                new Skill
                {
                    Name = "Javascript"
                }
            };
                context.Skills.AddRange(skills);
            }

            if (!context.Roles.Any())
            {
                    var roles = new List<Role> 
                    {
                        new Role { Name = "Mentor" },
                        new Role { Name = "Client" }
                    };
                context.Roles.AddRange(roles);
            }
                await context.SaveChangesAsync();
        }
    }
}