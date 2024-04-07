using BusinessLayer;
using DataLayer;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DbContextTest
{
    internal class GroupContextTest
    {
        MessagingDbContext dbContext;
        TextMessageContext textDbContext;
        GroupContext groupDbContext;

        [SetUp]
        public void Setup()
        {
            dbContext = new MessagingDbContext();
            textDbContext = new TextMessageContext(dbContext);
            groupDbContext = new GroupContext(dbContext, textDbContext);
        }
        [Test]
        public async Task GroupContextCreateTest()
        {
            Group group = new Group("Name", null, null, null);

            await groupDbContext.CreateAsync(group);

            Assert.That(dbContext.Groups.Contains(group));

            await groupDbContext.DeleteAsync(group.Id);
        }

        [Test]
        public async Task GroupContextEditTest()
        {
            Group group = new Group("Name", null, null, null);

            await groupDbContext.CreateAsync(group);

            group.Name = "CoolName";

            await groupDbContext.UpdateAsync(group);

            Assert.That("CoolName" == groupDbContext.ReadAsync(group.Id).Result.Name);

            await groupDbContext.DeleteAsync(group.Id);
        }

        [Test]
        public async Task GroupContextReadTest()
        {
            Group group = new Group("Name", null, null, null);

            await groupDbContext.CreateAsync(group);

            Group groupFromDb = await groupDbContext.ReadAsync(group.Id);

            Assert.That(group.Name == groupFromDb.Name && group.CoverImage == groupFromDb.CoverImage);

            await groupDbContext.DeleteAsync(group.Id);
        }

        [Test]
        public async Task GroupContextDeleteTest()
        {
            Group group = new Group("Name", null, null, null);

            await groupDbContext.CreateAsync(group);
            await groupDbContext.DeleteAsync(group.Id);

            Assert.That(!dbContext.Groups.Contains(group));
        }
    }
}
