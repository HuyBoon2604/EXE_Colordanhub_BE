using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Dance_Data
{
    public class ChatDTO
    {
        public string Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Content { get; set; } = null!;

        public DateTime Time { get; set; }

    }
}
