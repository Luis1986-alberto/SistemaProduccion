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
    public class LG_aInmueble_CD
    {
        public static readonly LG_aInmueble_CD _Instancia = new LG_aInmueble_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aInmueble_CD Instancia
        { get { return LG_aInmueble_CD._Instancia; } }

        public LG_aInmueble_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aInmueble>Lista_Inmuebles()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdInmueble, Codigo_Predio, Direccion_Predial from LG_aInmueble ";
                    return ConexionSQL.Query<LG_aInmueble>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al listar ", Ex);}
        }

        public LG_aInmueble TraerIdInmueble(Int32 idinmueble)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdInmueble, Codigo_Predio, Direccion_Predial from LG_aInmueble where IdInmueble = @id ";
                    return ConexionSQL.QueryFirst<LG_aInmueble>(sql, new { id = idinmueble });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar ", Ex); }
        }

        public string Agregar_Inmueble(LG_aInmueble inmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aInmueble (Codigo_Predio, Direccion_Predial) values (@codigo_predio, @direccion_predial)";
                    conexionsql.ExecuteScalar(sqlinsert, new {codigo_predio = inmueble.Codigo_Predio, direccion_predial = inmueble.Direccion_Predial});
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Inmueble(LG_aInmueble inmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aInmueble set Codigo_Predio = @codigo_predio, Direccion_Predial = @direccion_predial where IdInmueble = @id ";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                                                                id = inmueble.IdInmueble, ncodigo_predio = inmueble.Codigo_Predio, 
                                                                direccion_predial = inmueble.Direccion_Predial
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Eliminar_Inmueble(Int32 idinmueble)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aInmueble where IdInmueble = @id ";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idinmueble });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }


    }
}
