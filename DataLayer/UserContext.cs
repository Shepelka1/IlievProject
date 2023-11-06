using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserContext
    {
        public readonly MessagingDbContext dbContext;

        public UserContext(MessagingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(User item)
        {
            try
            {
                dbContext.Users.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<User> query = dbContext.Users;

                if (useNavigationalProperties)
                {
                    query.Include(u => u.TextMessages)
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
                    query.Include(u => u.TextMessages)
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


                userFromDb.Userame = item.Userame;
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

        public async Task DeleteAsync(int key)
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
