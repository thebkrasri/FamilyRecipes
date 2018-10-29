using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }

        public int RecipeID { get; set; }

        [Display(Name = "Ingredient")]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public double Quantity { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Unit { get; set; }

        public virtual Recipe Recipe { get; set; }

        public Ingredient()
        {
        }
    }
}
