using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data
{
    public class ChatOfAllAccountDTO
    {
        public string UserIdChat { get; set; }

        public string FullName { get; set; } = null!;

        public string LastMessage { get; set; } = null!;

        public DateTime LastMessageTime { get; set; }
    }
}
