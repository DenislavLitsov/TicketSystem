namespace TicketSystem.WebApi.Domain
{
    public class PostNewTicketInputModel
    {
        public PostNewTicketInputModel()
        {
        }

        public string Subject { get; set; }
        
        public string Description { get; set; }
        
        public string AssigneeName { get; set; }
        
        public double EstimatedHours { get; set; }
        
        public int ProjectId { get; set; }
    }
}
