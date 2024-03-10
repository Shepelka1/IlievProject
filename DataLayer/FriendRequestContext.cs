using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FriendRequestContext
    {
        public readonly MessagingDbContext dbContext;

        public FriendRequestContext(MessagingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(FriendRequest item)
        {
            try
            {
                dbContext.FriendRequests.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FriendRequest> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<FriendRequest> query = dbContext.FriendRequests;

                if (useNavigationalProperties)
                {
                    query = query.Include(i => i.Sender)
                                 .Include(i => i.Receiver);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(i => i.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<FriendRequest>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<FriendRequest> query = dbContext.FriendRequests;

                if (useNavigationalProperties)
                {
                    query = query.Include(i => i.Sender)
                                 .Include(i => i.Receiver);
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

        public async Task DeleteAsync(string key)
        {
            try
            {
                FriendRequest friendRequestFromDb = await ReadAsync(key, false, false);

                if (friendRequestFromDb == null)
                {
                    throw new ArgumentException("A message with that key does not exist!");
                }

                dbContext.FriendRequests.Remove(friendRequestFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
