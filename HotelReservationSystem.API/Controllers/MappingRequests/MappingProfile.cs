using AutoMapper;
using HotelReservationSystem.API.Controllers.Customers.Register;
using HotelReservationSystem.API.Controllers.Reservation.BookRoom;
using HotelReservationSystem.API.Controllers.Reservation.GetCustomerReservations;
using HotelReservationSystem.API.Controllers.Reservation.Update;
using HotelReservationSystem.Application.Enum;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Application.Services.Models;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.API.Controllers.MappingRequests
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookRoomRequest, BookRoomDto>();
            CreateMap<ReservationUpdateRequest, ReservationUpdateDto>();
            CreateMap<Reservations, GetCustomerReservationsResponse>()
                .ForMember(d=> d.ReservationStatus, o=> o.MapFrom(s=> Enum.GetName(typeof(ReservationStatusEnum), s.ReservationStatusId)));
            CreateMap<CustomerModel, CustomerDto>();
            CreateMap<CustomerDto, CustomerModel>();
            CreateMap<GetCustomerReservationDetailsDto, GetCustomerReservationsResponse>();

        }
    }
}
