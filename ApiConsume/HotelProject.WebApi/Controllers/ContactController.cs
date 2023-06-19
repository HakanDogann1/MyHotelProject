using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.Booking;
using HotelProject.DtoLayer.Dtos.Contact;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }
        [HttpGet("GetContactCount")]
        public IActionResult GetContactCount()
        {
            var value = _contactService.TGetContactCount();
            return Ok(value);
        }
     
        [HttpPost]
        public IActionResult AddBooking(ResultContactDto resultContactDto)
        {
            var value = _mapper.Map<Contact>(resultContactDto);
            value.ContactDate=DateTime.Now.Date;
            _contactService.TAdd(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

       
    }
}
