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
    public class LG_aEstadoInmueble_CD
    {
        public static readonly LG_aEstadoInmueble_CD _Instancia = new LG_aEstadoInmueble_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aEstadoInmueble_CD Instancia
        { get { return LG_aEstadoInmueble_CD._Instancia; } }

        public LG_aEstadoInmueble_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }


        public IEnumerable<LG_aEstadoInmueble>Lista_estadoInmueble()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdEstadoInmueble, Estado_Inmueble from LG_aEstadoInmueble ";
                    return ConexionSQL.Query<LG_aEstadoInmueble>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al listar", Ex);}
        }


        public LG_aEstadoInmueble TraerporIDEstadoInmueble(Int32 idestadoinmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdEstadoInmueble, Estado_Inmueble from LG_aEstadoInmueble where IdEstadoInmueble =@id ";
                    return ConexionSQL.QueryFirst<LG_aEstadoInmueble>(sql, new { id = idestadoinmueble });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public string Agregar_EstadoInmueble(LG_aEstadoInmueble estadoinmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aEstadoInmueble (Estado_Inmueble) values (@estado_inmueble)";
                    conexionsql.ExecuteScalar(sqlinsert, new {estado_inmueble = estadoinmueble.Estado_Inmueble});
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_EstadoInmueble(LG_aEstadoInmueble estadoinmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aEstadoInmueble set  Estado_Inmueble = @estado_inmueble where IdEstadoInmueble = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {id = estadoinmueble.IdEstadoInmueble, estado_inmueble = estadoinmueble.Estado_Inmueble});
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Estadoinmueble(Int32 idestadoinmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aEstadoInmueble where IdEstadoInmueble = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idestadoinmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

    }
}
