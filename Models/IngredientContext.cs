using Microsoft.EntityFrameworkCore;

namespace FamilyRecipes.Models
{
    public class IngredientContext : DbContext
    {
        public IngredientContext(DbContextOptions<IngredientContext> options)
            : base(options)
        {
        }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}
