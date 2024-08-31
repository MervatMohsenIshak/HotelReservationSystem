using AutoMapper;
using HotelReservationSystem.Application.Abstractions;
using HotelReservationSystem.Application.Abstractions.Services;
using HotelReservationSystem.Application.Enum;
using HotelReservationSystem.Application.Services.DTO;
using HotelReservationSystem.Application.Services.Models;
using HotelReservationSystem.Domain.Abstractions.UnitOfWork;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReservationService(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Reservations> BookRoom(BookRoomDto bookRoomdto, CancellationToken cancellationToken)
        {
            if (bookRoomdto == null)
                throw new ArgumentNullException(nameof(bookRoomdto));

            ReservationStatusEnum status = GetStatus(bookRoomdto.StartDate);

            Reservations reservation = _mapper.Map<Reservations>(bookRoomdto);
            reservation.ReservationStatusId = (int)status;

            bool isAvailable =await CheckRoomAvailability(reservation);

            if (isAvailable)
            {
                string referanceNumber = GenerateReferanceNumber(reservation);
                reservation.ReferenceNumber = referanceNumber;
                Reservations result = await _unitOfWork.Reservations.AddAsync(reservation);
                await _unitOfWork.CommitAsync(cancellationToken);
                return result;

            }
            else
                return null;
        }

        public async Task<bool> UpdateReservation(ReservationUpdateDto reservationDto, Guid customerId, CancellationToken cancellationToken)
        {
            if (reservationDto == null)
                throw new ArgumentNullException(nameof(reservationDto));


            Reservations reservation = await _unitOfWork.Reservations.GetByRefNumberAndCustomerIdAsync(reservationDto.ReferenceNumber, customerId);
            // iterator will be null if user try to update record that not belong to him
            if (reservation == null)
                throw new Exception("Either you enter Wrong reference Number or you are not allowed to do this action.");

            ReservationStatusEnum status = GetStatus(reservationDto.StartDate);
            reservation.BoardingTypeId = reservationDto.BoardingTypeId;
            reservation.StartDate = reservationDto.StartDate;
            reservation.EndDate = reservationDto.EndDate;
            reservation.ReservationStatusId = (int)status;
            reservation.UpdatedOn = DateTime.UtcNow;
           

            _unitOfWork.Reservations.Update(reservation);
            int affectedRows = await _unitOfWork.CommitAsync(cancellationToken);

            return affectedRows > 0;

        }

        public async Task<bool> DeleteReservation(string referenceNumber, Guid customerId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(referenceNumber) || string.IsNullOrWhiteSpace(referenceNumber))
                throw new ArgumentNullException(nameof(referenceNumber));

            Reservations reservation = await _unitOfWork.Reservations.GetByRefNumberAndCustomerIdAsync(referenceNumber, customerId);

            if (reservation == null)
                throw new Exception("Either you enter Wrong reference Number or you are not allowed to do this action.");

            if(reservation.ReservationStatusId == (int)ReservationStatusEnum.UpComing)
            {
                //Soft delete by marking it as a canceled reservation
                reservation.ReservationStatusId = (int)ReservationStatusEnum.Canceled;
                _unitOfWork.Reservations.Update(reservation);
                int affectedRows = await _unitOfWork.CommitAsync(cancellationToken);

                return affectedRows > 0;
            }else
                throw new Exception("This Reservation Can't be Canceled.");


        }

        public async Task<IEnumerable<GetCustomerReservationDetailsDto>> GetReservationsByCustomerId(Guid customerId, CancellationToken cancellationToken)
        {
            if ( string.IsNullOrEmpty(customerId.ToString()) || string.IsNullOrWhiteSpace(customerId.ToString()))
                throw new ArgumentNullException(nameof(customerId));

            IEnumerable<Reservations> customerReservations = await _unitOfWork.Reservations.GetReservationsByCustomerIdAsync(customerId);

            if(!customerReservations.Any())
                return Enumerable.Empty<GetCustomerReservationDetailsDto>();

            return _mapper.Map<IEnumerable<GetCustomerReservationDetailsDto>>(customerReservations);
        }

        #region Private Methods

        private async Task<bool> CheckRoomAvailability(Reservations reservation)
        {
            IEnumerable<Reservations> rescords = await _unitOfWork.Reservations.GetReservationByRoomId(reservation.RoomId);
            //check if all records are old, not active
            int count = rescords.Where(x => x.EndDate < reservation.StartDate).Count();
            
            return count > 0? true: false;
        }

        private string GenerateReferanceNumber(Reservations reservation)
        {
            string formattedDate = reservation.StartDate.ToString("ddMMyy");
            return string.Concat("RS",reservation.RoomId.ToString(), formattedDate);
        }

        private ReservationStatusEnum GetStatus (DateTime startDate)
        {
            if (startDate < DateTime.Now)
                throw new ApplicationException("Can't Reserve in past Date");

            return startDate.Date > DateTime.UtcNow.Date ? ReservationStatusEnum.UpComing : ReservationStatusEnum.Active; 
                   
        }
        #endregion
    }
}
