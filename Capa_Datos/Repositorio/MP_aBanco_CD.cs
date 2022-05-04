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
    public class MP_aBanco_CD
    {
        public static readonly MP_aBanco_CD _Instancia = new MP_aBanco_CD();
        public Inicio princpal = new Inicio();
        public string cadenaconexion = "";

        public static MP_aBanco_CD Instancia
        { get { return MP_aBanco_CD._Instancia; } }

        public MP_aBanco_CD()
        {
            princpal.LeerConfiguracion();
            cadenaconexion = princpal.CadenaConexion;
        }

        public IEnumerable<MP_aBanco> Lista_Bancos()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdBanco, Nombre_Banco, Abreviatura_Banco from MP_aBanco ";
                    return ConexionSQL.Query<MP_aBanco>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }


        public IEnumerable<MP_aBanco>Traer_BancoPorId(Int32 idbanco)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdBanco, Nombre_Banco, Abreviatura_Banco from MP_aBanco where IdBanco = @id";
                    return ConexionSQL.Query<MP_aBanco>(sql, new { id = idbanco });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Traer por Id", Ex);}
        }

        public string Agregar_Banco(MP_aBanco banco)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert into MP_aBanco (Nombre_Banco, Abreviatura_Banco) values (@nombre_banco, @abreviatura_banco) ";
                    ConexionSql.Execute(sqlinsert, new { nombre_banco = banco.Nombre_Banco, abreviatura_banco = banco.Abreviatura_Banco });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Agregar", Ex);}
        }

        public string Actualizar_Banco(MP_aBanco banco)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Insert into MP_aBanco set Nombre_Banco = @nombre_banco, Abreviatura_Banco = @abreviatura_banco where IdBanco = @id  ";
                    ConexionSql.Execute(sqlupdate, new {id = banco.IdBanco, nombre_banco = banco.Nombre_Banco, abreviatura_banco = banco.Abreviatura_Banco });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }

        public string Eliminar_Banco(Int32 idbanco)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "delete MP_aBanco  where IdBanco = @id ";
                    ConexionSql.Execute(sqlinsert, new { id = idbanco });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Agregar", Ex); }
        }
    }
}
