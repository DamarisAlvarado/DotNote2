using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using DotNote2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNote2.Viewmodels
{
    public partial class InicioSesionVM : BaseViewmodel.BaseViewmodel
    {
        SQLiteService sqlite;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        public InicioSesionVM()
        {
            sqlite = new SQLiteService();
            Username = string.Empty;
            Password = string.Empty;
        }

        [RelayCommand]
        public async Task IniciarSesion()
        {
            try
            {
                IsBusy = true;

                var usuario = await sqlite.IniciarSesionAsync(Username, Password);
                if (usuario != null)
                {
                    App.Usuario = usuario;
                    await SecureStorage.Default.SetAsync("usuario", usuario.Username);
                    await SecureStorage.Default.SetAsync("password", usuario.Password);
                    await Application.Current.MainPage.Navigation.PushAsync(new MisNotas());
                }
            }
            catch (Exception ex) 
            {
                await MostrarMensaje.Error($"IniciarSesion: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task ObtenerDatos()
        {
            try
            {
                IsBusy = true;

                var user = await SecureStorage.Default.GetAsync("usuario");
                var password = await SecureStorage.Default.GetAsync("password");
                Username = user != null ? user : string.Empty;
                Password = password != null ? password : string.Empty;
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"ObtenerDatos: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task IrRegistrar()
        {
            try
            {
                IsBusy = true;

                await Application.Current.MainPage.Navigation.PushAsync(new RegistroView());
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"IrRegistrar: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
