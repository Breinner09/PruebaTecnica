using System;
using System.Collections.Generic;

namespace SistemaPeliculas.Modelos
{
    public partial class User
    {
        public User()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
