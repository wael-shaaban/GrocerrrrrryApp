using Microsoft.Extensions.Logging;
using CommunityToolkit;
using CommunityToolkit.Maui;

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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
