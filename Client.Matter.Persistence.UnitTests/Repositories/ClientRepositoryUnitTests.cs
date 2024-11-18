using Client.Matter.Persistence.Entities;
using Client.Matter.Persistence.Implementations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace Client.Matter.Persistence.UnitTests.Repositories
{
    [TestClass]
    public class ClientRepositoryUnitTests
    {
        private static SqliteConnection _sqliteConnection;
        private static DbContextOptions<SqliteClientMatterDbContext> _options;
        private static ClientEf _client1;
        private static AddressEf _addressForClient1;
        private static PeopleEf _person1ForClient1;

        [ClassInitialize]
        public static void InitializeClass(TestContext _1)
        {
            _sqliteConnection = new SqliteConnection("Filename=:memory:");
            _sqliteConnection.Open();

            _options = new DbContextOptionsBuilder<SqliteClientMatterDbContext>()
                .UseSqlite(_sqliteConnection)
                .Options;

            _addressForClient1 = new AddressEf()
            {
                AddressId = 1,
                AddressLine1 = "1 Cherry Tree Lane",
                AddressLine2 = "Kensington",
                City = "London",
                County = "London town",
                Postcode = "NW1 4TY"
            };

            _person1ForClient1 = new PeopleEf()
            {
                Email = "joe.bloggs@hotmail.co.uk",
                FirstName = "Joseph",
                LastName = "Bloggs",
                Phone = "0151 100 2000",
                PreferredName = "Joe",
                Title = "Mr"
            };

            _client1 = new ClientEf()
            {
                AddressId = 1,
                ClientId = "12345",
                Code = "Client1",
                Description = "First client description",
                InceptionDate = DateTime.Now,
                MatterCount = 0,
                Name = "Joe Bloggs company",
                People = new List<PeopleEf>() { _person1ForClient1 }
            };

            _person1ForClient1.ClientId = _client1.ClientId;

            using (var dbContext = new SqliteClientMatterDbContext(_options))
            {
                dbContext.Database.EnsureCreated();

                dbContext.Addresses.Add(_addressForClient1);

                dbContext.Clients.Add(_client1);

                dbContext.Peoples.Add(_person1ForClient1);

                dbContext.SaveChanges();
            }
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            _sqliteConnection.Dispose();
        }        

        public static ClientRepository CreateObjectUnderTest()
        {
            var dbContext = new SqliteClientMatterDbContext(_options);
            return new ClientRepository(dbContext);
        }

        [TestMethod]
        public async Task GetClientByIdAsync_SuccessfullyReturnsClient()
        {
            //Arrange
            var objectUnderTest = CreateObjectUnderTest();

            //Act
            var result = await objectUnderTest.GetClientByIdAsync(_client1.ClientId);

            //Assert
            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(_client1);
        }

        [TestMethod]
        public async Task GetClientByIdAsync_ReturnsNullWhenClientIdDoesNotExist()
        {
            //Arrange
            var invalidClientId = "Whatever";
            var objectUnderTest = CreateObjectUnderTest();

            //Act
            var result = await objectUnderTest.GetClientByIdAsync(invalidClientId);

            //Assert
            result.ShouldBeNull();
        }
    }
}