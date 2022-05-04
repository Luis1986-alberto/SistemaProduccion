    using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Interface
{
    public class RepositorioBase<T> : IRepositori<T> where T : class
    {
        private Inicio principal = new Inicio();
        private string cadenaConexion;

        public RepositorioBase()
        {
            principal.LeerConfiguracion();
            cadenaConexion = principal.CadenaConexion;
        }

        public string Actualizar(T entidad)
        {
            throw new NotImplementedException();
        }

        public string Agregar(T entidad)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FiltroPorUnCampo(IPredicate predicado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Listar()
        {
            throw new NotImplementedException();
        }

        public T TraerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
