using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPeliculas.DTO;

namespace SistemaPeliculas.Logica.Servicios.Metodos
{
    public interface IUserService
    {
        Task<List<UserDTO>> Lista();
        Task<SesionDTO> ValidacionCredenciales(string username, string password);
        Task<UserDTO> Registrar(UserDTO modelo);
    }
}
