namespace _06_RapidApiHotelProject.Models.Dashboard
{
    public class WeatherDto
    {
        public WeatherLocation location { get; set; }
        public WeatherCurrent current { get; set; }
    }

    public class WeatherLocation
    {
        public string name { get; set; }
        public string country { get; set; }
    }

    public class WeatherCurrent
    {
        public double temp_c { get; set; }
        public WeatherCondition condition { get; set; }
    }

    public class WeatherCondition
    {
        public string text { get; set; }
        public string icon { get; set; }
    }

}
