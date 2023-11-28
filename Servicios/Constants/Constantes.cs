using SQLite;

namespace DotNote2.Servicios.Constants
{
    /// <summary>
    /// Clase con los datos importantes para la creacion de la base de datos.
    /// </summary>
    public class Constantes
    {
        /// <summary>
        /// Constante que contiene el nombre de la base de datos.
        /// </summary>
        public const string DatabaseFilename = "DotNote.db3";

        /// <summary>
        /// Flags para configurar el comportamiento del servicio.
        /// </summary>
        public const SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        /// <summary>
        /// Ruta de almacenamiento de la base de datos.
        /// </summary>
        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
