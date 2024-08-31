using AutoMapper;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Application.Services.Models;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Application.Services.MappingDto
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Customer,CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<BookRoomDto, Reservations>();
            CreateMap<ReservationUpdateDto, Reservations>();
            CreateMap<Reservations, GetCustomerReservationDetailsDto>()
                .ForMember(s => s.ReservationReferenceNumber, o => o.MapFrom(d => d.ReferenceNumber))
                .ForMember(s => s.RoomNumber, o => o.MapFrom(d => d.Room.RoomNumber))
                .ForMember(s => s.BoardingType, o => o.MapFrom(d => d.BoardingType.Name))
                .ForMember(s => s.ReservationStatus, o => o.MapFrom(d => d.ReservationStatus.Name))
                .ForMember(s => s.CustomerName, o => o.MapFrom(d => d.Customer.Name))
                .ForMember(s => s.StartDate, o => o.MapFrom(d => d.StartDate))
                .ForMember(s => s.EndDate, o => o.MapFrom(d => d.EndDate));

        }
    }
}
