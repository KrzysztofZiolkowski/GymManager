using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Models
{
    public class Coach : User
    {
        public Coach()
        {

        }
        public Coach(string firstName, string lastName, string phoneNumber, string email, string gender, DateTime createdAt, string profilePicture)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            CreatedAt = createdAt;
            ProfilePicture = profilePicture;

        }

        public virtual IList<Exercise> Exercises { get; set; } = new List<Exercise>();
        public virtual IList<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();
    }
}
