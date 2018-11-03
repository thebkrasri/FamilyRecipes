using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class IngredientOld
    {
        public int IngredientID { get; set; }

        [Display(Name = "Ingredient")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public string Unit { get; set; }

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }


    }
}
