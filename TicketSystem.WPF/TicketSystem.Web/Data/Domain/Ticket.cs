namespace TicketSystem.Web.Data.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Ticket : BaseModel<int>
    {
        public Ticket()
        {
        }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double EstimatedHours { get; set; }

        public int? AssigneeId { get; set; }

        public User Assignee { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
