namespace TicketSystem.Web.Data.Domain
{
    using System.ComponentModel.DataAnnotations;
    using Common;

    public class Project  : BaseModel<int>
    {
        public Project()
        {
        }

        [MaxLength(50)]
        public string Name { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }
    }
}
