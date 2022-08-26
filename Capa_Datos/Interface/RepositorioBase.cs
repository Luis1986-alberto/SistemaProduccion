using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Interface
{
    public class RepositorioBase<T> : IRepositori<T> where T : class
    {
        private Inicio principal = new Inicio();
        private string CadenaConexion;

        public RepositorioBase()
        {
            principal.LeerConfiguracion();
            CadenaConexion = principal.CadenaConexion;
        }

        public bool Actualizar(T entidad)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.Update(entidad);
                conexionSql.Close();
                return result;
            }
        }

        public int Agregar(T entidad)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.Insert(entidad);
                conexionSql.Close();
                return result;
            }
        }

        public bool Eliminar(T entidad)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.Delete(entidad);
                conexionSql.Close();
                return result;
            }
        }

        public IEnumerable<T> FiltroPorUnCampo(IPredicate predicado)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.GetList<T>(predicado);
                conexionSql.Close();
                return result;
            }
        }

        public IEnumerable<T> Listar()
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.GetList<T>();
                conexionSql.Close();
                return result;
            }
        }
        public IEnumerable<T> ListarPorConsulta(string consulta)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.Query<T>(consulta);
                conexionSql.Close();
                return result;
            }
        }
        public T TraerPorId(int id)
        {
            using (var conexionSql = new SqlConnection(CadenaConexion))
            {
                conexionSql.Open();
                var result = conexionSql.Get<T>(id);
                conexionSql.Close();
                return result;
            }
        }


    }
}
