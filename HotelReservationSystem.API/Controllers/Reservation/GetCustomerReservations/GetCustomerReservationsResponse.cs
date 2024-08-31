﻿namespace HotelReservationSystem.API.Controllers.Reservation.GetCustomerReservations
{
    public class GetCustomerReservationsResponse
    {
        public string ReservationReferenceNumber { get; set; }
        public string RoomNumber { get; set; }
        public string BoardingType { get; set; }
        public string ReservationStatus { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
