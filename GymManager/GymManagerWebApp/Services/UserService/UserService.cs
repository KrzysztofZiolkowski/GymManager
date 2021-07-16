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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly GymManagerContext _dbContext;
        private readonly IFileService _fileService;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, GymManagerContext dbContext,
            IFileService fileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
        public async Task<List<User>> GetUsersAsync(string currentUserEmail)
        {
            return await _dbContext.Users
                    .Where(x=>x.NormalizedEmail != currentUserEmail)
                    .Select(x => x).ToListAsync();
        }
        public async Task<Customer> GetUserByIdAsync(string userId)
        {
            return (Customer)await _dbContext.Users
                    .FindAsync(userId);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users
                    .SingleOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User> UpdateUser(User user)
        {
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<string> GetUserIdByEmailAsync(string email)
        {
            return await _dbContext.Users
                .Where(x => x.Email == email)
                .Select(x => x.Id)
                .SingleOrDefaultAsync();
        }
        public List<User> SortUsersByEmails(List<User> users)
        {
            return users.OrderBy(x => x.Email).ToList();
        }
        public User CreateAddUserVievModel(AddUserViewModel model)
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
        public async Task<string> GetRoleName (User user)
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
        public Customer CreateCustomer(RegisterCustomerViewModel model)
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
        public string FormatTextFirstLetterBigRestSmall(string textToTransform)
        {
            return char.ToUpper(textToTransform[0]) + textToTransform.Substring(1);
        }
        public EditUserViewModel CreateEditUserViewModel (User user, string userRole, List<string> allRoles)
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
        public User CreateUpdatedUserModel(User user, EditUserViewModel model)
        {
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            return user;
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
        public async Task<IdentityResult> CreateUser (AddUserViewModel model)
        {
            var newUser = CreateAddUserVievModel(model);
            await _userManager.AddToRoleAsync(newUser, model.Role);
            var result = await _userManager.CreateAsync(newUser, model.Password1);

            return result;
        }
        public async Task<IdentityResult> RemoveUser (string userId)
        {
            var userToRemove = await _userManager.FindByIdAsync(userId);
            return await _userManager.DeleteAsync(userToRemove);
        }
        public async Task<IdentityResult> UpdateUser (EditProfileViewModel newModel)
        {
            var userToUpdate = await _userManager.FindByIdAsync(newModel.Id);

            await UpdateUserRole(userToUpdate, newModel.CurrentUserRole);
            var updatedUser = CreateUpdatedUserModel(userToUpdate, newModel);

            return await _userManager.UpdateAsync(updatedUser);
        }
        public async Task UpdateUserRole(User userToUpdate, string newRole)
        {
            var roles = await _userManager.GetRolesAsync(userToUpdate);
            await _userManager.RemoveFromRolesAsync(userToUpdate, roles);
            await _userManager.AddToRoleAsync(userToUpdate, newRole);
        }
        public User UpdateUserAttributes(EditProfileViewModel userFromView, User userToUpdate)
        {
            userToUpdate.FirstName = userFromView.FirstName;
            userToUpdate.LastName = userFromView.LastName;
            userToUpdate.PhoneNumber = userFromView.PhoneNumber;
            userToUpdate.Gender = userFromView.Gender;

            if (userFromView.ProfilePicture != null)
            {
                userToUpdate.ProfilePicture = _fileService.UploadFile(userFromView);
            }

            return userToUpdate;
        }
    }
}