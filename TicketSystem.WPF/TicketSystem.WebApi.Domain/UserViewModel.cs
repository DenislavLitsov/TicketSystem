namespace TicketSystem.WebApi.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {

        public UserViewModel()
        {
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(70)]
        public string EMail { get; set; }

        public int? CreatedById { get; set; }

        public UserViewModel CreatedBy { get; set; }

        public ICollection<ProjectViewModel> CreatedProjects { get; set; }

        public ICollection<TicketViewModel> AssignedTickets { get; set; }
    }
}