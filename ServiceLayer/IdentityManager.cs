using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class IdentityManager
    {
        private readonly IdentityContext identityContext;

        public IdentityManager(IdentityContext identityContext)
        {
            this.identityContext = identityContext;
        }

        public async Task CreateAsync(User user)
        {
            await identityContext.CreateAsync(user);
        }

        public async Task<User> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await identityContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<User>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await identityContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(User user, bool useNavigationalProperties = false)
        {
            await identityContext.UpdateAsync(user, useNavigationalProperties);
        }

        public async Task<ClaimsPrincipal> LogInUserAsync(string username, string password)
        {
            return await identityContext.LogInUserAsync(username, password);
        }

            public async Task DeleteAsync(string key)
        {
            await identityContext.DeleteAsync(key);
        }
    }
}
