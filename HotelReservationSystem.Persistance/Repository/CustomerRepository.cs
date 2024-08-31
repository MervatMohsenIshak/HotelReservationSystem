using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Domain.Entities;
using HotelReservationSystem.Persistence.DBContext;

namespace HotelReservationSystem.Persistence.Repository
{
    internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public Customer GetUserByUsername(string username)
        {
            return _context.Customer.SingleOrDefault(u => u.Name == username);
        }

        public Customer GetUserByEmail(string email)
        {
            return _context.Customer.SingleOrDefault(u => u.Email == email);
        }

    }
}
