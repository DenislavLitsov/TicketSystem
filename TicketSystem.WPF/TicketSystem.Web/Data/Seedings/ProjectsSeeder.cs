namespace TicketSystem.Web.Data.Seedings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using TicketSystem.Web.Data.Common;
    using TicketSystem.Web.Data.Domain;

    public class ProjectsSeeder : ISeeder
    {
        public ProjectsSeeder()
        {
        }

        public void Seed(ApplicationDBContext dbContext, IServiceProvider serviceProvider)
        {
            var usersRepo = serviceProvider.GetRequiredService<IRepository<User>>();
            var projectRepo = serviceProvider.GetRequiredService<IRepository<Project>>();
            string userName = SeedingConstants.UserNameSeeding;

            var user = usersRepo.GetAll()
                .Include(x => x.CreatedProjects)
                .First(x => x.Name == userName);

            if (user.CreatedProjects.Count == 0)
            {
                foreach (var projectName in SeedingConstants.ProjectNames)
                {
                    var project = new Project()
                    {
                        Name = projectName,
                        CreatedBy = user
                    };

                    projectRepo.Create(project);
                }

                projectRepo.SaveChanges();
            }
        }
    }
}
