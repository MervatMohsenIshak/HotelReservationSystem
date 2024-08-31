namespace HotelReservationSystem.Application.Services.Models
{
    public  class BookRoomDto
    {
        public Guid CustomerId { get; set; }
        public long RoomId { get; set; }
        public int BoardingTypeId { get; set; }
        public int ReservationStatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
