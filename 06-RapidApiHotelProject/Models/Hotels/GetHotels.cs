namespace _06_RapidApiHotelProject.Models.Hotels
{
    public class GetHotels
    {
        public class Rootobject
        {
            public bool status { get; set; }
            public long timestamp { get; set; }
            public object message { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public Hotel[] hotels { get; set; }
        }

        public class Hotel
        {
            public string accessibilityLabel { get; set; }
            public int hotel_id { get; set; }
            public Property1 property { get; set; }
        }

        public class Property1
        {
            public Pricebreakdown priceBreakdown { get; set; }
            public int accuratePropertyClass { get; set; } //yıldız sayısı
            public string countryCode { get; set; } //ülke 
            public string name { get; set; } //otel adı
            public string reviewScoreWord { get; set; } //sözlü puan(muhteşem vs.)
            public string wishlistName { get; set; } //şehir adı
            public string[] photoUrls { get; set; } //kapak fotoğrafı
            public float reviewScore { get; set; } //puan
            public int reviewCount { get; set; } //yorum sayısı
        }

        public class Pricebreakdown
        {
            public Benefitbadge[] benefitBadges { get; set; }
            public Grossprice grossPrice { get; set; }
        }

        public class Grossprice
        {
            public string currency { get; set; } // para birimi
            public float value { get; set; } //gecelik fiyat
        }

        public class Benefitbadge
        {
            public string text { get; set; } //rozetler
        }

    }
}