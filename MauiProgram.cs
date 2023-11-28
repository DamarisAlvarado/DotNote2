using DotNote2.view;
using DotNote2.Viewmodels;
using DotNote2.Viewmodels.BaseViewmodel;
using DotNote2.Views;
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
            builder.Services.AddSingleton<RegistroVM>();
            builder.Services.AddSingleton<BaseViewmodel>();

            builder.Services.AddTransient<MisNotas>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<Contacto>();
            builder.Services.AddTransient<CrearNotaView>();
            builder.Services.AddTransient<RegistroView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}