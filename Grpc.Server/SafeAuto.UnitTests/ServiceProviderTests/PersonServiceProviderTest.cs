using Grpc.SA.DAL.IRepository;
using Grpc.SA.DAL.IServiceProviders;
using Grpc.SA.DAL.Models;
using Grpc.SA.DAL.ServiceProviders;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SafeAuto.UnitTests.ServiceProviderTests
{
    public class PersonServiceProviderTest
    {
        private readonly IPersonServiceProvider _personServiceProvider;
        private readonly Mock<IPersonRepository> _personRepository = new Mock<IPersonRepository>();
        public PersonServiceProviderTest()
        {
            _personServiceProvider = new PersonServiceProvider(_personRepository.Object);
        }

        [Fact]
        public async Task GetPersonByIdAsync_ShouldReturnPerson_WhenPersonExists()
        {
            //Arrange
            int personId = 1;
            var personData = new Person {
                Id = 1,
                FirstName = "SafeAuto",
                LastName = "Development",
                Addresses = new List<Address>()
            };
            _personRepository.Setup(s => s.GetPersonByIdAsync(personId)).ReturnsAsync(personData);

            //Act
            var result = await _personServiceProvider.GetPersonByIdAsync(personId);

            //Assert

            Assert.Equal(personId, result.Id);
            Assert.Equal(personData.FirstName, result.FirstName);
            Assert.Equal(personData.LastName, result.LastName);
        }
    }
}
