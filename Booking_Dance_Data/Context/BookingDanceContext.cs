using Booking_Dance_Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking_Dance_Data.Context
{
    public class BookingDanceContext : DbContext
    {
        public BookingDanceContext(DbContextOptions<BookingDanceContext> options) : base(options) { }

        public DbSet<Noti> Notis { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Capacity> Capacities { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ClassDance> ClassDances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Capacity -> Size 
            modelBuilder.Entity<Capacity>()
                .HasOne(n => n.Size)
                .WithMany()
                .HasForeignKey(n => n.SizeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Capacity -> Studio 
            modelBuilder.Entity<Capacity>()
                .HasOne(n => n.Studio)
                .WithMany()
                .HasForeignKey(n => n.StudioId)
                .OnDelete(DeleteBehavior.Restrict);



            // Image -> Studio 
            modelBuilder.Entity<Image>()
                .HasOne(n => n.Studio)
                .WithMany()
                .HasForeignKey(n => n.StudioId)
                .OnDelete(DeleteBehavior.Restrict);


            // Account -> ClassDance 
            modelBuilder.Entity<ClassDance>()
                .HasOne(n => n.Account)
                .WithMany()
                .HasForeignKey(n => n.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Class -> Booking 
            modelBuilder.Entity<Booking>()
                .HasOne(n => n.ClassDance)
                .WithMany()
                .HasForeignKey(n => n.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Class -> Studio 
            modelBuilder.Entity<ClassDance>()
                .HasOne(n => n.Studio)
                .WithMany()
                .HasForeignKey(n => n.StudioId)
                .OnDelete(DeleteBehavior.Restrict);
            // Noti -> Account (1-N)
            modelBuilder.Entity<Noti>()
                .HasOne(n => n.Account)
                .WithMany(a => a.Notis)
                .HasForeignKey(n => n.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Account -> Role (1-N)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Account -> Studio (1-N)
            modelBuilder.Entity<Studio>()
                .HasOne(s => s.Account)
                .WithMany(a => a.Studios)
                .HasForeignKey(s => s.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Studio -> Booking (1-N)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Studio)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.StudioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> Account (N-1)
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Account)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccountId)
                .OnDelete(DeleteBehavior.Restrict);



            // Studio -> Category (1-N)
            modelBuilder.Entity<Studio>()
                .HasOne(s => s.Category)
                .WithMany()
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            // Review -> Studio (1-N)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Studio)
                .WithMany(s => s.Reviews)
                .HasForeignKey(r => r.StudioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Review -> Account (1-N)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Account)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order -> Booking (1-N)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Booking)
                .WithMany(b => b.Orders)
                .HasForeignKey(o => o.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment -> Order (1-N)
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Voucher -> Account (1-N)
            modelBuilder.Entity<Voucher>()
                .HasOne(v => v.Account)
                .WithMany(a => a.Vouchers)
                .HasForeignKey(v => v.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Voucher -> Studio (1-N)
            modelBuilder.Entity<Voucher>()
                .HasOne(v => v.Studio)
                .WithMany(s => s.Vouchers)
                .HasForeignKey(v => v.StudioId)
                .OnDelete(DeleteBehavior.Restrict);

            // History -> Payment (1-N)
            modelBuilder.Entity<History>()
                .HasOne(h => h.Payment)
                .WithMany(p => p.Histories)
                .HasForeignKey(h => h.PaymentId)
                .OnDelete(DeleteBehavior.Restrict);

        
        }
    }
}
