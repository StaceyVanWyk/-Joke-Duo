using Microsoft.Extensions.Logging;
using System.Net.Http;
using Joke_Duo.Services;


namespace Joke_Duo
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

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<JokeService>();
#endif

            return builder.Build();
        }
    }
}
