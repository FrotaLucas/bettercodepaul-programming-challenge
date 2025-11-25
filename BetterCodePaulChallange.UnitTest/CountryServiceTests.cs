using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration;
using BetterCodePaulChallenge.ConsoleApp.Application.Model;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using Moq;

namespace BetterCodePaulChallange.UnitTest
{
    public class CountryServiceTests
    {
        [Fact]
        public void GethighestDensity_ShouldReturnCountryWithHighestDensity()
        {
            var mockRepo = new Mock<ICountryRepository>();

            var countries = new List<CountryData>
            {
                new CountryData { Name = "Austria", Population = 9000000, AreaKm2 = 80000 }, 
                new CountryData { Name = "Belgium", Population = 11500000, AreaKm2 = 30000 },
                new CountryData { Name = "Croatia", Population = 4000000, AreaKm2 = 56000 }  
            };

            mockRepo.Setup(r => r.GetCountryData()).Returns(countries);

            var service = new CountryService(mockRepo.Object);

            var result = service.GethighestDensity();

            Assert.NotNull(result);
            Assert.Equal("Belgium", result.Name);
            Assert.Equal(11500000, result.Population);
            Assert.Equal(30000, result.AreaKm2);
            Assert.Equal(11500000.0 / 30000.0, result.Density);
        }

        [Fact]
        public void GethighestDensity_ShouldReturnNull_WhenNoData()
        {
            var mockRepo = new Mock<ICountryRepository>();

            mockRepo.Setup(r => r.GetCountryData()).Returns(new List<CountryData>());

            var service = new CountryService(mockRepo.Object);

            var result = service.GethighestDensity();

            Assert.Null(result);
        }
    }
}
