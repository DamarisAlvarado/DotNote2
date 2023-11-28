using SQLite;

namespace DotNote2.Models
{
    /// <summary>
    /// Modelo que describe la estructura de una nota.
    /// </summary>
    public class Nota
    {
        /// <summary>
        /// Identificador de la nota. <br/>
        /// Numero entero de valor unico.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Valor entero (0 y 1). <br/>
        /// Determina si esta nota deberia mostrarse en notas guardadas. <br/>
        /// Similar a archivar una nota.
        /// </summary>
        public int IsSaved { get; set; }

        /// <summary>
        /// Encabezado o titulo de la nota.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Mensaje de la nota.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Ruta de una imagen, si realmente se agrego una.
        /// </summary>
        public string ImageAttached { get; set; }

        /// <summary>
        /// Fecha de creación de la nota.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Hora de creación de la nota.
        /// </summary>
        public string Time { get; set; }
    }
}
