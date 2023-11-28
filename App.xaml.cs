using DotNote2.Models;

namespace DotNote2
{
    public partial class App : Application
    {
        /// <summary>
        /// Usuario logueado. <br/>
        /// En el inicio de sesion se define su valor para ser usado en los otros view.
        /// </summary>
        public static Usuario Usuario { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            Usuario = new Usuario()
            { 
                Id = 100,
                NameSurname = "Damaris",
                Username = "damaris",
                Password = "damaris",
                Email = "damaris@gmail.com"
            };
        }
    }
}