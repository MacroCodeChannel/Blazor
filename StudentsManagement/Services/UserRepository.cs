using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using StudentsManagement.Client.Models;
using StudentsManagement.Client.Repository;
using StudentsManagement.Client.ViewModels;
using StudentsManagement.Data;

namespace StudentsManagement.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserRepository(SignInManager<ApplicationUser> signInManager ,RoleManager<ApplicationRole> roleManager,UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            this._userManager = userManager;
            this._context = context;
            this._roleManager = roleManager;
            this._signInManager = signInManager;    
        }

        public async Task<RegisterUserViewModel> AddAsync(RegisterUserViewModel mod)
        {
                if (mod == null) return null;
                var user = CreateUser();
                user.NormalizedUserName = mod.UserName;
                user.NormalizedEmail = mod.Email;
                user.FirstName = mod.FirstName;
                user.LastName = mod.LastName;
                user.MiddleName = mod.MiddleName;
                user.Email = mod.Email;
                user.GenderId = mod.GenderId;
                user.IsActive = true;
                user.EmailConfirmed = true;
                user.UserName = mod.UserName;
                user.LockoutEnabled = true;
                user.Photo = "photo.jpg";
                user.LastActivityDate = DateTime.Now;
                var result = await _userManager.CreateAsync(user, mod.Password);
           
            return mod;
        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }

      
        public async Task<ApplicationUser> DeleteAsync(string id)
        {
            var data = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            _context.Users.Remove(data);
            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            var data = await _context.Users
                .Include(x => x.Gender)
                .ToListAsync();

            return data;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var data = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null) return null;

            return data;
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser mod)
        {
            if (mod == null) return null;

            var data = _context.Users.Update(mod).Entity;
            await _context.SaveChangesAsync();

            return data;
        }
    }
}
