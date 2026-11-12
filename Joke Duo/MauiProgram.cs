
using Joke_Duo.Services;
using Joke_Duo.Services.Interfaces;
using Joke_Duo.ViewModels;

using JokeDuo;
using JokeDuo.ViewModels;
using JokeDuo.Views;
using Microsoft.Extensions.Logging;
using System.Net.Http;

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

            // Register services
            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddSingleton<
                IConfigurationService, ConfigurationService>();

            builder.Services.AddSingleton<
                IJokeApiService, JokeApiHttpService>();

            // Register ViewModel and View
            builder.Services.AddTransient<JokeDuoViewModel>();
            builder.Services.AddTransient<JokeDuoView>();

            // Register AppShell
            builder.Services.AddSingleton<AppShell>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
