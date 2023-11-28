using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DotNote2.Servicios;
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
            var usuario = await sqlite.IniciarSesionAsync(Username,Password);
            if (usuario != null)
            {
                App.Usuario = usuario;
                await SecureStorage.Default.SetAsync("usuario",usuario.Username);
                await SecureStorage.Default.SetAsync("password",usuario.Password);
                await Application.Current.MainPage.Navigation.PushAsync(new MisNotas());
            }
        }
        [RelayCommand]
        public async Task IrRegistrar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegistroView());
        }
    }
}
