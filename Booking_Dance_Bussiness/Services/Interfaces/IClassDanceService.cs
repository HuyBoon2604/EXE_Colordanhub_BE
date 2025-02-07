using Booking_Dance_Data.Models.DTO.BookingDTO;
using Booking_Dance_Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Bussiness.Services.Interfaces
{
    public interface IClassDanceService
    {
        //Task<ClassDance> AddNewClassDance(AddBookingDTO request);
        Task<List<ClassDance>>GetAllClassDance();

    }
}
