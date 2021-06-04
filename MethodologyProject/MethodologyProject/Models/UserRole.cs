using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MethodologyProject.Models
{
    public class UserRole
    {
        [Key]
        public int id { get; set; }

        public String Name { get; set; }
    }
}