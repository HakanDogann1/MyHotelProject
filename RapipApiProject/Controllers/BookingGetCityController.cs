using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using RapipApiProject.Models;
using System.Linq;

namespace RapipApiProject.Controllers
{
    public class BookingGetCityController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}%C3%BCk&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "f874e08470msh3574dfb2a70fff4p1e1129jsn1122a39cc826" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var Data = JsonConvert.DeserializeObject<List<BookingGetCityViewModel>>(body);
                    return View(Data.Take(1).ToList());
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=karabuk%C3%BCk&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "f874e08470msh3574dfb2a70fff4p1e1129jsn1122a39cc826" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var Data = JsonConvert.DeserializeObject<List<BookingGetCityViewModel>>(body);
                    return View(Data.Take(1).ToList());
                }
            }

        }
    }
}
