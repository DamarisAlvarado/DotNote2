using CommunityToolkit.Mvvm.Input;
using DotNote2.Models;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using DotNote2.Views;
using System.Collections.ObjectModel;

namespace DotNote2.Viewmodels
{
    public partial class MisNotasViewmodel : BaseViewmodel.BaseViewmodel
    {

        private SQLiteService SQLiteService;
        public ObservableCollection<Nota> notas { get; } = new();

        public async Task Obtenernotas()
        {
            notas.Clear();
            SQLiteService = new SQLiteService();
            var lista = await SQLiteService.ObtenerMisNotasAsync(App.Usuario);
            foreach (var nota in lista) { notas.Add(nota); }

        }
        public async Task Eliminar()
        {
          // no funciona 
            SQLiteService = new SQLiteService();
            await SQLiteService.BorrarNotaAsync(App.Usuario);
            

        }


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
