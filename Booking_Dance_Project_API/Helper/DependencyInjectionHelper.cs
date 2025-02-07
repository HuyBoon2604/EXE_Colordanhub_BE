
using Booking_Dance_Bussiness;
using Booking_Dance_Bussiness.Services.Implements;
using Booking_Dance_Bussiness.Services.Interfaces;
using Booking_Dance_Data.Repositories;
using Booking_Dance_Data.Repository;
using Booking_Dance_Data.Repository.Implements;
using Booking_Dance_Data.Repository.Interfaces;
using Booking_Dance_Project_API.Helper;
using Cursus.Repositories;
using System.Configuration;

namespace Booking_Dance_Project_API
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IStudioService, StudioService>();
            services.AddTransient<IStudioRepo, StudioRepo>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAccountRepo, AccountRepo>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IBookingRepo, BookingRepo>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderRepo, OrderRepo>();
            services.AddTransient<IClassDanceRepo, ClassDanceRepocs>();
            services.AddTransient<IClassDanceService, ClassDanceService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IPaymentRepo, PaymentRepo>();
            services.AddTransient<IReviewRepo, ReviewRepo>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IImageRepo, ImageRepo>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ICapacityRepo, CapacityRepo>();

            services.AddFirebaseServices();

            return services;
        }
    }
}
