using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Display(Name="Recipe Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string Type { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }

        public Recipe(){
            CreatedDate = DateTime.UtcNow;
        }

        [Display(Name="Added By")]
        [StringLength(20, MinimumLength = 3)]
        public string CreatedBy { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Step> Steps { get; set; }
    }

    public class Step
    {
        public int StepID { get; set; }

        [Display(Name = "Step #")]
        [Required]
        public int StepNum { get; set; }

        [Required]
        public string Instructions { get; set; }

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }

    }

    public class Ingredient
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
