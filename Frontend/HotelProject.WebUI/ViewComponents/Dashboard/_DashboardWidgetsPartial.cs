using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetsPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:61156/api/DashboardWidgets/GetStaffCount");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:61156/api/DashboardWidgets/GetBookingCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:61156/api/DashboardWidgets/GetGuestCount");

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:61156/api/DashboardWidgets/GetRoomCount");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2=await responseMessage2.Content.ReadAsStringAsync();
                var jsonData3=await responseMessage3.Content.ReadAsStringAsync();
                var jsonData4=await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.staffCount = jsonData;
                ViewBag.staffCount2 = jsonData2;
                ViewBag.staffCount3 = jsonData3;
                ViewBag.staffCount4 = jsonData4;
            }
            return View();
        }
    }
}
