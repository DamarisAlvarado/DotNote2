using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNote2.Models;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using System.Collections.ObjectModel;
using System;
using DotNote2.Views;

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
        private Nota Nota;
      
        public CrearNotaViewmodel(Nota nota) 
        {
            SQLiteService = new SQLiteService();
            Header = string.Empty;
            Body = string.Empty;
            ImageAttached = string.Empty;
            if(nota != null)
            {
                Nota = nota;
                Header = nota.Header;
                Body = nota.Body;
            }
        }

        [RelayCommand]
        public async Task CrearNota()
        {
            try
            {
                IsBusy = true;

                if (Nota == null)
                {
                    Nota = new Nota()
                    {
                        IsSaved = 0,
                        Username = App.Usuario.Username,
                        Header = Header,
                        Body = Body,
                        ImageAttached = ImageAttached,
                        Date = DateTime.Today.ToString("dd-MMM-yyyy"),
                        Time = DateTime.Now.ToString("hh:mm:ss tt")
                    };
                } 
                else
                {
                    Nota.Header = Header;
                    Nota.Body = Body;
                }


                if(!await SQLiteService.CrearModificarNotaAsync(Nota))
                {
                    await MostrarMensaje.Precaucion("No se pudo guardar la nota");
                    return;
                }

                await MostrarMensaje.Informacion("Nota guardada con exito");
            }
            catch(Exception ex)
            {
                await MostrarMensaje.Error($"CrearNota: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                await Application.Current.MainPage.Navigation.PopAsync();
                await MisNotas.vm.Obtenernotas();
            }
        }
    }
}
