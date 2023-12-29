    using System;
using System.Collections.Generic;

namespace SistemaPeliculas.Modelos
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public int? PeliculaId { get; set; }
        public string? NombrePelicula { get; set; }
        public int? Calificacion { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
