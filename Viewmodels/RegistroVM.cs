using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNote2.Models;
using DotNote2.Servicios;
using DotNote2.Servicios.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNote2.Viewmodels
{
    public partial class RegistroVM :  BaseViewmodel.BaseViewmodel
    {
        SQLiteService sqlite;

        [ObservableProperty]
        public string nameSurname;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        public RegistroVM()
        {
            sqlite = new SQLiteService();
            NameSurname = string.Empty;
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
        [RelayCommand]
        public async Task Registrar()
        {
            try
            {
                IsBusy = true;

                Usuario usuario = new Usuario()
                {
                    NameSurname = NameSurname,
                    Username = Username,
                    Password = Password,
                    Email = Email
                };
                if (await sqlite.CrearModificaraUsuarioAsync(usuario))
                {
                    await MostrarMensaje.Informacion("Usuario creado");
                    await SecureStorage.Default.SetAsync("usuario", usuario.Username);
                    await SecureStorage.Default.SetAsync("password", usuario.Password);
                }
                else
                {
                    await MostrarMensaje.Informacion("Usuario no creado");
                }
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"Registrar: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
                await Application.Current.MainPage.Navigation.PopAsync();
                await MainPage.iniciar.ObtenerDatos();
            }
        }
    }
}
