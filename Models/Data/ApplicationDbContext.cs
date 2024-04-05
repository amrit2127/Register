using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contry_State_City.Models.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("conStr")
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Register> Registers { get; set; }


        // theme cerulean
    }
}