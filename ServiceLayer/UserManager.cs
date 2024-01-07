using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserManager
    {
        private readonly UserContext userContext;

        public UserManager(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task CreateAsync(User user)
        {
            await userContext.CreateAsync(user);
        }

        public async Task<User> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await userContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await userContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(User user, bool useNavigationalProperties = false)
        {
            await userContext.UpdateAsync(user, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await userContext.DeleteAsync(key);
        }
    }
}
