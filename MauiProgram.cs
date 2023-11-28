using DotNote2.Viewmodels;
using Microsoft.Extensions.Logging;

namespace DotNote2
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

            builder.Services.AddSingleton<CrearNotaViewmodel>();
            builder.Services.AddSingleton<InicioSesionVM>();
            builder.Services.AddSingleton<MisNotasViewmodel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}