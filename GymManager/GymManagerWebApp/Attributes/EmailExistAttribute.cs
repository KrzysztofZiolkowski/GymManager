using GymManagerWebApp.Data;
using GymManagerWebApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Attributes
{
    public class EmailExistsAttribute : ValidationAttribute
    {
        private readonly string _errorMessage;

        public EmailExistsAttribute(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (EmailAlreadyRegistered(value))
            {
                return new ValidationResult(_errorMessage);
            }

            return ValidationResult.Success;
        }

        private bool EmailAlreadyRegistered(object emailToRegister)
        {
            using (var context = new GymManagerContext())
            {
                return context.Users.Any(x => x.Email == emailToRegister.ToString());
            };
        }
    }
}
