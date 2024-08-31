using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Application.Services.Models;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Application.Abstractions.Services
{
    public interface IReservationService
    {
        Task<Reservations> BookRoom(BookRoomDto reservation, CancellationToken cancellation);
        Task<bool> UpdateReservation(ReservationUpdateDto reservationDto, Guid customerId, CancellationToken cancellationToken);
        Task<bool> DeleteReservation(string referenceNumber, Guid customerId, CancellationToken cancellationToken);
        Task<IEnumerable<GetCustomerReservationDetailsDto>> GetReservationsByCustomerId(Guid customerId, CancellationToken cancellationToken);
    }
}
