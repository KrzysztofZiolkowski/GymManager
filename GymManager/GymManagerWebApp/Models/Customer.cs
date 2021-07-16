using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Customer : User
    {
        public Customer()
        {

        }
        public Customer(string firstName, string lastName, string phoneNumber, string email, string gender, DateTime createdAt, string profilePicture)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            CreatedAt = createdAt;
            ProfilePicture = profilePicture;

        }
        public virtual IList<Purchase> Purchases { get; set; } = new List<Purchase>();
        public virtual IList<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
