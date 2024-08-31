using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Domain.Abstractions.Repository
{
    public interface IReservationsRepository : IBaseRepository<Reservations>
    {
        Task<Reservations> GetByRefNumberAndCustomerIdAsync(string referenceNumber, Guid customerId);
        Task<IEnumerable<Reservations>> GetReservationsByCustomerIdAsync(Guid customerId);
        Task<IEnumerable<Reservations>> GetReservationByRoomId(long roomId);
    }
}
