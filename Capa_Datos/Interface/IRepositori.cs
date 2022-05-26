using DapperExtensions.Predicate;
using System.Collections.Generic;

namespace Capa_Datos.Interface
{
    public interface IRepositori<T> where T : class
    {

        int Agregar(T entidad);

        bool Actualizar(T entidad);

        bool Eliminar(T entidad);

        T TraerPorId(int id);

        IEnumerable<T> Listar();

        IEnumerable<T> FiltroPorUnCampo(IPredicate predicado);


    }
}
