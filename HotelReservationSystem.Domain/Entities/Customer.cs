using HotelReservationSystem.Domain.Entities._Base;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HotelReservationSystem.Domain.Entities
{
    public class Customer: BaseEntity
    {
        [Key]
        public new Guid Id { get; set; }

        [Required]
        [MaxLength(255), EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
