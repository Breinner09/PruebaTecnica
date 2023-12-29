using AutoMapper;
using SistemaPeliculas.Data.Repositorios.Metodos;
using SistemaPeliculas.DTO;
using SistemaPeliculas.Logica.Servicios.Metodos;
using SistemaPeliculas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPeliculas.Logica.Servicios
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IGenericRepositorio<Pelicula> _peliculaRepositorio;
        private readonly IMapper _mapper;

        public PeliculaService(IGenericRepositorio<Pelicula> peliculaRepositorio, IMapper mapper)
        {
            _peliculaRepositorio = peliculaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PeliculaDTO>> Lista()
        {
            try
            {
                var queryPeliculas = await _peliculaRepositorio.Consultar();
                var listaPeliculas = queryPeliculas.ToList();

                return _mapper.Map<List<PeliculaDTO>>(listaPeliculas);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PeliculaDTO> Guardar(PeliculaDTO modelo)
        {
            try
            {
                var peliculaModelo = _mapper.Map<Pelicula>(modelo);

                var peliculaEncontrada = await _peliculaRepositorio.Obtener(u => u.PeliculaId == peliculaModelo.PeliculaId && u.UserId == peliculaModelo.UserId);


                if (peliculaEncontrada != null)
                {
                    throw new TaskCanceledException("La película ya esta guardada en tu perfil");
                }

                var peliculaGuardada = await _peliculaRepositorio.Crear(_mapper.Map<Pelicula>(modelo));


                if (peliculaGuardada.PeliculaId == 0)
                    throw new TaskCanceledException("La película no se pudo guardar");

                var query = await _peliculaRepositorio.Consultar(u => u.PeliculaId == peliculaGuardada.PeliculaId);

                peliculaGuardada = query.First();

                return _mapper.Map<PeliculaDTO>(peliculaGuardada);
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Editar(PeliculaDTO modelo)
        {
            try
            {
                var peliculaModelo = _mapper.Map<Pelicula>(modelo);

                var peliculaEncontrada = await _peliculaRepositorio.Obtener(u => u.Id == peliculaModelo.Id);

                if (peliculaEncontrada == null)
                    throw new TaskCanceledException("La película no se encontró");

                peliculaEncontrada.Calificacion = peliculaModelo.Calificacion;

                bool respuesta = await _peliculaRepositorio.Editar(peliculaEncontrada);

                if (!respuesta)
                    throw new TaskCanceledException("La calificación de la película no se pudo editar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var peliculaEncontrada = await _peliculaRepositorio.Obtener(u => u.Id == id);

                if (peliculaEncontrada == null)
                    throw new TaskCanceledException("La película no se encontró");

                bool respuesta = await _peliculaRepositorio.Eliminar(peliculaEncontrada);

                if (!respuesta)
                    throw new TaskCanceledException("La película no se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PeliculaDTO>> ObtenerPorIdUsuario(int userId)
        {
            try
            {
                var queryPeliculasUsuario = await _peliculaRepositorio.Consultar(u => u.UserId == userId);
                var listaPeliculasUsuario = queryPeliculasUsuario.ToList();

                if (listaPeliculasUsuario == null || listaPeliculasUsuario.Count == 0)
                {
                    throw new TaskCanceledException("No se encontraron peliculas guardadas en este perfil");
                }

                return _mapper.Map<List<PeliculaDTO>>(listaPeliculasUsuario);
            }
            catch
            {
                throw;
            }
        }
    }
}
