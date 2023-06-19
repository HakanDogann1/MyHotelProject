using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _ServiceService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _ServiceService.TAdd(service);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var value = _ServiceService.TGetById(id);
            _ServiceService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _ServiceService.TUpdate(service);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var value = _ServiceService.TGetById(id);
            return Ok(value);
        }
    }
}
