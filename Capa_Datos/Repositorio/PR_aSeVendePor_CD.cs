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
    public class PR_aSeVendePor_CD
    {
        private Inicio Principal = new Inicio();
        private string cadenaconexion = "";
        public static readonly PR_aSeVendePor_CD _Instancia = new PR_aSeVendePor_CD();

        public static PR_aSeVendePor_CD Instancia
        { get { return PR_aSeVendePor_CD._Instancia; } }

        public PR_aSeVendePor_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }

        public IEnumerable<PR_aSeVendePor>Lista_seVendePor()
        {
            try
            {
                using( var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdSevendepor, seVende_Por from PR_aSevendePor ";
                    return ConexionSQL.Query<PR_aSeVendePor>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);   }
        }

        public PR_aSeVendePor TraerPor_IdSeVendePor(byte idsevendepor)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdSevendepor, seVende_Por from PR_aSevendePor where IdSevendepor = @id";
                    return ConexionSql.QueryFirst<PR_aSeVendePor>(sql, new { id = idsevendepor });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer Por Id", Ex); }
        }

        public string Agregar_SeVende_Por(PR_aSeVendePor sevendepor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aSevendePor (SeVende_Por) Values (@sevende_por) ";
                    ConexionSQL.ExecuteScalar(sqlinsert, new { sevende_por = sevendepor.SeVende_Por });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al agregar", Ex); }
        }

        public string Actualizar_SeVende_Por (PR_aSeVendePor sevende_por)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aSevendePor set SeVende_Por = @sevende_por where IdSeVendePor = @id ";
                    ConexionSQL.ExecuteScalar(sqlupdate, new { id = sevende_por.IdSeVendePor, sevende_por = sevende_por.SeVende_Por });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception ("Error al Actualizar ", Ex);}
        }

        public String Eliminar_SeVende_Por (byte idsevendepor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete PR_aSevendePor where IdSeVendePor = @id ";
                    ConexionSQL.ExecuteScalar(sqldelete, new { id = idsevendepor });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception ("error al Eliminar ", Ex);}
        }


    }
}
