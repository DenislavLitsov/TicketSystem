namespace TicketSystem.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CreatedById { get; set; }

        public UserViewModel CreatedBy { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}