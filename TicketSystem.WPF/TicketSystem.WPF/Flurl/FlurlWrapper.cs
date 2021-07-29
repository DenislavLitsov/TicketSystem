namespace TicketSystem.WPF.Flurl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using global::Flurl.Http;
    
    using TicketSystem.WebApi.Domain;


    public class FlurlWrapper
    {
        public FlurlWrapper()
        {
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync()
        {
            var allProjectsEndPoint = EndPoints.GetAllProjects();
            IEnumerable<ProjectViewModel> projects = await allProjectsEndPoint.GetJsonAsync<IEnumerable<ProjectViewModel>>();

            return projects;
        }

        public async Task<IEnumerable<TicketViewModel>> GetAllTicketsAsync(int projId)
        {
            var allTickets = EndPoints.GetAllTicketsURL(projId);
            IEnumerable<TicketViewModel> tickets = await allTickets.GetJsonAsync<IEnumerable<TicketViewModel>>();

            return tickets;
        }

        public async Task CreateNewTicketAsync(TicketViewModel model)
        {
            var createTicketURL = EndPoints.GetCreateNewTicketURL(model.ProjectId);

            await createTicketURL.PostUrlEncodedAsync(new
            {
                Subject = model.Subject,
                Description = model.Description,
                AssigneeName = model.Assignee.Name,
                EstimatedHours = model.EstimatedHours,
                ProjectId = model.ProjectId,
            });
        }
    }
}
