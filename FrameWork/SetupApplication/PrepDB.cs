using Microsoft.EntityFrameworkCore;
using SetupApplication.DataBase;

namespace SetupApplication
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            Console.WriteLine("Gino was here");
            using (var servicesScope = app.ApplicationServices.CreateScope())
            {
                Console.WriteLine("Gino was in scope");
                SeedData(servicesScope.ServiceProvider.GetRequiredService<UserDataContext>());
            }

        }
        public static void SeedData(UserDataContext context)
        {
            System.Console.WriteLine("Appling Migriations...");
            context.Database.Migrate();
            System.Console.WriteLine("GoData");
            if (!context.userModel.Any())
            {
                System.Console.WriteLine("Add Data");
                context.userModel.AddRange(
                  new models.UserModel { Email="Ginovandegraaf@hotmail.com", Name="Gino", Passowrd="password"},
                  new models.UserModel { Email = "Admin@Gmail.com", Name = "Admin", Passowrd = "1234" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already Data");
            }
        }
    }
}

