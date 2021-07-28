namespace TicketSystem.Web.Data.Seedings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using TicketSystem.Web.Data.Common;
    using TicketSystem.Web.Data.Domain;

    public class TicketSeeder : ISeeder
    {
        public TicketSeeder()
        {
        }

        public void Seed(ApplicationDBContext dbContext, IServiceProvider serviceProvider)
        {
            var projectRepo = serviceProvider.GetRequiredService<IRepository<Project>>();
            var ticketsRepo = serviceProvider.GetRequiredService<IRepository<Ticket>>();
            var userRepo = serviceProvider.GetRequiredService<IRepository<User>>();

            var projects = projectRepo
                .GetAll()
                .Where(x => SeedingConstants.ProjectNames.Any(y => y == x.Name))
                .Include(x => x.Tickets)
                .ToList();

            foreach (var proj in projects)
            {
                if (proj.Tickets.Count == 0)
                {
                    for (int i = 0; i < SeedingConstants.TicketNames.Count(); i++)
                    {
                        var user = userRepo.GetAll().First();

                        var ticket = new Ticket()
                        {
                            Subject = SeedingConstants.TicketNames[i],
                            Description = SeedingConstants.TicketDesriptions[i],
                            EstimatedHours = new Random().NextDouble() * 15,
                            Project = proj,
                            Assignee = user,
                        };

                        ticketsRepo.Create(ticket);
                    }

                    ticketsRepo.SaveChanges();
                }
            }
        }
    }
}
