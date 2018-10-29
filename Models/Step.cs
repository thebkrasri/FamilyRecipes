using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class Step
    {
        public int StepID { get; set; }

        public int RecipeID { get; set; }

        [Display(Name = "Step #")]
        [Required]
        public int Num { get; set; }

        [Required]
        public string Instructions { get; set; }

        public virtual Recipe Recipe { get; set; }

        public Step()
        {
        }
    }
}
