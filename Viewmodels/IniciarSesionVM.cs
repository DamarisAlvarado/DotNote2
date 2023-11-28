namespace DotNote2.Viewmodels;

public class IniciarSesionVM : ContentPage
{
	public IniciarSesionVM()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}