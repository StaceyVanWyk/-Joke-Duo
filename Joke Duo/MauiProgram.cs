using Joke_Duo.Services;
using Joke_Duo.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using JokeDuo.ViewModels;
using JokeDuo.Views;


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
            builder.Services.AddSingleton<ConfigurationService>();
            builder.Services.AddSingleton<IJokeApiService, JokeApiHttpService>();
            builder.Services.AddTransient<JokeDuoViewModel>();
            builder.Services.AddTransient<JokeDuoView>();
#endif

            return builder.Build();
        }
    }
}
