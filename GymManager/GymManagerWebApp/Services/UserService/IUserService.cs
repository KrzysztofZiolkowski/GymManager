using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace GymManagerWebApp.Services
{
    public interface IUserService
    {
        Task<string> GetRoleName(User user);
        [Authorize(Roles = "Admin")]
        Task<User> GetUserByEmailAsync(string email);
        [Authorize(Roles = "Admin")]
        Task<Customer> GetUserByIdAsync(string userId);
        Task<List<User>> GetUsersAsync(string currentUserEmail);
        User CreateAddUserViewModel(AddUserViewModel model);
        EditUserViewModel CreateEditUserViewModel(User model, string modelRole, List<string> allRoles);
        Task<SignInResult> LoginAsync(LoginViewModel login);
        Task LogoutAsync();
        List<User> SortUsersByEmails(List<User> users);
        Task<string> GetUserIdByEmailAsync(string email);
        Task<IdentityResult> CreateUser(AddUserViewModel model);
        Task<IdentityResult> RemoveUser(string userId);
        Task<IdentityResult> UpdateUser(EditProfileViewModel newModel);
        Customer CreateCustomerViewModel(RegisterCustomerViewModel model);
        EditProfileViewModel CreateEditProfileViewModel(Customer currrentUser);
        User UpdateUserAttributes(EditProfileViewModel userFromView, User userToUpdate);
    }
}