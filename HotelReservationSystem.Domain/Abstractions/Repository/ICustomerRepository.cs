using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Domain.Abstractions.Repository
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        Customer GetUserByUsername(string username);
        Customer GetUserByEmail(string email);
    }
}
