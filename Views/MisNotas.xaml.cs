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

    public async void Pruebass(object sender, EventArgs e)
	{
		await DisplayAlert("DOTNOTE","Si funciono jajaj","Ok");
	}
    public async void Contacto(object sender, EventArgs e)
    {
        await DisplayAlert("DOTNOTE", "ejemplo de contacto", "Ok");
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await vm.Obtenernotas();
    }
}