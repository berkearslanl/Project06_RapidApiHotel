namespace _06_RapidApiHotelProject.Models.Hotels
{
    public class GetHotelDetail
    {
        public class Rootobject
        {
            public bool status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public int hotel_id { get; set; }
            public string hotel_name { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string countrycode { get; set; }
            public string arrival_date { get; set; }
            public string departure_date { get; set; }
            public string description { get; set; }
            public int review_nr { get; set; }
            public int available_rooms { get; set; }
            public int hotel_include_breakfast { get; set; }
            public Facilities_Block facilities_block { get; set; }
            public Product_Price_Breakdown product_price_breakdown { get; set; }

            public Top_Ufi_Benefit[] top_ufi_benefits { get; set; }
        }
        public class Top_Ufi_Benefit
        {
            public string translated_name { get; set; }
            public string icon { get; set; }
        }

        public class Facilities_Block
        {
            public string name { get; set; }
            public Facility[] facilities { get; set; }
        }

        public class Facility
        {
            public string name { get; set; }
            public string icon { get; set; }
        }

        public class Product_Price_Breakdown
        {
            public Gross_Amount_Per_Night gross_amount_per_night { get; set; }
            public Gross_Amount gross_amount { get; set; }
        }

        public class Gross_Amount_Per_Night
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

    }
}