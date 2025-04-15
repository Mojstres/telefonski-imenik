using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using TelefonskiImenik.DataAccess;
using System.IO;
using System.Linq;

namespace TelefonskiImenik.Tests
{
    [TestClass]
    public class ContactRepositoryTests
    {
        private readonly string _connectionString;

        public ContactRepositoryTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("conn")
                ?? throw new InvalidOperationException("Connection string 'conn' not found.");
        }

        [TestMethod]
        public void CanReadAllContacts()
        {
            var repository = new ContactRepository(_connectionString);
            var contacts = repository.GetAll();
            Assert.IsNotNull(contacts);
        }

        [TestMethod]
        public void CanAddContact_AndRollback()
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled);

            var repository = new ContactRepository(_connectionString);
            var contact = new Contact(0, "Testni Janez", "040234567");

            repository.Add(contact);

            var results = repository.Search("Testni Janez");

            Assert.IsTrue(results.Any(c => c.Stevilka == "040234567"));
        }
    }
}
