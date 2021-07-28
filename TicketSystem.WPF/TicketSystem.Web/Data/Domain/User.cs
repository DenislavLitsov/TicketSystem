namespace TicketSystem.Web.Data.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class User : BaseModel<int>
    {
        public User()
        {
        }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(70)]
        public string EMail { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public ICollection<Project> CreatedProjects { get; set; }

        public ICollection<Ticket> AssignedTickets { get; set; }
    }
}
