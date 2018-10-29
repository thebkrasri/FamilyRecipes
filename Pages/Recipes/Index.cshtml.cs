using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FamilyRecipes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        public string SearchString { get; set; }
        public SelectList Types { get; set; }
        public string RecipeType { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string recipeType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> typeQuery = from m in _context.Recipe
                                            orderby m.Type
                                            select m.Type;

            var recipes = from m in _context.Recipe
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.CreatedBy.ToLower().Contains(searchString.ToLower()));
            }

            if (!String.IsNullOrEmpty(recipeType))
            {
                recipes = recipes.Where(x => x.Type == recipeType);
            }
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            Recipe = await recipes.ToListAsync();
            SearchString = searchString;
        }
    }
}
