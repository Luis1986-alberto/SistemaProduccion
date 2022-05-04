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
    public class LG_aLinea_CD
    {
        public static readonly LG_aLinea_CD _Instancia = new LG_aLinea_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aLinea_CD Instancia
        { get { return LG_aLinea_CD._Instancia; } }

        public LG_aLinea_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aLinea> Lista_linea()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdLinea, Nombre_Linea, Codigo_Linea, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aLinea ";
                    return ConexionSQL.Query<LG_aLinea>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }


        public LG_aLinea TraerporIdLinea(Int32 idlinea)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdLinea, Nombre_Linea, Codigo_Linea, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aLinea where IdLinea = @id ";
                    return ConexionSQL.QueryFirst<LG_aLinea>(sql, new { id = idlinea });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public string Agregar_Linea(LG_aLinea linea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aLinea (Nombre_Linea, Codigo_Linea, IdUsuario_PC,  IdUsuario) values " +
                                                            "(@nombre_linea, @codigo_linea, @idusuario_pc, @idusuario)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                                                                nombre_linea = linea.Nombre_Linea, codigo_linea = linea.Codigo_Linea,
                                                                idusuario_pc = Environment.UserName, idusuario = linea.IdUsuario
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Linea(LG_aLinea linea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aLinea set  Nombre_Linea = @nombre_linea, Codigo_Linea = @codigo_linea, IdUsuario_PC = @idusuario_pc, " +
                                    " IdUsuario = @idusuario  where IdLinea = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = linea.IdLinea, nombre_linea = linea.Nombre_Linea, codigo_linea = linea.Codigo_Linea,
                                                                idusuario_pc = Environment.UserName, idusuario = linea.IdUsuario
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Linea(Int32 idlinea)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aLinea where IdLinea = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idlinea });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        public IEnumerable<LG_aLinea>FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aLinea>(predicado);
            ConexionSQL.Close();
            return result;
        }
    }
}
