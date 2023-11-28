using DotNote2.Viewmodels;

namespace DotNote2.Views;

public partial class MisNotas : ContentPage
{
	public MisNotas()
	{
		InitializeComponent();
		BindingContext = new MisNotasViewmodel();
	}

	public async void Pruebass(object sender, EventArgs e)
	{
		await DisplayAlert("DOTNOTE","Si funciono jajaj","Ok");
	}
    public async void Contacto(object sender, EventArgs e)
    {
        await DisplayAlert("DOTNOTE", "ejemplo de contacto", "Ok");
    }
}