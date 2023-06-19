using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RapipApiProject.Models;

namespace RapipApiProject.Controllers
{
    public class InstagramController : Controller
    {
        public async Task<IActionResult> Index(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/dgn.hakan78"),
                    Headers =
    {
        { "X-RapidAPI-Key", "f874e08470msh3574dfb2a70fff4p1e1129jsn1122a39cc826" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var Data = JsonConvert.DeserializeObject<InstagramViewModel>(body);
                    return View(Data);
                }
            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://instagram-profile1.p.rapidapi.com/getprofile/{userName}"),
                    Headers =
    {
        { "X-RapidAPI-Key", "f874e08470msh3574dfb2a70fff4p1e1129jsn1122a39cc826" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var Data = JsonConvert.DeserializeObject<InstagramViewModel>(body);
                    return View(Data);
                }
            }

           
        }
    }
}
