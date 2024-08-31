using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Domain.Entities;
using HotelReservationSystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelReservationSystem.Persistence.Repository
{
    public class ReservationsRepository : BaseRepository<Reservations>, IReservationsRepository
    {
        public ReservationsRepository(AppDbContext context) : base(context) { }

        public async Task<Reservations> GetByRefNumberAndCustomerIdAsync(string referenceNumber, Guid customerId)
        {
            return await _context.Reservation.SingleOrDefaultAsync(r => r.ReferenceNumber == referenceNumber && r.CustomerId == customerId);
        }

        public async Task<IEnumerable<Reservations>> GetReservationsByCustomerIdAsync(Guid customerId)
        {
            return _context.Reservation.Where(r => r.CustomerId == customerId)
                                       .Include(x => x.Customer)
                                       .Include(s => s.Room)
                                       .Include(s => s.ReservationStatus)
                                       .Include(s => s.BoardingType);
        }

        public async Task<IEnumerable<Reservations>> GetReservationByRoomId(long roomId)
        {
            return  _context.Reservation.Join(_context.Room,
                                             reservation => reservation.RoomId,
                                             room => room.Id,
                                             (reservation, room) => new Reservations
                                             {
                                                 Id = reservation.Id,
                                                 RoomId = reservation.RoomId,
                                                 StartDate = reservation.StartDate,
                                                 EndDate = reservation.EndDate,
                                                 ReservationStatus = reservation.ReservationStatus
                                             }).Where(x => x.RoomId == roomId);
        }
    }
}
