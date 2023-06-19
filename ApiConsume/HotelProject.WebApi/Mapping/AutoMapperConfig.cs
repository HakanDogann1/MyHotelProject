using AutoMapper;
using HotelProject.DtoLayer.Dtos.AboutDtos;
using HotelProject.DtoLayer.Dtos.Booking;
using HotelProject.DtoLayer.Dtos.Contact;
using HotelProject.DtoLayer.Dtos.GuestDtos;
using HotelProject.DtoLayer.Dtos.RoomDtos;
using HotelProject.DtoLayer.Dtos.SendMessageDtos;
using HotelProject.EntityLayer;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto,Room>().ReverseMap();
            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();

            CreateMap<ResultBookingDto,Booking>().ReverseMap();
            CreateMap<UpdateBookingDto,Booking>().ReverseMap();

            CreateMap<ResultContactDto,Contact>().ReverseMap();
            CreateMap<UpdateContactDto,Contact>().ReverseMap();

            CreateMap<ResultGuestDto,Guest>().ReverseMap();
            CreateMap<UpdateGuestDto,Guest>().ReverseMap();

            CreateMap<ResultSendMessageDto,SendMessage>().ReverseMap();
            CreateMap<UpdateSendMessageDto,SendMessage>().ReverseMap();
        }
    }
}
