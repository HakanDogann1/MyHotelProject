using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.Booking;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(ResultBookingDto resultBookingDto)
        {
            var value = _mapper.Map<Booking>(resultBookingDto);
            _bookingService.TAdd(value);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("UpdateReservetion")]
        public IActionResult UpdateReservetion(Booking booking)
        {
            _bookingService.TBookingStatusApproved(booking);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateReservetion2(int id)
        {
            _bookingService.TBookingStatusApproved2(id);
            return Ok();
        }
        [HttpPut("UpdateReservetion3")]
        public IActionResult UpdateReservetion3(int id)
        {
            _bookingService.TBookingStatusApproved3(id);
            return Ok();
        }
        [HttpPut("UpdateReservetion4")]
        public IActionResult UpdateReservetion4(int id)
        {
            _bookingService.TBookingStatusApproved4(id);
            return Ok();
        }
    }
}
