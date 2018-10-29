using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRecipes.Models
{
    public class Recipe
    {

        public int RecipeID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        private DateTime _date = DateTime.Now;
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate
        {
            get { return _date; }
            set { _date = value; }
        }
        /*public Recipe()
        {
            CreatedDate = DateTime.UtcNow;
        }*/

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        [Display(Name = "Added By")]
        public string CreatedBy { get; set; }

    }
}
