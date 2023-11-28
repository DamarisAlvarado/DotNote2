namespace DotNote2.Views;

public partial class MisNotas : ContentPage
{
	public MisNotas()
	{
		InitializeComponent();
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