using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Models.DTO.BookingDTO;
using Booking_Dance_Data.Models.Entities;
using Booking_Dance_Data.Repository;
using Booking_Dance_Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Implements
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IAccountRepo _accountRepo;
        private readonly IStudioRepo _studioRepo;
        private readonly IClassDanceRepo _classRepo;

        public BookingService(IBookingRepo bookingRepo, IAccountRepo accountRepo, IStudioRepo studioRepo, IClassDanceRepo classRepo)
        {
            _bookingRepo = bookingRepo;
            _accountRepo = accountRepo;
            _studioRepo = studioRepo;
            _classRepo = classRepo;
        }

        public async Task<Booking> AddNewBooking(AddBookingDTO request)
        {
            var ac = await _accountRepo.CheckUserRole(request.AccountId);
            var st = await _studioRepo.GetStudioById(request.StudioId);

            if (ac != null && st != null)
            {
                DateTime checkInDateTime = DateTime.Parse(request.CheckIn);
                DateTime checkOutDateTime = DateTime.Parse(request.CheckOut);

                var totalHours = (checkOutDateTime - checkInDateTime).TotalHours;


                decimal pricePerHour = st.Pricing.GetValueOrDefault(0);

                if (pricePerHour == 0)
                {

                    return null;
                }

                decimal totalPrice = (decimal)totalHours * pricePerHour;


                var booking = new Booking
                {
                    Id = Guid.NewGuid().ToString().Substring(0, 5),
                    AccountId = request.AccountId,
                    StudioId = request.StudioId,
                    BookingDate = request.BookingDate,
                    CheckIn = request.CheckIn,
                    CheckOut = request.CheckOut,
                    TotalPrice = totalPrice,
                };

                await _bookingRepo.AddBooking(booking);
                return booking;
            }

            return null;
        }

        public async Task<Booking> AddNewBookingClassDance(AddBookingClassDTO request)
        {
            // Validate input
            if (request == null)
                throw new ArgumentNullException(nameof(request), "Request cannot be null");

            // Fetch account role
            var ac = await Task.Run(() => _accountRepo.CheckUserRole(request.AccountId));
            if (ac == null)
                throw new InvalidOperationException($"Invalid AccountId: {request.AccountId}");

            // Fetch class dance
            var st = await _classRepo.GetClassDanceByIdAsync(request.ClassDanceId);
            if (st == null)
                throw new InvalidOperationException($"ClassDance not found for Id: {request.ClassDanceId}");

            // Create new booking
            var booking = new Booking
            {
                Id = Guid.NewGuid().ToString().Substring(0, 5),
                AccountId = request.AccountId,
                ClassId = request.ClassDanceId,
                BookingDate = request.BookingDate,
                TotalPrice= request.TotalPrice, 

            };

            // Add to database
            await _bookingRepo.AddBooking(booking);
            return booking;
        }

        public async Task<BookingByBookingIdDTO> GetbookingByid(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Booking ID cannot be null or empty.", nameof(id));
            }

            try
            {

                var booking = await _bookingRepo.GetBookingById(id);


                if (booking == null)
                {
                    throw new KeyNotFoundException($"Booking with ID: {id} not found.");
                }


                var getBooking = new BookingByBookingIdDTO
                {
                    Id = booking.Id,
                    AccountId = booking.AccountId,
                    StudioId = booking.StudioId,
                    ClassId = booking.ClassId,
                    BookingDate = booking.BookingDate,
                    CheckIn = booking.CheckIn,
                    CheckOut = booking.CheckOut,
                    TotalPrice = booking.TotalPrice,
                    UserName = booking.Account?.UserName ?? "N/A",
                    StudioName = booking.Studio?.StudioName ?? "N/A",
                    StudioAddress = booking.Studio?.StudioAddress ?? "N/A",
                    StudioDescription = booking.Studio?.StudioDescription ?? "N/A",
                    ImageStudio = booking.Studio?.ImageStudio ?? "No Image Available"
                };

                return getBooking;
            }
            catch (KeyNotFoundException ex)
            {


                throw;
            }
            catch (Exception ex)
            {


                throw new Exception("An unexpected error occurred. Please try again later.");
            }
        }

    }
}
