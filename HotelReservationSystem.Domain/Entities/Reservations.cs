using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Domain.Entities
{
    public class Reservations
    {
        [Key]
        public long Id { get; set; }
        public string ReferenceNumber { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [Required]
        [ForeignKey("Room")]
        public long RoomId { get; set; }

        [Required]
        [ForeignKey("BoardingType")]
        public int BoardingTypeId { get; set; }

        [Required]
        [ForeignKey("ReservationStatus")]
        public int ReservationStatusId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public BoardingType BoardingType { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
    }
}
