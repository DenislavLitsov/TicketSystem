namespace TicketSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Common;
    using Microsoft.EntityFrameworkCore;
    using TicketSystem.Web.Data.Domain;
    using TicketSystem.WebApi.Domain;

    public class TicketService
    {
        private readonly IRepository<Ticket> ticketsRepo;
        private readonly AutoMapper<Ticket, TicketViewModel> ticketMapper;
        private readonly AutoMapper<TicketViewModel, Ticket> reverseTicketMapper;
        private readonly AutoMapper<User, UserViewModel> usersMapper;
        private readonly AutoMapper<PostNewTicketInputModel, Ticket> ticketInputModelMapper;

        public TicketService(
            IRepository<Ticket> ticketsRepo,
            AutoMapper<Ticket, TicketViewModel> ticketMapper,
            AutoMapper<TicketViewModel, Ticket> reverseTicketMapper,
            AutoMapper<User, UserViewModel> usersMapper,
            AutoMapper<PostNewTicketInputModel, Ticket> TicketInputModelMapper)
        {
            this.ticketsRepo = ticketsRepo;
            this.ticketMapper = ticketMapper;
            this.reverseTicketMapper = reverseTicketMapper;
            this.usersMapper = usersMapper;
            this.ticketInputModelMapper = TicketInputModelMapper;
        }

        public IEnumerable<TicketViewModel> GetAllTickets(int projectId)
        {
            var tickets = this.ticketsRepo
                .GetAll()
                .Include(x => x.Assignee)
                .Where(x => x.ProjectId == projectId)
                .ToList();

            var result = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                var mockedTicket = this.ticketMapper.MapNew(ticket);
                var mocedUser = this.usersMapper.MapNew(ticket.Assignee);
                mockedTicket.Assignee = mocedUser;
                result.Add(mockedTicket);
            }

            return result;
        }

        public void CreateNewTicket(int projId, PostNewTicketInputModel newTicketInputModel)
        {
            this.TrimTicketData(newTicketInputModel);
            var dbTicket = this.ticketInputModelMapper.MapNew(newTicketInputModel);

            dbTicket.ProjectId = projId;
            dbTicket.Assignee = new User()
            {
                Name = newTicketInputModel.AssigneeName,
                EMail = newTicketInputModel.AssigneeName,
            };

            this.ticketsRepo.Create(dbTicket);
            this.ticketsRepo.SaveChanges();
        }

        private void TrimTicketData(PostNewTicketInputModel dataToTrim)
        {
            dataToTrim.Subject = dataToTrim.Subject.Trim();
            dataToTrim.Description = dataToTrim.Description.Trim();
            dataToTrim.AssigneeName = dataToTrim.AssigneeName.Trim();
        }
    }
}
