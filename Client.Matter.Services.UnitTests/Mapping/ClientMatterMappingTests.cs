using AutoMapper;
using Client.Matter.Models.DTOs;
using Client.Matter.Persistence.Entities;
using Client.Matter.Services.Mapping;
using Shouldly;

namespace Client.Matter.Services.UnitTests.Mapping
{
    [TestClass]
    public class ClientMatterMappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;
        private readonly ClientEf _clientEf;

        public ClientMatterMappingTests()
        {
            _configuration = new MapperConfiguration(x => x.AddProfile(new ClientMatterMappingProfile()));
            _mapper = new Mapper(_configuration);

            _clientEf = new ClientEf() { ClientId = "1", AddressId = 100, Code = "123", Description = "Test desc", InceptionDate = DateTime.Now, MatterCount = 7, Name = "Bob's industries",
                                        Address = new AddressEf() { AddressId = 100, AddressLine1 = "1 Cherry Lane", City = "Springfield", Postcode = "Sp1" },
                                        People = new List<PeopleEf>() { new PeopleEf() { ClientId = "1", FirstName = "David", LastName = "Jones", PreferredName = "Dave" } }
            };
        }

        [TestMethod]
        public void ConfigurationIsValid()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void MapClientCorrectly()
        {
            //Act
            var mapped = _mapper.Map<ClientEf, ClientDto>(_clientEf);

            //Assert
            mapped.Address.AddressId.ShouldBe(_clientEf.AddressId);
            mapped.Address.Postcode.ShouldBe(_clientEf.Address.Postcode);
            mapped.Description.ShouldBe(_clientEf.Description);
            mapped.InceptionDate.ShouldBe(_clientEf.InceptionDate);
            mapped.People.First().FirstName.ShouldBe(_clientEf.People.First().FirstName);
            mapped.People.First().PreferredName.ShouldBe(_clientEf.People.First().PreferredName);
        }
    }
}