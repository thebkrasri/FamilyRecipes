using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipe.Add(Recipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}