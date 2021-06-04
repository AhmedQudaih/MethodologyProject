using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MethodologyProject.Models
{
    public class Experiment
    {
        [Key]
        public int id { get; set; }
        public String start_date { get; set; }
        [Required(ErrorMessage = "Please enter the End Date"), MaxLength(30)]
        [Display(Name = "End Date")]
        public String end_date { get; set; }

        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Experiment Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter Description"), MaxLength(70)]
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}