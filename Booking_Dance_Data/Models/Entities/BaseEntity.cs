namespace Booking_Dance_Data.Models.Entities
{
    public class BaseEntity
    {
        public bool? IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
