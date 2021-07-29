namespace TicketSystem.WPF.Flurl
{
    public class EndPoints
    {
        const string domain = "https://localhost:44371";

        public static string GetAllProjects()
        {
            var res = $"{domain}/Projects";
            return res;
        }

        public static string GetAllTicketsURL(int id)
        {
            var res = $"{domain}/Projects/{id}/Tickets";
            return res;
        }

        public static string GetCreateNewTicketURL(int id)
        {
            var res = $"{domain}/Projects/{id}/Tickets";
            return res;
        }
    }
}
