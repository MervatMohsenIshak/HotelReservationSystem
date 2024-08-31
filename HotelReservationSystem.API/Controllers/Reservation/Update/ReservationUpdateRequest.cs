namespace HotelReservationSystem.API.Controllers.Reservation.Update
{
    public class ReservationUpdateRequest
    {
        public string ReferenceNumber { get; set; }
        public int BoardingTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
