using AutoMapper;
using HotelReservationSystem.Application.Abstractions;
using HotelReservationSystem.Application.Abstractions.Services;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Domain.Abstractions.UnitOfWork;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Application.Services
{
    internal class CustomerService: ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }

        public async Task<bool> CreateCustomer(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            Customer customer = _mapper.Map<Customer>(customerDto);

            await _unitOfWork.Customers.AddAsync(customer);
            int affectedRows = await _unitOfWork.CommitAsync(cancellationToken);

            return affectedRows > 0;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            IEnumerable<Customer> customerList = await _unitOfWork.Customers.GetAll();
            return _mapper.Map<IEnumerable<CustomerDto>>(customerList);
        }

        public async Task<string> Login(string email, CancellationToken cancellationToken)
        {
            Customer customer = _unitOfWork.Customers.GetUserByEmail(email);
            if (customer == null)
            {
                throw new KeyNotFoundException("this User not exist");
            }
            string token = _jwtProvider.GenerateToken(customer);
            return token;
        }
    }
}
