using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPeliculas.DTO
{
    public class PeliculaDTO
    {
        public int Id { get; set; }
        public int? PeliculaId { get; set; }
        public string? NombrePelicula { get; set; }
        public int? Calificacion { get; set; }
        public int? UserId { get; set; }
    }
}
