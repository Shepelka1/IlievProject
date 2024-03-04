using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class GroupManager
    {
        private readonly GroupContext groupContext;

        public GroupManager(GroupContext groupContext)
        {
            this.groupContext = groupContext;
        }

        public async Task CreateAsync(Group group)
        {
            await groupContext.CreateAsync(group);
        }

        public async Task<Group> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await groupContext.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<ICollection<Group>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            return await groupContext.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(Group group, bool useNavigationalProperties = false)
        {
            await groupContext.UpdateAsync(group, useNavigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await groupContext.DeleteAsync(key);
        }

        public async Task AddTextMessageAsync(Group item, TextMessage message)
        {
            await groupContext.AddTextMessageAsync(item, message);
        }
    }
}