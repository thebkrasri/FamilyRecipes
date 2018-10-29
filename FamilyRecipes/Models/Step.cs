using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
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

        public Step()
        {
        }
    }
}
