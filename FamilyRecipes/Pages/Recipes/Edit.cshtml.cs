using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FamilyRecipes.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace FamilyRecipes.Pages.Recipes
{
    public class EditModel : PageModel
    {
        private readonly FamilyRecipes.Models.RecipeContext _context;

        public EditModel(FamilyRecipes.Models.RecipeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        [BindProperty]
        public IList<Ingredient> Ingredients { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredients = from m in _context.Ingredient
                              where m.RecipeID == id
                              select m;

            Recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.RecipeID == id); 

            Ingredients = await ingredients.ToListAsync();


            return Recipe == null ? NotFound() : (IActionResult)Page();
        }

        [HttpPost]
        public ActionResult OnPostDelete(int id)
        {
           
                var data = (from i in _context.Ingredient
                            where i.IngredientID == id
                            select i).SingleOrDefault();

                _context.Remove(data);
                _context.SaveChanges();
            

            return new EmptyResult();
            //return RedirectToPage(new{id = recipeid});
       
        }

        //public async Task<IActionResult> OnPostAsync(IList<Ingredient> Ingredients)
        [HttpPost]
        public ActionResult OnPostEdit(Recipe Recipe, IList<Ingredient> Ingredients)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            int id = Recipe.RecipeID;
            if (Recipe.CreatedDate == DateTime.MinValue) {
                Recipe.CreatedDate = DateTime.UtcNow;
            }

            _context.Attach(Recipe).State = EntityState.Modified;        


            int i = 0;
            while (i < (Ingredients.Count))
            {
                Ingredients[i].RecipeID = id;
                if (IngredientExists(Ingredients[i].IngredientID))
                {
                    _context.Attach(Ingredients[i]).State = EntityState.Modified;
                    _context.SaveChangesAsync();
                    i = i + 1;
                }
                else
                {
                    _context.Ingredient.Add(Ingredients[i]);
                    _context.SaveChangesAsync();
                    i = i + 1;
                }
               
            }

            try {
                _context.SaveChangesAsync();
            }



            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.RecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return new EmptyResult();
            //return RedirectToPage("./Index");
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeID == id);
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.IngredientID == id);
        }

        public IActionResult Index()
        {
            return PartialView("_ingredients", _context.Ingredient);
        }

        [NonAction]
        public virtual PartialViewResult PartialView(string viewName, object model)
        {
            ViewData.Model = model;

            return new PartialViewResult()
            {
                ViewName = viewName,
                ViewData = ViewData,
                TempData = TempData
            };
        }

    }

}
