using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Application.Services.DTO
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
