using DapperExtensions.Predicate;
using System.Collections.Generic;

namespace Capa_Datos.Interface
{
    public interface IRepositori<T> where T :class
    {
        string Agregar(T entidad);

        string Actualizar(T entidad);

        string Eliminar(int id);

        T TraerPorId(int id);

        IEnumerable<T> Listar();

        IEnumerable<T> FiltroPorUnCampo(IPredicate predicado);
    }
}
