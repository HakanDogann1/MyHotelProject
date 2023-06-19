using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4StaffPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:61156/api/DashboardStaff/GetLast4StaffList");
            if(responseMessage.IsSuccessStatusCode)
            {
                var JsonData=await responseMessage.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<StaffViewModel>>(JsonData);
                return View(Data);
            }
            return View();
        }
    }
}
