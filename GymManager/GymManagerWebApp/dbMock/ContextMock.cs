using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.dbMock
{
    public static class ContextMock
    {
        private static string adminRoleName = "Administrator";
        private static string coachRoleName = "Trener";
        private static string receptionistRoleName = "Pracownik recepcji";
        private static string customerRoleName = "Klient";

        public static string GetCustomerRoleName()
        {
            return customerRoleName;
        }
        public static void MockExampleData(GymManagerContext context)
        {
            {
                var adminIdentityRole = new IdentityRole() { Name = adminRoleName, NormalizedName = adminRoleName };
                var coachIdentityRole = new IdentityRole() { Name = coachRoleName, NormalizedName = coachRoleName };
                var receptionistIdentityRole = new IdentityRole() { Name = receptionistRoleName, NormalizedName = receptionistRoleName };
                var customerIdentityRole = new IdentityRole() { Name = customerRoleName, NormalizedName = customerRoleName };

                var admin = new User("Krzysztof", "Ziółkowski", "Mężczyzna", DateTime.UtcNow, null);
                var customer1 = new Customer("Patryk", "Zakrzewski", "123456789", "Klient1@example.com", "Mężczyzna", DateTime.UtcNow, null);
                var customer2 = new Customer("Katarzyna", "Błaszkowska", "123456789", "Klient2@example.com", "Mężczyzna", DateTime.UtcNow, null);
                var coach1 = new Coach("Robert", "Burneika", "123456789", "Trener1@example.com", "Mężczyzna", DateTime.UtcNow, null);
                var coach2 = new Coach("Sylwester", "Stallone", "123456789", "Trener2@example.com", "Mężczyzna", DateTime.UtcNow, null);

                var adminUserRole = new IdentityUserRole<string>() { UserId = admin.Id, RoleId = adminIdentityRole.Id };
                var customer1UserRole = new IdentityUserRole<string>() { UserId = customer1.Id, RoleId = customerIdentityRole.Id };
                var customer2UserRole = new IdentityUserRole<string>() { UserId = customer2.Id, RoleId = customerIdentityRole.Id };
                var coach1UserRole = new IdentityUserRole<string>() { UserId = coach1.Id, RoleId = coachIdentityRole.Id };
                var coach2UserRole = new IdentityUserRole<string>() { UserId = coach2.Id, RoleId = coachIdentityRole.Id };

                var timeCarnet1 = new TimeCarnet(type: "czasowy", price: 10, periodInDays: 7);
                var timeCarnet2 = new TimeCarnet(type: "czasowy", price: 20, periodInDays: 30);
                var timeCarnet3 = new TimeCarnet(type: "czasowy", price: 30, periodInDays: 90);
                var quantityCarnet1 = new QuantityCarnet(type: "ilościowy", price: 10, totalEtrances: 3);
                var quantityCarnet2 = new QuantityCarnet(type: "ilościowy", price: 20, totalEtrances: 10);
                var quantityCarnet3 = new QuantityCarnet(type: "ilościowy", price: 30, totalEtrances: 30);

                var room1 = new Room(number: 1, maxCustomersCapacity: 1);
                var room2 = new Room(number: 2, maxCustomersCapacity: 20);
                var room3 = new Room(number: 3, maxCustomersCapacity: 30);

                var exerciseName1 = new Exercise(name: "Trening siłowy");
                var exerciseName2 = new Exercise(name: "Pływanie");
                var exerciseName3 = new Exercise(name: "Zumba");
                var exerciseName4 = new Exercise(name: "Crossfit");
                var exerciseName5 = new Exercise(name: "Gimnastyka");
                var exerciseName6 = new Exercise(name: "Taniec");

                context.Roles.AddRange(
                    adminIdentityRole,
                    coachIdentityRole,
                    receptionistIdentityRole,
                    customerIdentityRole
                    );

                context.Users.AddRange(
                    admin,
                    customer1,
                    customer2,
                    coach1,
                    coach2
                    );
               
                context.UserRoles.AddRange(
                    adminUserRole,
                    customer1UserRole,
                    customer2UserRole,
                    coach1UserRole,
                    coach2UserRole
                    );
 
                context.Carnets.AddRange(
                    timeCarnet1,
                    timeCarnet2,
                    timeCarnet3,
                    quantityCarnet1,
                    quantityCarnet2,
                    quantityCarnet3
                    );

                context.Rooms.AddRange(
                    room1,
                    room2,
                    room3
                    );

                context.Exercises.AddRange(
                    exerciseName1,
                    exerciseName2,
                    exerciseName3,
                    exerciseName4,
                    exerciseName5,
                    exerciseName6
                    );

                context.SaveChanges();
            }
        }
    }
}
