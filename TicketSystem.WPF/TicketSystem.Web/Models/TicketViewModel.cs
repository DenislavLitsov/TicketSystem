namespace TicketSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class TicketViewModel
    {

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

        public UserViewModel Assignee { get; set; }

        public int ProjectId { get; set; }

        public ProjectViewModel Project { get; set; }
    }
}
