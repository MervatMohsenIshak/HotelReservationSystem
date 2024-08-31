using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Domain.Entities;
using HotelReservationSystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Persistence.Repository
{
    internal class RoomRepository: BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context) { }

        public async Task<Room> GetByIdAsync(long roomId)
        {
            return await _context.Room.SingleOrDefaultAsync(r => r.Id == roomId);
        }
    }
}
