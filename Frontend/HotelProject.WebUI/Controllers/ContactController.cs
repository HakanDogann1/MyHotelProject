using HotelProject.WebUI.Models.Booking;
using HotelProject.WebUI.Models.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(AddContactViewModel addContactViewModel)
        {
            addContactViewModel.ContactDate=DateTime.Now.Date;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addContactViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:61156/api/Contact", stringContent);
            return RedirectToAction("Index", "Default");
        }
    }
}
