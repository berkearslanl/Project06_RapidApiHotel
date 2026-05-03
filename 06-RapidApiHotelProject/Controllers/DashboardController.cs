using _06_RapidApiHotelProject.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _06_RapidApiHotelProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public DashboardController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            #region Hava Durumu
            try
            {
                var client = _httpClientFactory.CreateClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=Dubai"),
                    Headers =
                    {
                        { "x-rapidapi-key", _configuration["RapidApi:ApiKey"] },
                        { "x-rapidapi-host", "weatherapi-com.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    ViewBag.Weather = JsonSerializer.Deserialize<WeatherDto>(body);
                }
            }
            catch { ViewBag.Weather = null; }
            #endregion

            #region Döviz Kurları
            try
            {
                var client2 = _httpClientFactory.CreateClient();
                var request2 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://exchange-rates7.p.rapidapi.com/latest?base=TRY"),
                    Headers =
                    {
                        { "x-rapidapi-key", _configuration["RapidApi:ApiKey"] },
                        { "x-rapidapi-host", "exchange-rates7.p.rapidapi.com" },
                    },
                };
                using (var response2 = await client2.SendAsync(request2))
                {
                    response2.EnsureSuccessStatusCode();
                    var body2 = await response2.Content.ReadAsStringAsync();
                    ViewBag.Exchange = JsonSerializer.Deserialize<ExchangeDto>(body2);
                }
            }
            catch { ViewBag.Exchange = null; }
            #endregion

            #region Yakıt Fiyatları
            try
            {
                var client3 = _httpClientFactory.CreateClient();
                var request3 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://fuel-gas-price-api.p.rapidapi.com/state/NY"),
                    Headers =
                    {
                        { "x-rapidapi-key", _configuration["RapidApi:ApiKey"] },
                        { "x-rapidapi-host", "fuel-gas-price-api.p.rapidapi.com" },
                    },
                };
                using (var response3 = await client3.SendAsync(request3))
                {
                    response3.EnsureSuccessStatusCode();
                    var body3 = await response3.Content.ReadAsStringAsync();
                    var options3 = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    ViewBag.Fuel = JsonSerializer.Deserialize<FuelPriceDto>(body3, options3);
                }
            }
            catch { ViewBag.Fuel = null; }
            #endregion

            #region Kripto Paralar
            try
            {
                var client4 = _httpClientFactory.CreateClient();
                var request4 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://crypto-market-prices.p.rapidapi.com/tokens?base=TRY"),
                    Headers =
                    {
                        { "x-rapidapi-key", _configuration["RapidApi:ApiKey"] },
                        { "x-rapidapi-host", "crypto-market-prices.p.rapidapi.com" },
                    },
                };
                using (var response4 = await client4.SendAsync(request4))
                {
                    response4.EnsureSuccessStatusCode();
                    var body4 = await response4.Content.ReadAsStringAsync();
                    ViewBag.Crypto = JsonSerializer.Deserialize<CryptoDto.Rootobject>(body4);
                }
            }
            catch { ViewBag.Crypto = null; }
            #endregion

            #region Haber Başlıkları
            try
            {
                var client5 = _httpClientFactory.CreateClient();
                var request5 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://real-time-news-data.p.rapidapi.com/top-headlines?limit=500&country=US&lang=en"),
                    Headers =
                    {
                        { "x-rapidapi-key", _configuration["RapidApi:ApiKey"] },
                        { "x-rapidapi-host", "real-time-news-data.p.rapidapi.com" },
                    },
                };
                using (var response5 = await client5.SendAsync(request5))
                {
                    response5.EnsureSuccessStatusCode();
                    var body5 = await response5.Content.ReadAsStringAsync();
                    ViewBag.News = JsonSerializer.Deserialize<NewsDto.Rootobject>(body5);
                }
            }
            catch { ViewBag.News = null; }
            #endregion

            #region Günün Yemeği
            try
            {
                var client6 = _httpClientFactory.CreateClient();
                var request6 = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://www.themealdb.com/api/json/v1/1/random.php"),
                };
                using (var response6 = await client6.SendAsync(request6))
                {
                    response6.EnsureSuccessStatusCode();
                    var body6 = await response6.Content.ReadAsStringAsync();
                    ViewBag.Meal = JsonSerializer.Deserialize<MealDto>(body6);
                }
            }
            catch { ViewBag.Meal = null; }
            #endregion

            return View();
        }
    }
}
