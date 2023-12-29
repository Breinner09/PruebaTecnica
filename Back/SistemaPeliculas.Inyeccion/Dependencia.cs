using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPeliculas.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPeliculas.Data.Repositorios.Metodos;
using SistemaPeliculas.Data.Repositorios;
using SistemaPeliculas.Utilidades;
using SistemaPeliculas.Logica.Servicios.Metodos;
using SistemaPeliculas.Logica.Servicios;

namespace SistemaPeliculas.Inyeccion
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<pruebaTecnicaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConexionSQL"));
            });

            services.AddTransient(typeof(IGenericRepositorio<>),typeof(GenericRepository<>));

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPeliculaService, PeliculaService>();
        }
    }
}
