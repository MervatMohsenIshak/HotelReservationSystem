using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Domain.Entities
{
    public class Room
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public int FloorNumber { get; set; }

        [Required]
        public int AdultNo { get; set; }

        [Required]
        public int ChildNo { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }

    }
}
