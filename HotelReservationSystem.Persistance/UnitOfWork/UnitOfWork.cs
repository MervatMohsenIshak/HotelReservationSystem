using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Domain.Abstractions.UnitOfWork;
using HotelReservationSystem.Persistence.DBContext;
using HotelReservationSystem.Persistence.Repository;

namespace HotelReservationSystem.Persistence.UnitOfWork
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ICustomerRepository _customerRepository;
        private IRoomRepository _roomRepository;
        private IReservationsRepository _reservationsRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customers
        {
            get
            {
                return _customerRepository ??= new CustomerRepository(_context);
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                return _roomRepository ??= new RoomRepository(_context);
            }
        }

        public IReservationsRepository Reservations
        {
            get
            {
                return _reservationsRepository ??= new ReservationsRepository(_context);
            }
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(); ;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
