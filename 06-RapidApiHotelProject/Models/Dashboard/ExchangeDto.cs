namespace _06_RapidApiHotelProject.Models.Dashboard
{
    public class ExchangeDto
    {
        public string _base { get; set; }
        public Rates rates { get; set; }
        public Time_Update time_update { get; set; }


        public class Rates
        {
            public int TRY { get; set; }
            public float EUR { get; set; }
            public float GBP { get; set; }
            public float JPY { get; set; }
            public float USD { get; set; }
        }

        public class Time_Update
        {
            public DateTime time_utc { get; set; }
            public string time_zone { get; set; }
        }

    }
}
