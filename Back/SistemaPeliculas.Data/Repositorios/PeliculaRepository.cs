using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPeliculas.Data.Repositorios.Metodos;
using SistemaPeliculas.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SistemaPeliculas.Modelos;

namespace SistemaPeliculas.Data.Repositorios
{
    public class PeliculaRepository
    { /*: GenericRepository<Pelicula>, IPeliculaRepository
    {
        private readonly pruebaTecnicaContext _dbcontext;

        public PeliculaRepository(pruebaTecnicaContext dbcontext): base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        /*public async Task<Pelicula> Registrar(Pelicula modelo)
        {
            Pelicula peliculaGuardada = new Pelicula();



            try
            {

            }
            catch
            {
                throw;
            }
        }*/
    }
}
