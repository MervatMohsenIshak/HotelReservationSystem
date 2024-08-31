using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Application.Abstractions
{
    public interface IJwtProvider
    {
        string GenerateToken(Customer user);
    }
}
