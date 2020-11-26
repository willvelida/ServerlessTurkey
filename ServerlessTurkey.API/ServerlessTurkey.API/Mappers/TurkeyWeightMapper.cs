using ServerlessTurkey.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessTurkey.API.Mappers
{
    public static class TurkeyWeightMapper
    {
        /// <summary>
        /// Generates a recipe for turkey based on the provided weight in pounds.
        /// </summary>
        /// <param name="turkeyWeightInput"></param>
        /// <returns></returns>
        public static TurkeyRecipeResponseDTO GenerateTurkeyRecipe(TurkeyWeightInput turkeyWeightInput)
        {
            return new TurkeyRecipeResponseDTO()
            {
                SaltCups = 0.05 * turkeyWeightInput.TurkeyWeightInPounds,
                WaterInGallons = Math.Round(0.66 * turkeyWeightInput.TurkeyWeightInPounds, 2),
                BrownSugarCups = Convert.ToInt32(0.13 * turkeyWeightInput.TurkeyWeightInPounds),
                Shallots = Convert.ToInt32(0.2 * turkeyWeightInput.TurkeyWeightInPounds),
                ClovesOfGarlic = Convert.ToInt32(0.4 * turkeyWeightInput.TurkeyWeightInPounds),
                WholePeppercorns = Convert.ToInt32(0.13 * turkeyWeightInput.TurkeyWeightInPounds),
                DriedJuniperBerries = Convert.ToInt32(0.13 * turkeyWeightInput.TurkeyWeightInPounds),
                FreshRosemary = Convert.ToInt32(0.13 * turkeyWeightInput.TurkeyWeightInPounds),
                Thyme = Convert.ToInt32(0.06 * turkeyWeightInput.TurkeyWeightInPounds),
                BrineTime = 2.4 * turkeyWeightInput.TurkeyWeightInPounds,
                RoastTime = 15 * turkeyWeightInput.TurkeyWeightInPounds
            };
        }
    }
}
