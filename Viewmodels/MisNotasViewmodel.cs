using CommunityToolkit.Mvvm.Input;
using DotNote2.Servicios.Utilities;
using DotNote2.Views;

namespace DotNote2.Viewmodels
{
    public partial class MisNotasViewmodel : BaseViewmodel.BaseViewmodel
    {
        [RelayCommand]
        public async Task IrCrearNota()
        {
            try
            {
                IsBusy = true;
                await Application.Current.MainPage.Navigation.PushAsync(new CrearNotaView());
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"IrCrearNota: {ex.Message}");
            }
            finally 
            { 
                IsBusy = false; 
            }
        }

    }
}
