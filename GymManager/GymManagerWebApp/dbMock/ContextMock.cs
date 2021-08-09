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
        private static readonly string adminRoleName = "Administrator";
        private static readonly string coachRoleName = "Trener";
        private static readonly string receptionistRoleName = "Pracownik recepcji";
        private static readonly string customerRoleName = "Klient";

        public static string GetCustomerRoleName()
        {
            return customerRoleName;
        }
        public static void MockExampleData(GymManagerContext context)
        {
            {
                var admin = new User() {
                    FirstName = "Krzysztof",
                    LastName = "Ziółkowski",
                    PhoneNumber = "513558514",
                    Email = "admin@example.com",
                    UserName = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Gender = "Mężczyzna",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = null,
                    PasswordHash = "AQAAAAEAACcQAAAAEFPG/u9+LV6N7VfhuDQ77RZ4nIkXBdkigyO1zdZnMt+/c6Hfj2fmZpawt9hTwQTlEw=="
                };

                var customer1 = new Customer() {
                    FirstName = "Patryk",
                    LastName = "Zakrzewski",
                    PhoneNumber = "123456789",
                    Email = "Klient1@example.com",
                    UserName = "Klient1@example.com",
                    NormalizedEmail = "KLIENT1@EXAMPLE.COM",
                    NormalizedUserName = "KLIENT1@EXAMPLE.COM",
                    Gender = "Mężczyzna",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = null,
                    PasswordHash = "AQAAAAEAACcQAAAAEFPG/u9+LV6N7VfhuDQ77RZ4nIkXBdkigyO1zdZnMt+/c6Hfj2fmZpawt9hTwQTlEw=="
                };

                var customer2 = new Customer()
                {
                    FirstName = "Katarzyna",
                    LastName = "Błaszkowska",
                    PhoneNumber = "123456789",
                    Email = "Klient2@example.com",
                    UserName = "Klient2@example.com",
                    NormalizedEmail = "KLIENT2@EXAMPLE.COM",
                    NormalizedUserName = "KLIENT2@EXAMPLE.COM",
                    Gender = "Mężczyzna",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = null,
                    PasswordHash = "AQAAAAEAACcQAAAAEFPG/u9+LV6N7VfhuDQ77RZ4nIkXBdkigyO1zdZnMt+/c6Hfj2fmZpawt9hTwQTlEw=="
                };

                var coach1 = new Coach() {
                    FirstName = "fRobert",
                    LastName = "Burneika",
                    PhoneNumber = "123456789",
                    Email = "Trener1@example.com",
                    UserName = "Trener1@example.com",
                    NormalizedEmail = "TRENER1@EXAMPLE.COM",
                    NormalizedUserName = "TRENER1@EXAMPLE.COM",
                    Gender = "Mężczyzna",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = null,
                    PasswordHash = "AQAAAAEAACcQAAAAEFPG/u9+LV6N7VfhuDQ77RZ4nIkXBdkigyO1zdZnMt+/c6Hfj2fmZpawt9hTwQTlEw=="
                };
                
                var coach2 = new Coach() { 
                    FirstName="Sylwester", 
                    LastName= "Stallone", 
                    PhoneNumber = "123456789",
                    Email = "Trener2@example.com",
                    UserName = "Trener2@example.com",
                    NormalizedEmail = "TRENER2@EXAMPLE.COM",
                    NormalizedUserName = "TRENER2@EXAMPLE.COM",
                    Gender = "Mężczyzna",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = null,
                    PasswordHash = "AQAAAAEAACcQAAAAEFPG/u9+LV6N7VfhuDQ77RZ4nIkXBdkigyO1zdZnMt+/c6Hfj2fmZpawt9hTwQTlEw=="
                };

                var adminIdentityRole = new IdentityRole() { Name = adminRoleName, NormalizedName = adminRoleName };
                var coachIdentityRole = new IdentityRole() { Name = coachRoleName, NormalizedName = coachRoleName };
                var receptionistIdentityRole = new IdentityRole() { Name = receptionistRoleName, NormalizedName = receptionistRoleName };
                var customerIdentityRole = new IdentityRole() { Name = customerRoleName, NormalizedName = customerRoleName };

                var adminUserRole = new IdentityUserRole<string>() { UserId = admin.Id, RoleId = adminIdentityRole.Id };
                var customer1UserRole = new IdentityUserRole<string>() { UserId = customer1.Id, RoleId = customerIdentityRole.Id };
                var customer2UserRole = new IdentityUserRole<string>() { UserId = customer2.Id, RoleId = customerIdentityRole.Id };
                var coach1UserRole = new IdentityUserRole<string>() { UserId = coach1.Id, RoleId = coachIdentityRole.Id };
                var coach2UserRole = new IdentityUserRole<string>() { UserId = coach2.Id, RoleId = coachIdentityRole.Id };

                var quantityCarnet1 = new Carnet(name: "ilościowy", price: 10, totalEtrances: 3);
                var quantityCarnet2 = new Carnet(name: "ilościowy", price: 20, totalEtrances: 10);
                var quantityCarnet3 = new Carnet(name: "ilościowy", price: 30, totalEtrances: 30);

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
 
                context.CarnetsOffer.AddRange(
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
