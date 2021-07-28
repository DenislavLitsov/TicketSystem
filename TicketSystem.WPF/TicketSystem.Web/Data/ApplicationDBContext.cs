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
        private ApplicationDBContext SingletonInstance;

        public ApplicationDBContext()
        {
        }

        private DbSet<User> Users { get; set; }

        public ApplicationDBContext GetInstance()
        {
            if (SingletonInstance == null)
            {
                SingletonInstance = new ApplicationDBContext();
            }

            return SingletonInstance;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Localhost;Database=TicketSystem;Trusted_Connection=true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
