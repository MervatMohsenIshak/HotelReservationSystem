using HotelReservationSystem.Application.Abstractions.Services;
using HotelReservationSystem.Application.Services;
using HotelReservationSystem.Application.Services.MappingDto;
using Microsoft.Extensions.DependencyInjection;

namespace HotelReservationSystem.Application
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddAutoMapper(typeof(AppMappingProfile));

            // Add other services similarly
            return services;
        }
    }
}
