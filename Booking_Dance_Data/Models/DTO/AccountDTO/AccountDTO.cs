using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
    }
}
