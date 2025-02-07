using Booking_Dance_Bussiness.Service.Implements;
using Booking_Dance_Bussiness.Service.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;

namespace Booking_Dance_Project_API.Helper;


public static class FireBaseHelper
{
    public static IServiceCollection AddFirebaseServices(this IServiceCollection services)
    {
        var credentialPath = Path.Combine(Directory.GetCurrentDirectory(),
            "cursusprojectinternship-62f5e39c9095.json");

        services.AddSingleton(StorageClient.Create(GoogleCredential.FromFile(credentialPath)));

        services.AddScoped<IFirebaseService, FirebaseService>();
        return services;
    }


}