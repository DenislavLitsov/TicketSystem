namespace TicketSystem.WebApi.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int CreatedById { get; set; }

        public UserViewModel CreatedBy { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}