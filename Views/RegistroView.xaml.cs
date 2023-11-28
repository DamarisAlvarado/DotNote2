using DotNote2.Viewmodels;

namespace DotNote2.Views;

public partial class RegistroView : ContentPage
{
	public RegistroView()
	{
		InitializeComponent();
		BindingContext = new RegistroVM();
	}
}