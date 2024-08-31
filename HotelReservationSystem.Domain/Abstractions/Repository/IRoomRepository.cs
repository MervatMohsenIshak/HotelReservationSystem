using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Domain.Abstractions.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetByIdAsync(long roomId);
    }
}
