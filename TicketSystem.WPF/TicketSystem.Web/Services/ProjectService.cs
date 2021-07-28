namespace TicketSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TicketSystem.Web.Data.Common;
    using TicketSystem.Web.Data.Domain;
    using TicketSystem.Web.Models;
    using TicketSystem.WebApi.Domain;

    public class ProjectService
    {
        private readonly IRepository<Project> projectRepo;
        private readonly AutoMapper<Project, ProjectViewModel> projectMapper;

        public ProjectService(IRepository<Project> projectRepo, 
            AutoMapper<Project, ProjectViewModel> projectMapper)
        {
            this.projectRepo = projectRepo;
            this.projectMapper = projectMapper;
        }

        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            var projects = this.projectRepo
                .GetAll()
                .ToList();

            var result = new List<ProjectViewModel>();
            foreach (var project in projects)
            {
                var mockedProject = this.projectMapper.MapNew(project);
                result.Add(mockedProject);
            }

            return result;
        }
    }
}
