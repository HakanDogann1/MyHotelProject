using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var values = _roomService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRomm(RoomAddDto roomAddDto)
        {
            if(ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var values = _mapper.Map<Room>(roomAddDto);
                _roomService.TAdd(values);
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateRoom(UpdateRoomDto roomUpdateDto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var values = _mapper.Map<Room>(roomUpdateDto);
                _roomService.TUpdate(values);
                return Ok();
            }
        }
    }
}
