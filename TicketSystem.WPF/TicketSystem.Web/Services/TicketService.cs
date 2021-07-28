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

        public TicketService(
            IRepository<Ticket> ticketsRepo,
            AutoMapper<Ticket, TicketViewModel> ticketMapper,
            AutoMapper<TicketViewModel, Ticket> reverseTicketMapper,
            AutoMapper<User, UserViewModel> usersMapper)
        {
            this.ticketsRepo = ticketsRepo;
            this.ticketMapper = ticketMapper;
            this.reverseTicketMapper = reverseTicketMapper;
            this.usersMapper = usersMapper;
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

        public void CreateNewTicket(int projId, TicketViewModel ticket)
        {
            var dbTicket = reverseTicketMapper.MapNew(ticket);
            dbTicket.ProjectId = projId;
            dbTicket.Assignee = new User()
            {
                Name = ticket.Assignee.Name,
                EMail = ticket.Assignee.Name,
            };

            this.ticketsRepo.Create(dbTicket);
            this.ticketsRepo.SaveChanges();
        }
    }
}
