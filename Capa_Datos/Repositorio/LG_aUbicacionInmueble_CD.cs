using Capa_Datos.Interface;
using Capa_Entidades.Tablas;
using Dapper;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class LG_aUbicacionInmueble_CD : IRepositori<LG_aUbicacionInmueble>
    {
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        public static readonly LG_aUbicacionInmueble_CD _Instancia = new LG_aUbicacionInmueble_CD();

        public static LG_aUbicacionInmueble_CD Instancia
        { get { return LG_aUbicacionInmueble_CD._Instancia; } }

        public LG_aUbicacionInmueble_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public String Agregar(LG_aUbicacionInmueble entidad)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aUbicacionInmueble (Nombre_Distrito) values (@nombre_distrito) ";
                    ConexionSQL.Execute(sqlinsert, new { nombre_distrito = entidad.Nombre_Distrito });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al insertar", Ex); }
        }

        public String Actualizar(LG_aUbicacionInmueble entidad)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aUbicacionInmueble set Nombre_Distrito = @nombre_distrito where IdUbicacionInmueble = @id ";
                    ConexionSQL.Execute(sqlinsert, new { id = entidad.IdUbicacionInmueble, nombre_distrito = entidad.Nombre_Distrito });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public String Eliminar(Int32 idubicacioninmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "delete LG_aUbicacionInmueble where IdUbicacionInmueble = @id ";
                    ConexionSQL.Execute(sqlinsert, new { id = idubicacioninmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar ", ex); }
        }

        public LG_aUbicacionInmueble TraerPorId(Int32 id)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUbicacionInmueble, Nombre_Distrito from LG_aUbicacionInmueble where IdUbicacionInmueble = @id";
                    return ConexionSQL.QueryFirst<LG_aUbicacionInmueble>(sql, new { id = id });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al traer ", ex); }
        }

        public IEnumerable<LG_aUbicacionInmueble> Listar()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUbicacionInmueble, Nombre_Distrito from LG_aUbicacionInmueble";
                    return ConexionSQL.Query<LG_aUbicacionInmueble>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public IEnumerable<LG_aUbicacionInmueble> FiltroPorUnCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            {
                ConexionSQL.Open();
                var result = ConexionSQL.GetList<LG_aUbicacionInmueble>(predicado);
                ConexionSQL.Close();
                return result;
            }
        }

    }
}
