using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class LG_aEstadoSolicitud_CD
    {
        public static readonly LG_aEstadoSolicitud_CD _Instancia = new LG_aEstadoSolicitud_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aEstadoSolicitud_CD Instancia
        { get { return LG_aEstadoSolicitud_CD._Instancia; } }

        public LG_aEstadoSolicitud_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aEstadoSolicitud> Lista_EstadoSolicitud()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdEstadoSolicitud, Descripcion_EstadoSolicitud from LG_aEstadoSolicitud ";
                    return ConexionSQL.Query<LG_aEstadoSolicitud>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }


        public LG_aEstadoSolicitud TraerporIDEstadoSolicitud(Int32 idestadosolicitud)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdEstadoSolicitud, Descripcion_EstadoSolicitud from LG_aEstadoSolicitud where IdEstadoSolicitud = @id ";
                    return ConexionSQL.QueryFirst<LG_aEstadoSolicitud>(sql, new { id = idestadosolicitud });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }


        public string Agregar_EstadoSolicitud(LG_aEstadoSolicitud estadosolicitud)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aEstadoSolicitud (Descripcion_EstadoSolicitud) values (@descripcion_estadosolicitud)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_estadosolicitud = estadosolicitud.Descripcion_EstadoSolicitud });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_EstadoSolicitud(LG_aEstadoSolicitud estadosolicitud)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aEstadoSolicitud set  Descripcion_EstadoSolicitud = @descripcion_estadosolicitud where IdEstadoSolicitud = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = estadosolicitud.IdEstadoSolicitud, 
                                                                descripcion_estadosolicitud = estadosolicitud.Descripcion_EstadoSolicitud
                                                              });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_EstadoSolicitud(Int32 idestadosolicitud)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aEstadoSolicitud where IdEstadoSolicitud = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idestadosolicitud });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

    }
}
