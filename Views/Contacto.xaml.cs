namespace DotNote2.view;

public partial class Contacto : ContentPage
{
	public Contacto()
	{
		InitializeComponent();
	}

    public async void clicnuevo(object sender, EventArgs e)
    {
        await DisplayAlert("Más Información", " Damaris Alvarado \n Llamar al 8121714183 o enviar email al : damaris@gmail.com", "Cerrar");

    }
    public async void clicnuevoSam(object sender, EventArgs e)
    {
        await DisplayAlert("Más Información", " Samantha Flores \n Llamar al 8175623085 o enviar email al : samantha@gmail.com", "Cerrar");

    }
    public async void clicnuevoAmel(object sender, EventArgs e)
    {
        await DisplayAlert("Más Información", " Amel Delgado \n Llamar al 8152649572 o enviar email al : amel@gmail.com", "Cerrar");

    }
}