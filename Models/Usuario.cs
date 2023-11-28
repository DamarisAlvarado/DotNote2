using SQLite;

namespace DotNote2.Models
{
    /// <summary>
    /// Modelo que describe la estructura de un usuario
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador del usuario. <br/>
        /// Numero entero de valor unico.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Nombre y Apellido del usuario. <br />
        /// <i>Puede ser simplemente el nombre sin el apellido.</i>
        /// </summary>
        public string NameSurname { get; set; }

        /// <summary>
        /// Nombre de usuario para iniciar sesión. <br/>
        /// Debe ser unico.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Contraseña secreta para iniciar sesión.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Correo electronico del usuario. <br/>
        /// Sirve para enviar notas por correo.
        /// </summary>
        public string Email { get; set; }
    }
}
