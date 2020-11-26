using ServerlessTurkey.API.Mappers;
using ServerlessTurkey.API.Models;
using Xunit;

namespace ServerlessTurkey.API.UnitTests.MapperTests
{
    public class TurkeyWeightMapperShould
    {
        [Fact]
        public void GenerateTurkeyRecipeCorrectly()
        {
            // Arrange
            var sut = new TurkeyWeightMapper();
            var testInput = new TurkeyWeightInput
            {
                TurkeyWeightInPounds = 20.0
            };

            // Act
            var response = sut.GenerateTurkeyRecipe(testInput);

            // Assert
            Assert.Equal(1.0, response.SaltCups);
            Assert.Equal(13.2, response.WaterInGallons);
            Assert.Equal(3, response.BrownSugarCups);
            Assert.Equal(4, response.Shallots);
            Assert.Equal(8, response.ClovesOfGarlic);
            Assert.Equal(3, response.WholePeppercorns);
            Assert.Equal(3, response.DriedJuniperBerries);
            Assert.Equal(3, response.FreshRosemary);
            Assert.Equal(1, response.Thyme);
            Assert.Equal(48.0, response.BrineTime);
            Assert.Equal(300.0, response.RoastTime);
        }
    }
}
