using System.ComponentModel.DataAnnotations;

namespace Booking_Dance_Data.Models.Entities
{
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        public string RoleName { get; set; }

        // Quan hệ 1-N với Account
        public ICollection<Account> Accounts { get; set; }
    }

}
