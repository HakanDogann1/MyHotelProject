using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _SubscribeService;

        public SubscribeController(ISubscribeService SubscribeService)
        {
            _SubscribeService = SubscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _SubscribeService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _SubscribeService.TAdd(subscribe);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var value = _SubscribeService.TGetById(id);
            _SubscribeService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _SubscribeService.TUpdate(subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var value = _SubscribeService.TGetById(id);
            return Ok(value);
        }
    }
}
