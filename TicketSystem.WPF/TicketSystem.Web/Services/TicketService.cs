namespace TicketSystem.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Common;
    using TicketSystem.Web.Data.Domain;
    using Models;

    public class TicketService
    {
        private readonly IRepository<Ticket> ticketsRepo;
        private readonly AutoMapper<Ticket, TicketViewModel> ticketMapper;

        public TicketService(
            IRepository<Ticket> ticketsRepo,
            AutoMapper<Ticket, TicketViewModel> ticketMapper)
        {
            this.ticketsRepo = ticketsRepo;
            this.ticketMapper = ticketMapper;
        }

        public IEnumerable<TicketViewModel> GetAllTickets(int projectId)
        {
            var tickets = this.ticketsRepo
                .GetAll()
                .Where(x => x.ProjectId == projectId)
                .ToList();

            var result = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                var mockedTicket = this.ticketMapper.MapNew(ticket);
                result.Add(mockedTicket);
            }

            return result;
        }
    }
}
