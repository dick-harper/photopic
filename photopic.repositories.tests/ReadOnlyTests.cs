using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using photopic.domain;
using photopic.repositories.Contexts;

namespace photopic.repositories.tests
{
    [TestClass]
    public class ReadOnlyTests
    {
        [TestMethod]
        public void AddUserTest()
        {
            const string connectionString = "mongodb://localhost";
            string databaseName = typeof(User).Name;
            //IMongoClient client = new MongoClient(connectionString);
            //IMongoDatabase database = client.GetDatabase(databaseName);

            //MongoContext context = new MongoContext(database);
            //var collection = context.GetCollection<User>();

            IReadOnlyMongoRepository repo = new ReadOnlyMongoRepository();
            repo.ConnectionString = connectionString;
            repo.DatabaseName = databaseName;
            
            var user = new User
            {
                Active = false,
                Email = "ted.shred@photopic.com",
                FirstName = "Ted",
                LastName = "Shred",
                LoginId = "teds",
                Phone = "3035556767"
            };

            repo.GetByIdAsync<User>(Guid.NewGuid());

            Assert.AreEqual(Guid.NewGuid(), user.Id);
        }
    }
}
