using GymManagerWebApp.Data;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.dbMock
{
    public class ContextMock
    {
        private readonly GymManagerContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public const string _ROLEADMIN = "Administrator";
        public const string _ROLECOACH = "Trener";
        public const string _ROLERECEPTIONIST = "Pracownik recepcji";
        public const string _ROLECUSTOMER = "Klient";

        public const string _IDADMIN = "ID1";
        public const string _IDCUSTOMER1 = "ID1";
        public const string _IDCUSTOMER2 = "ID2";
        public const string _IDCOACH1 = "ID3";
        public const string _IDCOACH2 = "ID4";

        public ContextMock(GymManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MockAllData()
        {
            MockRoles();
            MockUsers();
            MockUserRoles();
            MockCarnetOffer();
            MockRooms();
            MockExercises();
        }

        public void MockRoles()
        {
            _dbContext.Roles.Add(new IdentityRole(_ROLEADMIN));
            _dbContext.Roles.Add(new IdentityRole(_ROLECUSTOMER));
            _dbContext.Roles.Add(new IdentityRole(_ROLERECEPTIONIST));
            _dbContext.Roles.Add(new IdentityRole(_ROLECOACH));

            _dbContext.SaveChanges();
        }

        public void MockUsers()
        {
            _dbContext.Users.Add(new User(_IDADMIN,"Krzysztof", "Ziółkowski", "Mężczyzna", DateTime.UtcNow, null));
            _dbContext.Users.Add(new Customer(_IDCUSTOMER1,"Patryk", "Zakrzewski", "123456789","Klient1@example.com","Mężczyzna", DateTime.UtcNow, null));
            _dbContext.Users.Add(new Customer(_IDCUSTOMER2, "Katarzyna", "Błaszkowska", "123456789", "Klient1@example.com", "Mężczyzna", DateTime.UtcNow, null));
            _dbContext.Users.Add(new Coach(_IDCOACH1, "Robert", "Burneika", "123456789", "Trener1@example.com", "Mężczyzna", DateTime.UtcNow, null));
            _dbContext.Users.Add(new Coach(_IDCOACH2, "Sylwester", "Stallone", "123456789", "Trener2@example.com", "Mężczyzna", DateTime.UtcNow, null));

            _dbContext.SaveChanges();
        }

        public void MockUserRoles()
        {
            _dbContext.UserRoles.Add(new IdentityUserRole<string>() { RoleId = _ROLEADMIN, UserId = _IDADMIN });
            _dbContext.UserRoles.Add(new IdentityUserRole<string>() { RoleId = _ROLECUSTOMER, UserId = _IDCUSTOMER1 });
            _dbContext.UserRoles.Add(new IdentityUserRole<string>() { RoleId = _ROLECUSTOMER, UserId = _IDCUSTOMER2});
            _dbContext.UserRoles.Add(new IdentityUserRole<string>() { RoleId = _ROLECOACH, UserId = _IDCOACH1 });
            _dbContext.UserRoles.Add(new IdentityUserRole<string>() { RoleId = _ROLECOACH, UserId = _IDCOACH2});

            _dbContext.SaveChanges();
        }

        public void MockCarnetOffer()
        {
            _dbContext.Carnets.Add(new TimeCarnet(id: 1, type: "czasowy", price: 10, periodInDays: 7));
            _dbContext.Carnets.Add(new TimeCarnet(id: 1, type: "czasowy", price: 20, periodInDays: 30));
            _dbContext.Carnets.Add(new TimeCarnet(id: 1, type: "czasowy", price: 30, periodInDays: 90));
            _dbContext.Carnets.Add(new QuantityCarnet(id: 1, type: "ilościowy", price: 10, totalEtrances: 3));
            _dbContext.Carnets.Add(new QuantityCarnet(id: 1, type: "ilościowy", price: 20, totalEtrances: 10));
            _dbContext.Carnets.Add(new QuantityCarnet(id: 1, type: "ilościowy", price: 30, totalEtrances: 30));

            _dbContext.SaveChanges();
        }

        public void MockRooms()
        {
            _dbContext.Rooms.Add(new Room(id: 1, number: 1, maxCustomersCapacity: 1));
            _dbContext.Rooms.Add(new Room(id: 2, number: 2, maxCustomersCapacity: 20));
            _dbContext.Rooms.Add(new Room(id: 3, number: 3, maxCustomersCapacity: 30));

            _dbContext.SaveChanges();
        }

        public void MockExercises()
        {
            _dbContext.Exercises.Add(new Exercise(id: 1, name: "Trening siłowy"));
            _dbContext.Exercises.Add(new Exercise(id: 2, name: "Pływanie"));
            _dbContext.Exercises.Add(new Exercise(id: 3, name: "Zumba"));
            _dbContext.Exercises.Add(new Exercise(id: 4, name: "Crossfit"));
            _dbContext.Exercises.Add(new Exercise(id: 5, name: "Gimnastyka"));
            _dbContext.Exercises.Add(new Exercise(id: 6, name: "Taniec"));

            _dbContext.SaveChanges();
        }
        
        public void MockExerciseRoom()
        {
            

        }

        public void MockCoachExercise()
        {

        }

    }
}
