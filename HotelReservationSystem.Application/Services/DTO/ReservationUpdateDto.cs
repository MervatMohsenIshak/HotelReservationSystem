namespace HotelReservationSystem.Application.Services.DTO
{
    public class ReservationUpdateDto
    {
        public string ReferenceNumber { get; set; }
        public int BoardingTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
