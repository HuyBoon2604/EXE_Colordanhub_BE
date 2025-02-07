using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Booking_Dance_Data.Models.Entities;

namespace Booking_Dance_Data.Models.Entities
{
    public class Account : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string? GoogleId { get; set; }
        public string RoleId { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }

        public string Password { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? DateOfBirth { get; set; }

        // Quan hệ 1-N với các bảng khác
        public ICollection<Noti> Notis { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Studio> Studios { get; set; }
        public ICollection<Voucher> Vouchers { get; set; }
        public ICollection<Review> Reviews { get; set; }

        // Quan hệ N-1 với Role
        public Role? Role { get; set; }
    }

}

