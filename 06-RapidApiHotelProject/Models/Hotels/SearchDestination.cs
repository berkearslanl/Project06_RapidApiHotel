namespace _06_RapidApiHotelProject.Models.Hotels
{
    public class SearchDestination
    {
        public class Rootobject
        {
            public bool status { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string dest_id { get; set; }
            public string search_type { get; set; }
            public int hotels { get; set; }
            public string city_name { get; set; }
            public string name { get; set; }
            public string dest_type { get; set; }
            public string country { get; set; }
        }

    }
}
