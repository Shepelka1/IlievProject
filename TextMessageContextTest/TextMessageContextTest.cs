using BusinessLayer;
using DataLayer;
using ServiceLayer;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace TextMessageContextTest
{
    public class Tests
    {
        MessagingDbContext dbContext;
        TextMessageContext textDbContext;

        [SetUp]
        public void Setup()
        {
            dbContext = new MessagingDbContext();
            textDbContext = new TextMessageContext(dbContext);
        }

        [Test]
        public async Task TextMessageContextCreateTest()
        {
            TextMessage message = new TextMessage("hello", null, null);

            await textDbContext.CreateAsync(message);

            Assert.That(dbContext.TextMessages.Contains(message));

            await textDbContext.DeleteAsync(message.Id);
        }

        [Test]
        public async Task TextMessageContextEditTest()
        {
            TextMessage message = new TextMessage("hello", null, null);

            await textDbContext.CreateAsync(message);

            message.Text = "bye";

            await textDbContext.UpdateAsync(message);

            Assert.That("bye" == textDbContext.ReadAsync(message.Id).Result.Text);

            await textDbContext.DeleteAsync(message.Id);
        }

        [Test]
        public async Task TextMessageContextReadTest()
        {
            TextMessage message = new TextMessage("hello", null, null);

            await textDbContext.CreateAsync(message);

            TextMessage messageFromDb = await textDbContext.ReadAsync(message.Id);

            Assert.That(message.Text == messageFromDb.Text &&
                message.Sender == messageFromDb.Sender &&
                message.Group == messageFromDb.Group);

            await textDbContext.DeleteAsync(message.Id);
        }

        [Test]
        public async Task TextMessageContextDeleteTest()
        {
            TextMessage message = new TextMessage("hello", null, null);

            await textDbContext.CreateAsync(message);
            await textDbContext.DeleteAsync(message.Id);

            Assert.That(!dbContext.TextMessages.Contains(message));
        }
    }
}