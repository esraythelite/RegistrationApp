using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RegistrationContext
{
    public class Context:DbContext
    {

        public Context(DbContextOptions options):base(options)
        {

        }
        public Context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-TMFM5HV; Database = RegistrationDb; User Id = sa; Password = 123");
        }
        public DbSet<User> Users { get; set; }
    }
}
