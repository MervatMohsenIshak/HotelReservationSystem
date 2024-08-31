using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.API.Controllers.Customers.Register
{
    public class CustomerModel 
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
