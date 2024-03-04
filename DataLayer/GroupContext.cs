using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class GroupContext
    {
        public readonly MessagingDbContext dbContext;
        public readonly TextMessageContext textMessageContext;

        public GroupContext(MessagingDbContext dbContext, TextMessageContext textMessageContext)
        {
            this.dbContext = dbContext;
            this.textMessageContext = textMessageContext;
        }

        public async Task CreateAsync(Group item)
        {
            try
            {
                dbContext.Groups.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Group> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Group> query = dbContext.Groups;

                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Messages)
                         .Include(g => g.Users);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(g => g.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<Group>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<Group> query = dbContext.Groups;

                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Messages)
                         .Include(g => g.Users);
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

        public async Task UpdateAsync(Group item, bool useNavigationalProperties = false)
        {
            try
            {
                Group groupFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);


                groupFromDb.Name = item.Name;
                groupFromDb.CoverImage = item.CoverImage;
                groupFromDb.Messages = item.Messages;

                if (useNavigationalProperties)
                {
                    List<User> usersFromDb = dbContext.Users.ToList();

                    foreach (User user in item.Users)
                    {
                        if (!usersFromDb.Contains(user))
                        {
                            throw new NullReferenceException("No such user exists, dummy");
                        } 
                    }

                    groupFromDb.Users = usersFromDb.Intersect(item.Users).ToList();
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
                Group groupFromDb = await ReadAsync(key, false, false);

                if (groupFromDb == null)
                {
                    throw new ArgumentException("A group with that key does not exist!");
                }

                dbContext.Groups.Remove(groupFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddTextMessageAsync(Group item, TextMessage message)
        {
            await textMessageContext.CreateAsync(message);
            await dbContext.SaveChangesAsync();
        }

    }
}
