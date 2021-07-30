using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using GymManagerWebApp.Models.Admin;
using GymManagerWebApp.Services.FileService;

namespace GymManagerWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly GymManagerContext _dbContext;
        private readonly IFileService _fileService;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager,GymManagerContext dbContext,
            IFileService fileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailure: false);
            return result;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<Customer> GetUserByIdAsync(string userId)
        {
            return (Customer)await _dbContext.Users
                    .FindAsync(userId);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Where(x => x.Email == email)
                .Select(x => x.Id)
                .SingleOrDefaultAsync();
        }
        public async Task<List<User>> GetUsersAsync(string currentUserEmail)
        {
            return await _dbContext.Users
                    .Where(x => x.NormalizedEmail != currentUserEmail)
                    .Select(x => x).ToListAsync();
        }
        public async Task<string> GetRoleName(User user)
        {
            var roleId = _dbContext.UserRoles
                .Where(x => x.UserId == user.Id)
                .Select(x => x.RoleId)
                .ToString();

            var roleName = await _dbContext.Roles
                .Where(x => x.Id == roleId)
                .Select(x => x.Name)
                .SingleOrDefaultAsync();

            return roleName;
        }
        public async Task<IdentityResult> CreateUser(AddUserViewModel model)
        {
            var newUser = CreateAddUserViewModel(model);
            await _userManager.AddToRoleAsync(newUser, model.Role);
            var result = await _userManager.CreateAsync(newUser, model.Password1);

            return result;
        }
        public User CreateAddUserViewModel(AddUserViewModel model)
        {
            var user = new User()
            {
                FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1),
                LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1),
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                CreatedAt = DateTime.UtcNow,
            };
            return user;
        }
        public Customer CreateCustomerViewModel(RegisterCustomerViewModel model)
        {
            var customer = new Customer
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = FormatTextFirstLetterBigRestSmall(model.FirstName),
                LastName = FormatTextFirstLetterBigRestSmall(model.LastName),
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                CreatedAt = DateTime.UtcNow,
                ProfilePicture = _fileService.UploadFile(model),
            };

            return customer;
        }
        public EditUserViewModel CreateEditUserViewModel(User user, string userRole, List<string> allRoles)
        {
            var userViewModel = new EditUserViewModel()
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                AllRoles = allRoles,
                CurrentUserRole = userRole,
            };
            return userViewModel;
        }
        public User CreateUpdatedUserModel(User userToUpdate, EditProfileViewModel newUserData)
        {
            userToUpdate.FirstName = newUserData.FirstName;
            userToUpdate.LastName = newUserData.LastName;
            userToUpdate.PhoneNumber = newUserData.PhoneNumber;
            userToUpdate.Gender = newUserData.Gender;
            userToUpdate.ProfilePicture =  _fileService.UploadFile(newUserData);

            return userToUpdate;
        }
        public EditProfileViewModel CreateEditProfileViewModel(Customer currrentUser)
        {
            return new EditProfileViewModel()
            {
                Id = currrentUser.Id,
                Email = currrentUser.Email,
                FirstName = currrentUser.FirstName,
                LastName = currrentUser.LastName,
                Gender = currrentUser.Gender,
                PhoneNumber = currrentUser.PhoneNumber,
                ProfilePicturePath = currrentUser.ProfilePicture,
            };
        }
        public async Task<IdentityResult> RemoveUser (string userId)
        {
            var userToRemove = await _userManager.FindByIdAsync(userId);
            return await _userManager.DeleteAsync(userToRemove);
        }
        public async Task<IdentityResult> UpdateCustomer (EditProfileViewModel newCustomerData, string curruentCustomerId)
        {
            var customerToUpdate = await _userManager.FindByIdAsync(curruentCustomerId);
            var updatedCustomer = CreateUpdatedUserModel(customerToUpdate, newCustomerData);

            return await _userManager.UpdateAsync(updatedCustomer);
        }
        public async Task UpdateUserRole(User userToUpdate, string newRole)
        {
            var roles = await _userManager.GetRolesAsync(userToUpdate);
            await _userManager.RemoveFromRolesAsync(userToUpdate, roles);
            await _userManager.AddToRoleAsync(userToUpdate, newRole);
        }
        public string FormatTextFirstLetterBigRestSmall(string textToTransform)
        {
            return char.ToUpper(textToTransform[0]) + textToTransform.Substring(1);
        }
        public List<User> SortUsersByEmails(List<User> users)
        {
            return users.OrderBy(x => x.Email).ToList();
        }
    }
}