using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNote2.Models;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using System.Collections.ObjectModel;
using System;

namespace DotNote2.Viewmodels
{
    public partial class CrearNotaViewmodel : BaseViewmodel.BaseViewmodel
    {
        [ObservableProperty]
        public string header;

        [ObservableProperty]
        public string body;

        public string ImageAttached;

        private SQLiteService SQLiteService;

      
        public CrearNotaViewmodel() 
        { 
            SQLiteService = new SQLiteService();
            Header = string.Empty;
            Body = string.Empty;
            ImageAttached = string.Empty;
        }
        ObservableCollection<Nota> notas { get; } = new();

        public async Task Obtenernotas()
        {

            SQLiteService = new SQLiteService();
            var lista = await SQLiteService.ObtenerMisNotasAsync(App.Usuario);
            foreach (var nota in lista) { notas.Add(nota); }

        }

        [RelayCommand]
        public async Task CrearNota()
        {
            try
            {
                IsBusy = true;

                var nota = new Nota()
                {
                    IsSaved = 0,
                    Username = App.Usuario.Username,
                    Header = Header,
                    Body = Body,
                    ImageAttached = ImageAttached,
                    Date = DateTime.Today.ToString("dd-MMM-yyyy"),
                    Time = DateTime.Now.ToString("hh:mm:ss tt")
                };

                if(!await SQLiteService.CrearModificarNotaAsync(nota))
                {
                    await MostrarMensaje.Precaucion("No se pudo crear la nota");
                    return;
                }

                await MostrarMensaje.Informacion("Nota creada con exito");
            }
            catch(Exception ex)
            {
                await MostrarMensaje.Error($"CrearNota: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
