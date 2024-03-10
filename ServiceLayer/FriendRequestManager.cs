using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class FriendRequestManager
    {
        private readonly FriendRequestContext friendRequestContext;

        public FriendRequestManager(FriendRequestContext friendRequestContext)
        {
            this.friendRequestContext = friendRequestContext;
        }
        public async Task CreateAsync(FriendRequest item)
        {
            await friendRequestContext.CreateAsync(item);
        }

        public async Task<FriendRequest> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await friendRequestContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<FriendRequest>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await friendRequestContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task DeleteAsync(string key)
        {
            await friendRequestContext.DeleteAsync(key);
        }
    }
}
