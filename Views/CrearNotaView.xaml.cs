using DotNote2.Models;
using DotNote2.Viewmodels;

namespace DotNote2.Views;

public partial class CrearNotaView : ContentPage
{
	public CrearNotaView(Nota? nota)
	{
		InitializeComponent();
		BindingContext = new CrearNotaViewmodel(nota);
	}
}