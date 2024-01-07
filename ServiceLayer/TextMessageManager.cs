using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TextMessageManager
    {
        private readonly TextMessageContext textMessageContext;

        public TextMessageManager(TextMessageContext textMessageContext)
        {
            this.textMessageContext = textMessageContext;
        }

        public async Task CreateAsync(TextMessage textMessage)
        {
            await textMessageContext.CreateAsync(textMessage);
        }

        public async Task<TextMessage> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await textMessageContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<TextMessage>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await textMessageContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(TextMessage textMessage, bool useNavigationalProperties = false)
        {
            await textMessageContext.UpdateAsync(textMessage, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await textMessageContext.DeleteAsync(key);
        }
    }
}
