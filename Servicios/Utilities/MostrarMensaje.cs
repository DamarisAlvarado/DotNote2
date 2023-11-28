namespace DotNote2.Servicios.Utilities
{
    public class MostrarMensaje
    {
        public static async Task Error(string mensaje) =>
            await Application.Current.MainPage.DisplayAlert("¡Error!", mensaje, "¡Ups!");
    }
}
