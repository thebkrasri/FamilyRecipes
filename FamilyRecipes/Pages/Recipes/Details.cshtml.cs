using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FamilyRecipes.Models;

namespace FamilyRecipes.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly FamilyRecipes.Models.RecipeContext _context;

        public DetailsModel(FamilyRecipes.Models.RecipeContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }
        public IList<Ingredient> Ingredients { get; set; }
        public IList<Step> Steps { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ingredients = from m in _context.Ingredient
                          select m;

            Recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.RecipeID == id);
            ingredients = ingredients.Where(x => x.RecipeID == id);

            Ingredients = await ingredients.ToListAsync();

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
