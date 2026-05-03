using System.Text.Json.Serialization;

namespace _06_RapidApiHotelProject.Models.Dashboard
{
    public class CryptoDto
    {
        public class Rootobject
        {
            public int error { get; set; }
            public string message { get; set; }
            [JsonPropertyName("data")]
            public Data data { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("base")]
            public string _base { get; set; }
            public int total { get; set; }
            public DateTime updated_at { get; set; }
            public Token[] tokens { get; set; }
        }

        public class Token
        {
            public string symbol { get; set; }
            public string price { get; set; }
        }

    }
}
