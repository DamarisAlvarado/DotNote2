﻿using CommunityToolkit.Mvvm.Input;
using DotNote2.Models;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using DotNote2.Views;
using System.Collections.ObjectModel;

namespace DotNote2.Viewmodels
{
    public partial class MisNotasViewmodel : BaseViewmodel.BaseViewmodel
    {
        public string nombre { get; set; }
        public MisNotasViewmodel()
        {
             nombre = App.Usuario.NameSurname;
        }

        private SQLiteService SQLiteService;
        public ObservableCollection<Nota> notas { get; } = new();

        public async Task Obtenernotas()
        {
            notas.Clear();
            SQLiteService = new SQLiteService();
            var lista = await SQLiteService.ObtenerMisNotasAsync(App.Usuario);
            foreach (var nota in lista) { notas.Add(nota); }
        }

        [RelayCommand]
        public async Task Eliminar(int id)
        {
            // Si funciona
            SQLiteService = new SQLiteService();
            await SQLiteService.BorrarNotaAsync(id);
            await Obtenernotas();
            await MostrarMensaje.Informacion("Nota Eliminada");
        }


        [RelayCommand]
        public async Task IrCrearNota(Nota nota)
        {
            try
            {
                IsBusy = true;
                await Application.Current.MainPage.Navigation.PushAsync(new CrearNotaView(nota));
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

        [RelayCommand]
        public async Task Email(Nota nota)
        {
            try
            {
                IsBusy = true;

                var usuario = await MostrarMensaje.Email();
                var user = await SQLiteService.ObtenerUsuarioAsync(usuario);

                if (user != null)
                {
                    if (await EmailService.EnviarEmailAsync(App.Usuario, user, nota))
                    {
                        await MostrarMensaje.Informacion("Se envio el email con exito");
                        return;
                    }
                }
                await MostrarMensaje.Precaucion($"El usuario no existe");
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"Email: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                await Obtenernotas();
            }
        }
    }
}
