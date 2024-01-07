using DataLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ImageMessageManager
    {
        private readonly ImageMessageContext imageMessageContext;

        public ImageMessageManager(ImageMessageContext imageMessageContext)
        {
            this.imageMessageContext = imageMessageContext;
        }

        public async Task CreateAsync(ImageMessage image)
        {
            await imageMessageContext.CreateAsync(image);
        }

        public async Task<ImageMessage> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await imageMessageContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<ImageMessage>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await imageMessageContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(ImageMessage image, bool useNavigationalProperties = false)
        {
            await imageMessageContext.UpdateAsync(image, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await imageMessageContext.DeleteAsync(key);
        }
    }
}
