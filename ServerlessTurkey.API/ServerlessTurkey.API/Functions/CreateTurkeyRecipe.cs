using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServerlessTurkey.API.Models;
using ServerlessTurkey.API.Mappers;

namespace ServerlessTurkey.API.Functions
{
    public class CreateTurkeyRecipe
    {
        private readonly ILogger<CreateTurkeyRecipe> _logger;

        public CreateTurkeyRecipe(
            ILogger<CreateTurkeyRecipe> logger)
        {
            _logger = logger;
        }

        [FunctionName(nameof(CreateTurkeyRecipe))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "TurkeyRecipe")] HttpRequest req)
        {
            IActionResult actionResult = null;

            try
            {
                // Read the input
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                // Deserialize to our TurkeyWeightInput
                TurkeyWeightInput input = JsonConvert.DeserializeObject<TurkeyWeightInput>(requestBody);

                // Map the input weight to generate values for our recipe.
                TurkeyRecipeResponseDTO turkeyRecipeResponseDTO = TurkeyWeightMapper.GenerateTurkeyRecipe(input);

                // Return our DTO
                actionResult = new OkObjectResult(turkeyRecipeResponseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error. Exception thrown: {ex.Message}");
                actionResult = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return actionResult;
        }
    }
}
