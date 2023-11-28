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
        public string username;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string password;

        public RegistroVM()
        {
            sqlite = new SQLiteService();
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
        [RelayCommand]
        public async Task Registrar()
        {
            Usuario usuario = new Usuario()
            {
                Username = username, Password = password, Email = email
            };
            if(await sqlite.CrearModificaraUsuarioAsync(usuario)) 
            {
                
            }
            else
            {

            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
