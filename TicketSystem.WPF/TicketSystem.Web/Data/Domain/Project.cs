namespace TicketSystem.Web.Data.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Project  : BaseModel<int>
    {
        public Project()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
