using MethodologyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MethodologyProject.ViewModel
{
    public class ExperimentVolunteer
    {
        public List<Volunteer> Volunteers { get; set; }
        public List<Experiment> Experiments { get; set; }
        public List<UserRole> UserRole { get; set; }
        public Volunteer MyVolunteer { get; set; }
        public Experiment MyExperiment { get; set; }
        public UserRole MyUserRole { get; set; }

    }
}