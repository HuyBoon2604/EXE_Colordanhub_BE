using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data
{
    public class EditAccountDTO
    {

        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? email { get; set; }
        
        public string? Phone { get; set; }

        public string? DateOfBirth { get; set; }




    }
}
