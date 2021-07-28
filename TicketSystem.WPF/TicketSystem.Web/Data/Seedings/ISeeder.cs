namespace TicketSystem.Web.Data.Seedings
{
    using System;

    interface ISeeder
    {
        void Seed(ApplicationDBContext dbContext, IServiceProvider serviceProvider);
    }
}
