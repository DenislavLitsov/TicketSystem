namespace TicketSystem.Web.Data.Seedings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TicketSystem.Web.Data.Common;
    using TicketSystem.Web.Data.Domain;

    public class SeedManager
    {
        private readonly ApplicationDBContext applicationDBContext;
        private IEnumerable<ISeeder> seeders;

        public SeedManager()
        {
            this.seeders = new List<ISeeder>()
            {
                new UserSeeder(),
                new ProjectsSeeder(),
                new TicketSeeder(),
            };
        }

        public void Seed(ApplicationDBContext dbContext, IServiceProvider serviceProvider)
        {
            foreach (var seed in this.seeders)
            {
                seed.Seed(dbContext, serviceProvider);
            }
        }
    }
}
