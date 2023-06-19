using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _RoomService;

        public RoomController(IRoomService RoomService)
        {
            _RoomService = RoomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _RoomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRoom(Room room)
        {
            _RoomService.TAdd(room);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var value = _RoomService.TGetById(id);
            _RoomService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(Room room)
        {
            _RoomService.TUpdate(room);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRoom(int id)
        {
            var value = _RoomService.TGetById(id);
            return Ok(value);
        }
    }
}
