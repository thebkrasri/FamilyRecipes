using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyRecipes.Models;

namespace FamilyRecipes.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly FamilyRecipes.Models.RecipeContext _context;

        public CreateModel(FamilyRecipes.Models.RecipeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IList<Ingredient> Ingredients { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipe.Add(Recipe);

            await _context.SaveChangesAsync();
            int id = Recipe.RecipeID;

            int i = 0;
            while (i < Ingredients.Count)
            {
                Ingredients[i].RecipeID = id;
                _context.Ingredient.Add(Ingredients[i]);
                i = i + 1;
            }


            Recipe.CreatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}