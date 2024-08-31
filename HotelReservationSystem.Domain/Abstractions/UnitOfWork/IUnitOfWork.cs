using HotelReservationSystem.Domain.Abstractions.Repository;

namespace HotelReservationSystem.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IRoomRepository Rooms { get; }
        IReservationsRepository Reservations { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
