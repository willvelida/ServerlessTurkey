using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessTurkey.API.Models
{
    public class TurkeyRecipeResponseDTO
    {
        public double SaltCups { get; set; }
        public double WaterInGallons { get; set; }
        public int BrownSugarCups { get; set; }
        public int Shallots { get; set; }
        public int ClovesOfGarlic { get; set; }
        public int WholePeppercorns { get; set; }
        public int DriedJuniperBerries { get; set; }
        public int FreshRosemary { get; set; }
        public int Thyme { get; set; }
        public double BrineTime { get; set; }
        public double RoastTime { get; set; }
    }
}
