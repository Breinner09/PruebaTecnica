using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaPeliculas.DTO;
using SistemaPeliculas.Modelos;

namespace SistemaPeliculas.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region User
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<User, SesionDTO>().ReverseMap();
            #endregion

            #region Pelicula
            CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
           
            //CreateMap<User, SesionDTO>().ReverseMap();
            #endregion

        }

    }
}
