using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Domain.Entities
{
    public class RoomTypeSpacifications
    {
        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        public int RoomSpacificationsId { get; set; }

        public RoomType RoomType { get; set; }
        public RoomSpacifications RoomSpacifications { get; set; }
    }
}
