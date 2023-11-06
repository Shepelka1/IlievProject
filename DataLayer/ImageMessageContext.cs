using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ImageMessageContext
    {
        public readonly MessagingDbContext dbContext;

        public ImageMessageContext(MessagingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(ImageMessage item)
        {
            try
            {
                dbContext.ImageMessages.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ImageMessage> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<ImageMessage> query = dbContext.ImageMessages;

                if (useNavigationalProperties)
                {
                    query = query.Include(i => i.Sender)
                                 .Include(i => i.Group);
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

        public async Task<ICollection<ImageMessage>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            try
            {
                IQueryable<ImageMessage> query = dbContext.ImageMessages;

                if (useNavigationalProperties)
                {
                    query = query.Include(i => i.Sender)
                                 .Include(i => i.Group);
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

        public async Task UpdateAsync(ImageMessage item, bool useNavigationalProperties = false)
        {
            try
            {
                ImageMessage imageMessageFromDb = await ReadAsync(item.Id, useNavigationalProperties, false);


                imageMessageFromDb.Image = item.Image;
                imageMessageFromDb.Description = item.Description;
                imageMessageFromDb.SentDateTime = item.SentDateTime;

                if (useNavigationalProperties)
                {
                    imageMessageFromDb.SenderId = item.SenderId;
                    imageMessageFromDb.Sender = item.Sender;
                    imageMessageFromDb.GroupId = item.GroupId;
                    imageMessageFromDb.Group = item.Group;
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
                ImageMessage imageMessageFromDb = await ReadAsync(key, false, false);

                if (imageMessageFromDb == null)
                {
                    throw new ArgumentException("A message with that key does not exist!");
                }

                dbContext.ImageMessages.Remove(imageMessageFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
