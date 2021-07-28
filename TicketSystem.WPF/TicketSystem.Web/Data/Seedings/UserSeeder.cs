namespace TicketSystem.Web.Data.Seedings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Domain;
    using Microsoft.Extensions.DependencyInjection;
    using TicketSystem.Web.Data.Common;

    public class UserSeeder : ISeeder
    {
        public UserSeeder()
        {
        }

        public void Seed(ApplicationDBContext dbContext, IServiceProvider serviceProvider)
        {
            var usersRepo = serviceProvider.GetRequiredService<IRepository<User>>();
            string name = SeedingConstants.UserNameSeeding;

            if (usersRepo.GetAll().Any(x => x.Name == name) == false)
            {
                User user = new User()
                {
                    Name = name,
                    EMail = $"{name}@gmail.com",
                };

                usersRepo.Create(user);
                usersRepo.SaveChanges();
            }
        }
    }
}
