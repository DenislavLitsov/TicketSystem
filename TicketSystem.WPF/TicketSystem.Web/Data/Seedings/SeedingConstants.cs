namespace TicketSystem.Web.Data.Seedings
{
    public class SeedingConstants
    {

        public const string UserNameSeeding = "Markus";

        public static string[] ProjectNames = new string[]
        {
            "Car repair website",
            "Flower webshop"
        };

        public static string[] TicketNames = new string[]
        {
            "500 Unauthorized",
            "Hompage 404 not found"
        };

        public static string[] TicketDesriptions = new string[]
        {
            "We get the error 500 Unauthorized",
            "When we open the homepage we get 404 not found"
        };
    }
}
