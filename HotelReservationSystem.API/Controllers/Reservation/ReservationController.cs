using AutoMapper;
using Azure.Core;
using HotelReservationSystem.API.Controllers.Reservation.BookRoom;
using HotelReservationSystem.API.Controllers.Reservation.GetCustomerReservations;
using HotelReservationSystem.API.Controllers.Reservation.Update;
using HotelReservationSystem.Application.Abstractions.Services;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Application.Services.Models;
using HotelReservationSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelReservationSystem.API.Controllers.Reservation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }


        [HttpPost, Route("room")]
        [Authorize]
        public async Task<IActionResult> BookRoom([FromBody] BookRoomRequest request, CancellationToken cancellationToken)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null || request == null)
                return BadRequest();
            try
            {
                BookRoomDto reservation = _mapper.Map<BookRoomDto>(request);
                reservation.CustomerId = Guid.Parse(userId);

                Reservations result = await _reservationService.BookRoom(reservation, cancellationToken);

                if (result == null)
                    return UnprocessableEntity("This Room not available at this time.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }

        }


        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationUpdateRequest request, CancellationToken cancellationToken)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null || request == null)
                return BadRequest();
            try
            {
                ReservationUpdateDto reservation = _mapper.Map<ReservationUpdateDto>(request);
                bool isUpdate = await _reservationService.UpdateReservation(reservation, Guid.Parse(userId), cancellationToken);

                if (isUpdate)
                    return Ok();
                else
                    return UnprocessableEntity();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }

        }

        [HttpPost, Route("delete")]
        public async Task<IActionResult> DeleteReservation([FromBody] string reservationReferance, CancellationToken cancellationToken)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return BadRequest();
            try
            {
                bool isDeleted = await _reservationService.DeleteReservation(reservationReferance, Guid.Parse(userId), cancellationToken);

                if (isDeleted)
                    return Ok();
                else
                    return UnprocessableEntity();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }

        }


        [HttpGet, Route("customer/getall")]
        [Authorize]
        public async Task<IActionResult> GetReservationsByCustomer(CancellationToken cancellationToken)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return BadRequest();

            IEnumerable<GetCustomerReservationDetailsDto> records = await _reservationService.GetReservationsByCustomerId(Guid.Parse(userId), cancellationToken);

            IEnumerable<GetCustomerReservationsResponse> result = _mapper.Map<IEnumerable<GetCustomerReservationsResponse>>(records);


            return Ok(result);
        }

    }
}
