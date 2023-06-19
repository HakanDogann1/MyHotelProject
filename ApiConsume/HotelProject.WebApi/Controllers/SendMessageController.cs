using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;
        private readonly IMapper _mapper;

        public SendMessageController(ISendMessageService sendMessageService, IMapper mapper)
        {
            _sendMessageService = sendMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSendMessage(ResultSendMessageDto sendMessage)
        {
            var value = _mapper.Map<SendMessage>(sendMessage);
            _sendMessageService.TAdd(value);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var value = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(value);
            return Ok();
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            var value = _sendMessageService.TGetSendMessageCount();
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(UpdateSendMessageDto sendMessage)
        {
            var value = _mapper.Map<SendMessage>(sendMessage);
            _sendMessageService.TUpdate(value);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _sendMessageService.TGetById(id);
            return Ok(value);
        }
    }
}
