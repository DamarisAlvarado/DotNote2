using DotNote2.Viewmodels;

namespace DotNote2.Views;

public partial class CrearNotaView : ContentPage
{
	public CrearNotaView()
	{
		InitializeComponent();
		BindingContext = new CrearNotaViewmodel();
	}
}