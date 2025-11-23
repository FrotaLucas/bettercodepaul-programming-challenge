using BetterCodePaulChallenge.ConsoleApp.Application.Orquestration;
using BetterCodePaulChallenge.ConsoleApp.Domain.Contracts.Repository;
using BetterCodePaulChallenge.ConsoleApp.Domain.Entities;
using Moq;


namespace BetterCodePaulChallange.UnitTest
{
 
    public class WeatherServiceTests
    {
        [Fact]
        public void GetSmallestSpread_ShouldReturnCorrectDay()
        {
            var mockRepo = new Mock<IWeatherRepository>();
            var weatherData = new List<WeatherData>
        {
            new WeatherData { Day = 1, MxT = 30, MnT = 20, AvT = 25 }, 
            new WeatherData { Day = 2, MxT = 28, MnT = 27, AvT = 27.5 }, 
            new WeatherData { Day = 3, MxT = 25, MnT = 20, AvT = 22.5 } 
        };

            mockRepo.Setup(r => r.GetWheaterData()).Returns(weatherData);

            var service = new WeatherService(mockRepo.Object);

            var result = service.GetSmallestSpread();

            Assert.NotNull(result);
            Assert.Equal(2, result.Day);
            Assert.Equal(1, result.Amplitude);
        }

        [Fact]
        public void GetSmallestSpread_ShouldReturnNull_WhenNoData()
        {
            var mockRepo = new Mock<IWeatherRepository>();
            mockRepo.Setup(r => r.GetWheaterData()).Returns(new List<WeatherData>());

            var service = new WeatherService(mockRepo.Object);

            var result = service.GetSmallestSpread();

            Assert.Null(result);
        }
    }

}