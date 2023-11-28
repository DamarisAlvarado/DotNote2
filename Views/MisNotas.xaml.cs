using DotNote2.view;
using DotNote2.Viewmodels;

namespace DotNote2.Views;

public partial class MisNotas : ContentPage
{
    MisNotasViewmodel vm;
    public MisNotas()
    {
        InitializeComponent();
        vm = new MisNotasViewmodel();
        BindingContext = vm;
    }

  
    public async void Contacto(object sender, EventArgs e)
    {
        await  Navigation.PushAsync(new Contacto());
    }

    private async void ContentPage(object sender, EventArgs e)
    {
        await vm.Obtenernotas();
    }
}