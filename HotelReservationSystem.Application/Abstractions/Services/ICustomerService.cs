using HotelReservationSystem.Application.Services.DTO;

namespace HotelReservationSystem.Application.Abstractions.Services
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(CustomerDto Customer, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task<string> Login(string email, CancellationToken cancellationToken);
    }
}
