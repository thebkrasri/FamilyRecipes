using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyRecipes.Models;
using Newtonsoft.Json;

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


        //public async Task<IActionResult> OnPostAsync(IList<Ingredient> Ingredients)
        [HttpPost]
        public ActionResult OnPostCreate(Recipe Recipe, IList<Ingredient> Ingredients)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var ingredients = JsonConvert.DeserializeObject<IList<Ingredient>>(ingredients);


            _context.Recipe.Add(Recipe);
             _context.SaveChangesAsync();
            int id = Recipe.RecipeID;

            int i = 0;
            while (i < Ingredients.Count)
            {
                Ingredients[i].RecipeID = id;
                _context.Ingredient.Add(Ingredients[i]);
                i = i + 1;
            }


            Recipe.CreatedDate = DateTime.UtcNow;
             _context.SaveChangesAsync();

            return new EmptyResult();
           
        }

    }
}