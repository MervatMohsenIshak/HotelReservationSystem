using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.API.Controllers.Reservation.BookRoom
{
    public class BookRoomRequest
    {
        public long RoomId { get; set; }
        public int BoardingTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
