namespace TicketSystem.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TicketSystem.Web.Data.Domain;

    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        private DbSet<User> Users { get; set; }

        private DbSet<Ticket> Tickets { get; set; }

        private DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost;Database=TicketSystem;Trusted_Connection=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
