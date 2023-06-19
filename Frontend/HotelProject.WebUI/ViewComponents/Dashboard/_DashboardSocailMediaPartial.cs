using HotelProject.WebUI.Models.RapidApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocailMediaPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardSocailMediaPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
                ViewBag.follower = Data.followers;
                ViewBag.following = Data.following;
                return View();
            }
        }
    }
}
