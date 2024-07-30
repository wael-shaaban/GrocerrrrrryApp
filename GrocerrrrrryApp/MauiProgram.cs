using Microsoft.Extensions.Logging;
using CommunityToolkit;
using CommunityToolkit.Maui;
using GrocerrrrrryApp.Services;
using GrocerrrrrryApp.Pages;
using GrocerrrrrryApp.Interfaces;
using GrocerrrrrryApp.ViewModels;

namespace GrocerrrrrryApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                    fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuSemibold");
                });
            builder.Services.AddSingleton<IPlatformMessageHanger>(_ =>
            {
#if ANDROID
                return new Platforms.Android.AndroidHttpMessageHandler();
#elif IOS    
                return new Platforms.iOS.IosHttpMessageHandler();
#else
                throw new PlatformNotSupportedException("Only Android and iOS supported.");
#endif
            });
            builder.Services.AddHttpClient(Helpers.Constants.HttpsClientName, config =>
            {
                var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:54321" : "https://localhost:54321";
                config.BaseAddress = new Uri(baseAddress);
            }).ConfigureHttpMessageHandlerBuilder(handler =>
            {
                var httpMessageHandler = handler.Services.GetRequiredService<IPlatformMessageHanger>();
                handler.PrimaryHandler = httpMessageHandler.GetHttpMessageHandler();
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            //pages
            builder.Services.AddSingleton<HomePage>();
            //viewmodels
            builder.Services.AddSingleton<HomePageViewModel>();
            //services
            builder.Services.AddSingleton<CategoryService>();
            builder.Services.AddTransient<OfferService>();
            return builder.Build();
        }
    }
}
