using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FamilyRecipes.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RecipeContext(
                serviceProvider.GetRequiredService<DbContextOptions<RecipeContext>>()))
            {
                // Look for any movies.
                if (context.Recipe.Any())
                {
                    return;   // DB has been seeded
                }

                context.Recipe.AddRange(
                    new Recipe
                    {
                        Name = "Carne Asada",
                        CreatedDate = DateTime.Now,
                        Type = "Mexican",
                        CreatedBy = "Jorge Luis"
                    },

                     new Recipe
                     {
                         Name = "Sukiyaki",
                         CreatedDate = DateTime.Now,
                         Type = "Japanese",
                         CreatedBy = "Adriana"
                     },

                     new Recipe
                     {
                         Name = "French Toast",
                         CreatedDate = DateTime.Now,
                         Type = "Breakfast",
                         CreatedBy = "Jorge Luis"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}