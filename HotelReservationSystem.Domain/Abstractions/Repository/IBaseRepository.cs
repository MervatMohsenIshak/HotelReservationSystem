using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HotelReservationSystem.Domain.Abstractions.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        // IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
