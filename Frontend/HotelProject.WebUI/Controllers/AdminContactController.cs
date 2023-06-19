using HotelProject.WebUI.Models.Contact;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:61156/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:61156/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:61156/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<InboxContactViewModel>>(jsonData);
                
                if (responseMessage2.IsSuccessStatusCode)
                {
                    var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                    ViewBag.InboxCount = jsonData2;
                    ViewData["InboxCount"] = jsonData2;

                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                        ViewBag.sendMessageCount = jsonData3;
                        ViewData["sendMessageCount"] = jsonData3;
                    }
                        return View(Data);
                }
                return View();
               
            }
            return View();
        }
       
        [HttpGet]
        public IActionResult AddSendBox()
        {
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendBox(SendMessageViewModel model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "Admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:61156/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AddSendBox");
            }
            return View();
        }
        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:61156/api/SendMessage");

           
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<SendboxListViewModel>>(jsonData);
                return View(Data);
              
            }
            return View();
        }
        public async Task<IActionResult> MessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:61156/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<SendMessageDetailViewModel>(jsonData);
                return View(Data);
            }
            return View();
        }
        public async Task<IActionResult> InMessageDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:61156/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<InboxMessageDetailViewModel>(jsonData);
                return View(Data);
            }
            return View();
        }
        //public async Task<IActionResult> GetContactCount()
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:61156/api/Contact/GetContactCount");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var Data = JsonConvert.DeserializeObject<List<InboxContactViewModel>>(jsonData);
        //        return View(Data);
        //    }
        //    return View();
        //}
    }
}
