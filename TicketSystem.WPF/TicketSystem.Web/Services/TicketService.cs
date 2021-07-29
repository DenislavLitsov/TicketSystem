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
        private readonly IRepository<User> usersRepo;
        private readonly AutoMapper<Ticket, TicketViewModel> ticketMapper;
        private readonly AutoMapper<TicketViewModel, Ticket> reverseTicketMapper;
        private readonly AutoMapper<User, UserViewModel> usersMapper;
        private readonly AutoMapper<PostNewTicketInputModel, Ticket> ticketInputModelMapper;

        public TicketService(
            IRepository<Ticket> ticketsRepo,
            IRepository<User> usersRepo,
            AutoMapper<Ticket, TicketViewModel> ticketMapper,
            AutoMapper<TicketViewModel, Ticket> reverseTicketMapper,
            AutoMapper<User, UserViewModel> usersMapper,
            AutoMapper<PostNewTicketInputModel, Ticket> TicketInputModelMapper)
        {
            this.ticketsRepo = ticketsRepo;
            this.usersRepo = usersRepo;
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
            AssignUser(dbTicket, newTicketInputModel.AssigneeName);

            this.ticketsRepo.Create(dbTicket);
            this.ticketsRepo.SaveChanges();
        }

        private void AssignUser(Ticket ticket, string userName)
        {
            // To names are compared in upper for Normalized data
            var user = this.usersRepo
                .GetAll()
                .FirstOrDefault(x => x.Name.ToUpper() == userName.ToUpper());

            if (user != null)
            {
                ticket.AssigneeId = user.Id;
                ticket.Assignee = user;
            }
            else
            {
                var newUser = new User()
                {
                    Name = userName,
                    EMail = userName,
                };

                this.usersRepo.Create(newUser);
                ticket.Assignee = newUser;
            }
        }

        private void TrimTicketData(PostNewTicketInputModel dataToTrim)
        {
            dataToTrim.Subject = dataToTrim.Subject.Trim();
            dataToTrim.Description = dataToTrim.Description.Trim();
            dataToTrim.AssigneeName = dataToTrim.AssigneeName.Trim();
        }
    }
}
