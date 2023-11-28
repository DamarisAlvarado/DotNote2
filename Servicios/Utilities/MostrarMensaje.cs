namespace DotNote2.Servicios.Utilities
{
    public class MostrarMensaje
    {
        public static async Task Error(string mensaje) =>
            await Application.Current.MainPage.DisplayAlert("¡Error!", mensaje, "¡Ups!");

        public static async Task Precaucion(string mensaje) =>
            await Application.Current.MainPage.DisplayAlert("¡Atencion!", mensaje, "¡Ok!");

        public static async Task Informacion(string mensaje) =>
            await Application.Current.MainPage.DisplayAlert("¡Informacion!", mensaje, "¡Bien!");

        public static async Task<bool> Pregunta(string pregunta) =>
            await Application.Current.MainPage.DisplayAlert("Pregunta", pregunta, "Sí", "No");

        public static async Task<bool> Camara(string pregunta) =>
            await Application.Current.MainPage.DisplayAlert("Medio", pregunta, "Camara", "Galeria");
    }
}
