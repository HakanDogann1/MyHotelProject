using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _GuestService;
        private readonly IMapper _Mapper;

        public GuestController(IGuestService guestService, IMapper mapper)
        {
            _GuestService = guestService;
            _Mapper = mapper;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _GuestService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest(ResultGuestDto resultGuestDto)
        {
            var value = _Mapper.Map<Guest>(resultGuestDto);
            _GuestService.TAdd(value);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var value = _GuestService.TGetById(id);
            _GuestService.TDelete(value);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(UpdateGuestDto updateGuestDto)
        {
            var value = _Mapper.Map<Guest>(updateGuestDto);
            _GuestService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var value = _GuestService.TGetById(id);
            return Ok(value);
        }
    }
}
