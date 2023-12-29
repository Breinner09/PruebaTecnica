using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace SistemaPeliculas.Data.Repositorios.Metodos
{
    //Acá van a estar los metodos con los cuales se va a trabajar con los modelos
    public interface IGenericRepositorio<TModel> where TModel : class
    {
        Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);
        Task<TModel> Crear(TModel modelo);
        Task<bool> Editar(TModel modelo);
        Task<bool> Eliminar(TModel modelo);
        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);
    }
}
