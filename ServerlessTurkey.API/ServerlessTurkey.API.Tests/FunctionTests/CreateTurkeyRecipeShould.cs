using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using ServerlessTurkey.API.Functions;
using ServerlessTurkey.API.Mappers;
using ServerlessTurkey.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServerlessTurkey.API.UnitTests.FunctionTests
{
    public class CreateTurkeyRecipeShould
    {
        private readonly Mock<ILogger<CreateTurkeyRecipe>> _loggerMock;
        private readonly Mock<HttpRequest> _httpRequestMock;
        private readonly Mock<TurkeyWeightMapper> _turkeyMapperMock;

        private CreateTurkeyRecipe _func;

        public CreateTurkeyRecipeShould()
        {
            _loggerMock = new Mock<ILogger<CreateTurkeyRecipe>>();
            _httpRequestMock = new Mock<HttpRequest>();
            _turkeyMapperMock = new Mock<TurkeyWeightMapper>();

            _func = new CreateTurkeyRecipe(
                _loggerMock.Object);
        }

        [Fact]
        public async Task CreateNewRecipeResponse()
        {
            // Arrange
            var mockInput = new TurkeyWeightInput()
            {
                TurkeyWeightInPounds = 20.0
            };

            byte[] byteArray = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(mockInput));
            MemoryStream memoryStream = new MemoryStream(byteArray);
            _httpRequestMock.Setup(r => r.Body).Returns(memoryStream);

            // Act
            var response = await _func.Run(_httpRequestMock.Object);

            // Assert
            Assert.Equal(typeof(OkObjectResult), response.GetType());
        }
    }
}
