using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;

namespace GymManagerWebApp.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string PhoneNumber { get; set; }
        public override string Email { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProfilePicture { get; set; }
        public static object Identity { get; set; }
        public virtual IList<QuantityCarnet> QuantityCarnets { get; set; } = new List<QuantityCarnet>();
        public virtual IList<TimeCarnet> TimeCarnets { get; set; } = new List<TimeCarnet>();

        public User()
        {
        }

        public User(string firstName, string lastName, string gender, DateTime createdAt, string profilePicture)
        {
            FirstName = firstName;
            LastName= lastName;
            Gender = gender;
            CreatedAt = createdAt;
            ProfilePicture = profilePicture;
        }
    }
}