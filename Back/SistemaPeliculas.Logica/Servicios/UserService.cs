using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaPeliculas.Logica.Servicios.Metodos;
using SistemaPeliculas.Data.Repositorios.Metodos;
using SistemaPeliculas.DTO;
using SistemaPeliculas.Modelos;


namespace SistemaPeliculas.Logica.Servicios
{
    public class UserService : IUserService
    {
        private readonly IGenericRepositorio<User> _userRepositorio;
        private readonly IMapper _mapper;

        public UserService(IGenericRepositorio<User> userRepositorio, IMapper mapper)
        {
            _userRepositorio = userRepositorio;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> Lista()
        {
            try
            {
                var queryUser = await _userRepositorio.Consultar();
                var listaUser = queryUser.ToList();

                return _mapper.Map<List<UserDTO>>(listaUser);
            }
            catch
            {
                throw;
            }
        }
        public async Task<SesionDTO> ValidacionCredenciales(string username, string password)
        {
            try
            {
                var queryUser = await _userRepositorio.Consultar(u =>
                u.UserName == username && u.Password == password);

                if (queryUser.FirstOrDefault() == null)
                    throw new TaskCanceledException("El usuario y/o contraseña son incorrectos");

                User devolverUsuario = queryUser.First();

                return _mapper.Map<SesionDTO>(devolverUsuario);
            }
            catch
            {
                throw;
            }
        }
        public async Task<UserDTO> Registrar(UserDTO modelo)
        {
            try
            {
                var userModelo = _mapper.Map<User>(modelo);

                var usuarioEncontrado = await _userRepositorio.Obtener(u => u.UserName == userModelo.UserName);

                if (usuarioEncontrado != null)
                {
                    throw new TaskCanceledException("El usuario ya existe");
                }

                var usuarioCreado = await _userRepositorio.Crear(_mapper.Map<User>(modelo));


                if (usuarioCreado.UserId == 0)
                    throw new TaskCanceledException("El usuario no se pudo crear");

                var query = await _userRepositorio.Consultar(u => u.UserId == usuarioCreado.UserId);

                usuarioCreado = query.First();

                return _mapper.Map<UserDTO>(usuarioCreado);
            }
            catch
            {
                throw;
            }
        }


    }
}
