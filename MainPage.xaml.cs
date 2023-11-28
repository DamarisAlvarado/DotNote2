using DotNote2.Viewmodels;

namespace DotNote2
{
    public partial class MainPage : ContentPage
    {

        InicioSesionVM iniciar;
        public MainPage()
        {
            InitializeComponent();
            iniciar = new InicioSesionVM();
            BindingContext = iniciar;

        }

        
    }
}