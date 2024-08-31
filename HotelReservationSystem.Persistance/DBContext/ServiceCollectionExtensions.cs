using HotelReservationSystem.Application.Abstractions;
using HotelReservationSystem.Domain.Abstractions.Repository;
using HotelReservationSystem.Domain.Abstractions.UnitOfWork;
using HotelReservationSystem.Persistence.Authentication;
using HotelReservationSystem.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _unitOfWork = HotelReservationSystem.Persistence.UnitOfWork.UnitOfWork;
namespace HotelReservationSystem.Persistence.DBContext
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)); // or UseSqlite, etc.

           // services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddScoped<IUnitOfWork, _unitOfWork>();

            //repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationsRepository, ReservationsRepository>();

            return services;
        }


    }
}
