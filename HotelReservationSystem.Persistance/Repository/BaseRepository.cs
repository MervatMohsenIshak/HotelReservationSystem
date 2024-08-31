using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HotelReservationSystem.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public bool Update(T entity)
        {
            EntityEntry<T> updatedentity = _context.Set<T>().Update(entity);
           // _context.Update(entity).State = EntityState.Modified;
           return updatedentity != null;
        }

        public bool Delete(T entity)
        {
            EntityState status = _context.Set<T>().Remove(entity).State;
            return status == EntityState.Deleted;
        }       
    }

}
