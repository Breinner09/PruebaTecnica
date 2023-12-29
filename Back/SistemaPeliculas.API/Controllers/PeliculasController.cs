using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPeliculas.API.Utilidad;
using SistemaPeliculas.DTO;

using SistemaPeliculas.Logica.Servicios.Metodos;
using SistemaPeliculas.Logica.Servicios;

namespace SistemaPeliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _peliculaService;

        public PeliculasController(IPeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }

        [HttpGet]
        [Route("PeliculasPopulares/{pageNumber}")]
        public async Task<IActionResult> PeliculasPopulares(int pageNumber = 1)
        {
            try
            {
                string apiKey = "276fa3cf61f3c2a41133ce9a6e283783";
                string baseUrl = "https://api.themoviedb.org/3/";
                string endpoint = "movie/popular";

                string requestUrl = $"{baseUrl}{endpoint}?api_key={apiKey}&page={pageNumber}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return Ok(jsonResponse);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Error al obtener películas populares");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("BuscarPeliculaPorNombre")]
        public async Task<IActionResult> BuscarPeliculaPorNombre(string nombrePelicula)
        {
            try
            {
                string apiKey = "276fa3cf61f3c2a41133ce9a6e283783";
                string baseUrl = "https://api.themoviedb.org/3/";
                string endpoint = "search/movie";

                string pelicula = Uri.EscapeDataString(nombrePelicula);

                string requestUrl = $"{baseUrl}{endpoint}?api_key={apiKey}&query={pelicula}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return Ok(jsonResponse);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Error al buscar la película por nombre");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("BuscarPeliculaPorId")]
        public async Task<IActionResult> BuscarPeliculaPorId(int idPelicula)
        {
            try
            {
                string apiKey = "276fa3cf61f3c2a41133ce9a6e283783";
                string baseUrl = "https://api.themoviedb.org/3/";
                string endpoint = $"movie/{idPelicula}";

                string requestUrl = $"{baseUrl}{endpoint}?api_key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return Ok(jsonResponse);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Error al buscar la película por ID");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("Detalles/{movieId}")]
        public async Task<IActionResult> Detalles(int movieId)
        {
            try
            {
                string apiKey = "276fa3cf61f3c2a41133ce9a6e283783";
                string baseUrl = "https://api.themoviedb.org/3/";
                string endpoint = $"movie/{movieId}";

                string requestUrl = $"{baseUrl}{endpoint}?api_key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return Ok(jsonResponse);
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Error al obtener detalles de la película");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet]
        [Route("PeliculasPorUsuario/{userId}")]
        public async Task<IActionResult> PeliculasPorUsuario(int userId)
        {
            var rsp = new Response<List<PeliculaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _peliculaService.ObtenerPorIdUsuario(userId);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar([FromBody] PeliculaDTO pelicula)
        {
            var rsp = new Response<PeliculaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _peliculaService.Guardar(pelicula);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPut]
        [Route("EditarCalificacion")]

        public async Task<IActionResult> EditarCalificacion([FromBody] PeliculaDTO pelicula)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _peliculaService.Editar(pelicula);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpDelete]
        [Route("EliminarPelicula/{id:int}")]

        public async Task<IActionResult> EliminarPelicula(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _peliculaService.Eliminar(id);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }


    }
}
