using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TextMessageContext
    {
        public readonly MessagingDbContext dbContext;

        public TextMessageContext(MessagingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(TextMessage item)
        {
            try
            {
                dbContext.TextMessages.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TextMessage> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<TextMessage> query = dbContext.TextMessages;

                if (useNavigationalProperties)
                {
                    query = query.Include(t => t.Sender)
                                 .Include(t => t.Group);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(t => t.Id == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<TextMessage>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<TextMessage> query = dbContext.TextMessages;

                if (useNavigationalProperties)
                {
                    query = query.Include(t => t.Sender)
                                 .Include(t => t.Group);
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

        public async Task UpdateAsync(TextMessage item, bool useNavigationalProperties = false)
        {
            try
            {
                TextMessage textMessageFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);

                
                textMessageFromDb.Text = item.Text;
                textMessageFromDb.SentDateTime = item.SentDateTime;

                if (useNavigationalProperties)
                {
                    textMessageFromDb.SenderId = item.SenderId;
                    textMessageFromDb.Sender = item.Sender;
                    textMessageFromDb.GroupId = item.GroupId;
                    textMessageFromDb.Group = item.Group;
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
                TextMessage textMessageFromDb = await ReadAsync(key, false, false);

                if (textMessageFromDb == null)
                {
                    throw new ArgumentException("A message with that key does not exist!");
                }

                dbContext.TextMessages.Remove(textMessageFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
