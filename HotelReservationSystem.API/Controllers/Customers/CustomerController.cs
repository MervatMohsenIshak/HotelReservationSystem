using AutoMapper;
using HotelReservationSystem.API.Controllers.Customers.Register;
using HotelReservationSystem.Application.Abstractions.Services;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.API.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register([FromBody] CustomerModel customer, CancellationToken cancellationToken)
        {
            CustomerDto customerCreateDto = _mapper.Map<CustomerDto>(customer);
            bool isAdded = await _customerService.CreateCustomer(customerCreateDto, cancellationToken);

            if (isAdded)
                return Ok();
            else
                return UnprocessableEntity();

        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] string Email, CancellationToken cancellation)
        {
            string token = await _customerService.Login(Email, cancellation);
            return Ok(token);
        }

        [HttpGet, Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CustomerDto> customers = await _customerService.GetAllCustomers();
            if (customers.Any())
            {
                IEnumerable<CustomerModel> customersModel = _mapper.Map<IEnumerable<CustomerModel>>(customers);
                return Ok(customersModel);
            }
            else
                return NotFound();
            
        }
    }
}
