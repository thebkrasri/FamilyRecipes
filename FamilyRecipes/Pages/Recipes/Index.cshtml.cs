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
    public class IndexModel : PageModel
    {
        private readonly FamilyRecipes.Models.RecipeContext _context;

        public IndexModel(FamilyRecipes.Models.RecipeContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe.ToListAsync();
        }
    }
}
