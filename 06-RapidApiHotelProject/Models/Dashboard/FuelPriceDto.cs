namespace _06_RapidApiHotelProject.Models.Dashboard
{
    public class FuelPriceDto
    {
        public bool success { get; set; }
        public FuelData data { get; set; }

        public class FuelData
        {
            public string state { get; set; }
            public string stateName { get; set; }
            public FuelType regular { get; set; }
            public FuelType midGrade { get; set; }
            public FuelType premium { get; set; }
            public FuelType diesel { get; set; }
        }

        public class FuelType
        {
            public float current { get; set; }
        }
    }
}
