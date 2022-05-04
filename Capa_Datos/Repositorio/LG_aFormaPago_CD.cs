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
    public class LG_aFormaPago_CD
    {
        public static readonly LG_aFormaPago_CD _Instancia = new LG_aFormaPago_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;
        
        public static LG_aFormaPago_CD Instancia 
        { get { return LG_aFormaPago_CD._Instancia; } }


        public LG_aFormaPago_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aFormaPago> Lista_FormaPgo()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = " select IdFormaPago, Nombre_FormaPago, Dias from LG_aFormaPago ";
                    return ConexionSQL.Query<LG_aFormaPago>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Eror al Listar", Ex); }
        }

        public LG_aFormaPago TraerPorIdFormaPgo(Int32 idformapago)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = " select IdFormaPago, Nombre_FormaPago, Dias from LG_aFormaPago where IdFormaPago = @id ";
                    return ConexionSQL.QueryFirst<LG_aFormaPago>(sql, new { id = idformapago });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Eror al Listar", Ex); }
        }

        public string Agregar_FormaPago(LG_aFormaPago formapago)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aFormaPago (Nombre_FormaPago, Dias) values (@nombre_formapago, @dias)";
                    conexionsql.ExecuteScalar(sqlinsert, new {nombre_formapago = formapago.Nombre_FormaPago, dias = formapago.Dias});
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_FormaPago(LG_aFormaPago formapago)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aFormaPago set Nombre_FormaPago = @nombre_formapago, Dias = @dias where IdFormaPago = @id ";
                    conexionsql.ExecuteScalar(sqlinsert, new {id = formapago.IdFormaPago, nombre_formapago = formapago.Nombre_FormaPago, dias = formapago.Dias });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Eliminar_FormaPago(Int32 idformapago)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aFormaPago where IdFormaPago = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idformapago });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

    }
}
