using Microsoft.Extensions.Logging;
using Supermodel.Client.Frontend.Maui.Services;

namespace MauiTestApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #if DEBUG
    		builder.Logging.AddDebug();
            #endif

            //var x = SharedService.Instantiate<IImageResizer>();
            
            return builder.Build();
        }
    }
}
