using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Domain.Entities._Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
