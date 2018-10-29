using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Display(Name="Recipe")]
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


    }
}
