using DotNote2.Models;
using DotNote2.Servicios.Constants;
using DotNote2.Servicios.Utilities;
using SQLite;

namespace DotNote2.Servicios
{
    /// <summary>
    /// Clase que ofrece los servicios de consulta, inserccion, actualizacion y eliminacion de datos. <br/>
    /// Todos sus metodos son asincronos.
    /// </summary>
    public class SQLiteService
    {
        /// <summary>
        /// Componente que realiza las tareas con la base de datos.
        /// </summary>
        private readonly SQLiteAsyncConnection _database;

        /// <summary>
        /// Constructor, inicia una vez se crea un nuevo objeto.
        /// </summary>
        public SQLiteService()
        {
            // Iniciamos nuestra conexion a la base de datos, se creará si no existe
            _database = new SQLiteAsyncConnection(Constantes.DatabasePath, Constantes.Flags);
            // Crea la tabal Usuario, si no existe
            _database.CreateTableAsync<Usuario>().Wait();
            // Crea la tabla Nota, si no existe
            _database.CreateTableAsync<Nota>().Wait();
        }

        /// <summary>
        /// Crea o modifica un usuario pasado como parametro.
        /// </summary>
        /// <param name="user">El usuario nuevo a insertar, en otro caso se modifica</param>
        /// <returns>Task: retorna true si se ejecuta con exito</returns>
        public async Task<bool> CrearModificaraUsuarioAsync(Usuario user)
        {
            try
            {
                if (user.Id != 0)
                    await _database.UpdateAsync(user);
                else
                    await _database.InsertAsync(user);
                return await Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                await MostrarMensaje.Error($"CrearModificarUsuario: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Metodo para iniciar sesion
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="password">Contraseña</param>
        /// <returns>El usuario; o null, si no se encuentra</returns>
        public async Task<Usuario> IniciarSesionAsync(string usuario, string password)
        {
            return await Task.FromResult(await _database.Table<Usuario>().Where(u => u.Username == usuario && u.Password == password).FirstOrDefaultAsync());
        }

        /// <summary>
        /// Crea o modifica una nota pasada como parametro.
        /// </summary>
        /// <param name="nota">Nota a insertar o modificar</param>
        /// <returns>Task: true si se ejecuta con exito</returns>
        public async Task<bool> CrearModificarNotaAsync(Nota nota)
        {
            try
            {
                if (nota.Id != 0)
                    await _database.UpdateAsync(nota);
                else
                    await _database.InsertAsync(nota);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"CrearModificarNota: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Funcion que elimina un usuario.
        /// </summary>
        /// <param name="id">El Id del usuario</param>
        /// <returns>Tsak: true si se ejecuto con exito</returns>
        public async Task<bool> BorrarUsuarioAsync(int id)
        {
            try
            {
                await _database.DeleteAsync<Usuario>(id);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"BorrarUsuario: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Borra una nota.
        /// </summary>
        /// <param name="id">El Id de la nota</param>
        /// <returns>Task: true si se ejecuto con exito</returns>
        public async Task<bool> BorrarNotaAsync(int id)
        {
            try 
            {
                await _database.DeleteAsync<Nota>(id);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                await MostrarMensaje.Error($"BorrarNota: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Consulta las notas de "Mis Notas".
        /// </summary>
        /// <param name="user">Usuario del cual se obtiene las notas</param>
        /// <param name="busqueda">String de texto a buscar, titulo</param>
        /// <returns>Lista de notas, puede usarse en un CollectionView para mostrar</returns>
        public async Task<List<Nota>> ObtenerMisNotasAsync(Usuario user, string busqueda = "")
        {
            return await Task.FromResult(await _database.Table<Nota>().Where(n => n.IsSaved == 0 && n.Header.Contains(busqueda) && n.Username == user.Username).ToListAsync());
        }

        /// <summary>
        /// Consulta las notas archivadas.
        /// </summary>
        /// <param name="user">Usuario del cual se obtiene las notas</param>
        /// <param name="busqueda">String de texto a buscar, titulo</param>
        /// <returns>Lista de notas, puede usarse en un CollectionView para mostrar</returns>
        public async Task<List<Nota>> ObtenerNotasGuardadasAsync(Usuario user, string busqueda = "")
        {
            return await Task.FromResult(await _database.Table<Nota>().Where(n => n.IsSaved == 1 && n.Header.Contains(busqueda) && n.Username == user.Username).ToListAsync());
        }

        internal Task BorrarNotaAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
