using BusinessLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class IdentityContext
    {
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        public readonly MessagingDbContext dbContext;

        public IdentityContext(MessagingDbContext dbContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.dbContext = dbContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task CreateAsync(User item)
        {
            try
            {
                await userManager.CreateAsync(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query.Include(u => u.Messages)
                         .Include(u => u.Groups);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(u => u.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query.Include(u => u.Messages)
                         .Include(u => u.Groups);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(User item, bool useNavigationalProperties = false)
        {
            try
            {
                User userFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);


                userFromDb.UserName = item.UserName;
                userFromDb.ProfilePicture = item.ProfilePicture;
                userFromDb.Password = item.Password;
                userFromDb.Status = item.Status;

                if (useNavigationalProperties)
                {
                    List<Group> groupsFromDb = dbContext.Groups.ToList();

                    foreach (Group group in item.Groups)
                    {
                        if (!groupsFromDb.Contains(group))
                        {
                            throw new NullReferenceException("No such group exists, dummy");
                        }
                    }

                    userFromDb.Groups = groupsFromDb.Intersect(item.Groups).ToList();
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClaimsPrincipal> LogInUserAsync(string username, string password)
        {
            try
            {
                User user = await userManager.FindByNameAsync(username);

                if (user == null)
                {
                    return null;
                }
                IdentityResult result = await userManager.PasswordValidators[0].ValidateAsync(userManager, user, password);

                if (result.Succeeded)
                {
                    User loggedUser = await dbContext.Users
                        .Include(u => u.Messages)
                        .FirstOrDefaultAsync(u => u.Id == user.Id);

                    return await signInManager.CreateUserPrincipalAsync(loggedUser);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAsync(string key)
        {
            try
            {
                User userFromDb = await ReadAsync(key, false, false);

                if (userFromDb == null)
                {
                    throw new ArgumentException("A user with that key does not exist!");
                }

                dbContext.Users.Remove(userFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
