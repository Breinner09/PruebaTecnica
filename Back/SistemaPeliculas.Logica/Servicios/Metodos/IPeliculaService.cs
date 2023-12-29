using SistemaPeliculas.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPeliculas.Logica.Servicios.Metodos
{
    public interface IPeliculaService
    {
        Task<List<PeliculaDTO>> Lista();
        Task<PeliculaDTO> Guardar(PeliculaDTO modelo);
        Task<bool> Editar(PeliculaDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<PeliculaDTO>> ObtenerPorIdUsuario(int userId);
    }
}
