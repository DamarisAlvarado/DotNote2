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

        [ObservableProperty]
        public ImageSource image;

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
        public async Task ObtenerImagen()
        {
            try
            {
                IsBusy = true;

                if(!MediaPicker.IsCaptureSupported)
                {
                    await MostrarMensaje.Precaucion("No se puede acceder a galería");
                    return;
                }

                if(await MostrarMensaje.Camara("¿Como deseas adjuntar una imagen?"))
                {
                    var fotografia = await MediaPicker.Default.CapturePhotoAsync();
                    if(fotografia != null)
                    {
                        string localFilePath = Path.Combine(FileSystem.AppDataDirectory, fotografia.FileName);

                        Stream sourceStream = await fotografia.OpenReadAsync();
                        FileStream localFileStream = File.OpenWrite(localFilePath);

                        await sourceStream.CopyToAsync(localFileStream);
                        ImageAttached = localFilePath;
                        await CargarImagen();
                    }
                }
                else
                {
                    var fotografia = await MediaPicker.Default.PickPhotoAsync();
                    if (fotografia != null)
                    {
                        string localFilePath = Path.Combine(FileSystem.AppDataDirectory, fotografia.FileName);

                        Stream sourceStream = await fotografia.OpenReadAsync();
                        FileStream localFileStream = File.OpenWrite(localFilePath);

                        await sourceStream.CopyToAsync(localFileStream);
                        ImageAttached = localFilePath;
                        await CargarImagen();
                    }
                }
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"ObtenerImagen: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
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

        public async Task CargarImagen()
        {
            try
            {
                Image = ImageSource.FromFile(ImageAttached);
            }
            catch (Exception ex) 
            {
                await MostrarMensaje.Error($"CrearNota: {ex.Message}");
            }
        }
    }
}
