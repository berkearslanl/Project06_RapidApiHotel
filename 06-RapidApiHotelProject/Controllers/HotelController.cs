using _06_RapidApiHotelProject.Models.Hotels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _06_RapidApiHotelProject.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HotelController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> HotelList()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-782831&search_type=CITY&arrival_date=2026-04-29&departure_date=2026-05-01&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=EUR&location=US"),
                Headers =
    {
        { "x-rapidapi-key", _configuration["RapidApi2:ApiKey2"] },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var hotels = JsonSerializer.Deserialize<GetHotels.Rootobject>(body);
                ViewBag.Hotels = hotels;
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> HotelList(string city, string checkIn, string checkOut, int adults, string currency, string language, int minPrice, int maxPrice)
        {
            //destination id alma
            var apiKey = "bd4e3ecea8msh0ffa3afe552a2f7p104adajsnc2ffdf07dc7c";
            var host = "booking-com15.p.rapidapi.com";

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            client.DefaultRequestHeaders.Add("x-rapidapi-host", host);

            var destRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://{host}/api/v1/hotels/searchDestination?query={city}")
            };

            string destId = "";
            using (var destResponse = await client.SendAsync(destRequest))
            {
                destResponse.EnsureSuccessStatusCode();
                var destBody = await destResponse.Content.ReadAsStringAsync();
                var destination = JsonSerializer.Deserialize<SearchDestination.Rootobject>(destBody);
                destId = destination?.data?.FirstOrDefault()?.dest_id;
            }

            //otel listeleme

            var client2 = _httpClientFactory.CreateClient();
            client2.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);
            client2.DefaultRequestHeaders.Add("x-rapidapi-host", host);

            var priceParams = (minPrice > 0 || maxPrice > 0)
                ? $"&price_min={minPrice}&price_max={maxPrice}"
                : "";

            var hotelRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://{host}/api/v1/hotels/searchHotels?dest_id={destId}&search_type=CITY&arrival_date={checkIn}&departure_date={checkOut}&adults={adults}&children_age=0%2C17&room_qty=1&page_number=1{priceParams}&units=metric&temperature_unit=c&languagecode={language}&currency_code={currency}")
            };
            using (var hotelResponse = await client2.SendAsync(hotelRequest))
            {
                hotelResponse.EnsureSuccessStatusCode();
                var hotelBody = await hotelResponse.Content.ReadAsStringAsync();
                var hotels = JsonSerializer.Deserialize<GetHotels.Rootobject>(hotelBody);
                ViewBag.Hotels = hotels;
            }
            ViewBag.City = city;
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            ViewBag.Currency = currency;
            ViewBag.Adults = adults;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> HotelDetail(int id, string checkIn, string checkOut, string currency, float reviewScore, string reviewScoreWord, int adults)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelDetails?hotel_id={id}&arrival_date={checkIn}&departure_date={checkOut}&adults=1&children_age=1%2C17&room_qty=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code={currency}"),
                Headers =
    {
        { "x-rapidapi-key", _configuration["RapidApi2:ApiKey2"] },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var hotelDetail = JsonSerializer.Deserialize<GetHotelDetail.Rootobject>(body);
                ViewBag.HotelDetail = hotelDetail;
            }
            ViewBag.CheckIn = checkIn;
            ViewBag.CheckOut = checkOut;
            ViewBag.Currency = currency;
            ViewBag.ReviewScore = reviewScore;
            ViewBag.ReviewScoreWord = reviewScoreWord;
            ViewBag.Adults = adults;

            #region Gallery Endpoint

            var photoClient = _httpClientFactory.CreateClient();
            var photoRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/getHotelPhotos?hotel_id={id}"),
                Headers =
    {
        { "x-rapidapi-key", _configuration["RapidApi2:ApiKey2"] },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var photoResponse = await photoClient.SendAsync(photoRequest))
            {
                photoResponse.EnsureSuccessStatusCode();
                var photoBody = await photoResponse.Content.ReadAsStringAsync();
                var photos = JsonSerializer.Deserialize<GetHotelDetailPhotos.Rootobject>(photoBody);
                ViewBag.Photos = photos?.data?.Take(5).ToList();
            }

            #endregion

            return View();
        }
    }
}