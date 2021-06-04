using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace MethodologyProject.Models
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

    }
}