using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MethodologyProject.Models
{
    public class Volunteer
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter your national id")]
        public int national_id { get; set; }

        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Volunteer Name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter address"), MaxLength(30)]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please enter your phone number"), MaxLength(11)]
        [Display(Name = "Phone Number")]
        public String phone_number { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        [Display(Name = "Age")]
        public int age { get; set; }       


        [Display(Name = "Experiment id")]
        public Experiment experiment { get; set; }
        [ForeignKey("experiment")]
        public int? experiment_id { get; set; }

        [Display(Name = "Note")]
        public string note { get; set; }

        [DefaultValue(0)]
        public bool Status { get; set; }

        public UserRole UserRole { get; set; }
        [ForeignKey("UserRole")]
        public int UserRole_id { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public String Password { get; set; }


    }
}