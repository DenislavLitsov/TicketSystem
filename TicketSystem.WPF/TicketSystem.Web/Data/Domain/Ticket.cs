namespace TicketSystem.Web.Data.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Ticket : BaseModel<int>
    {
        public Ticket()
        {
        }


        [MaxLength(50)]
        public string Subject { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public double EstimatedHours { get; set; }

        public int AssigneeId { get; set; }

        public User Assignee { get; set; }
    }
}
