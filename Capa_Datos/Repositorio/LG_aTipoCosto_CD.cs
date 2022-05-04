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
    public class LG_aTipoCosto_CD
    {
        public static readonly LG_aTipoCosto_CD _Instancia = new LG_aTipoCosto_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aTipoCosto_CD Instancia
        { get { return LG_aTipoCosto_CD._Instancia; } }

        public LG_aTipoCosto_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoCosto> Lista_TipoCosto()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoCosto, Nombre_TipoCosto, Codigo_TipoCosto, Fecha_Servidor, IdUsuario_PC, IdUsuario from LG_aTipoCosto ";
                    return ConexionSQL.Query<LG_aTipoCosto>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public LG_aTipoCosto TraerPorIdTipoCosto(Int32 idtipocosto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoCosto, Nombre_TipoCosto, Codigo_TipoCosto, IdUsuario_PC, IdUsuario from LG_aTipoCosto where IdTipoCosto = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoCosto>(sql, new { id = idtipocosto });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer por ID", Ex);}
        }

        public string Agregar_TipoCosto(LG_aTipoCosto tipocosto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoCosto (Nombre_TipoCosto, Codigo_TipoCosto, IdUsuario_PC, IdUsuario ) values " +
                                    "(@nombre_tipocosto, @codigo_tipocosto, @idusuario_pc, @idusuario) ";
                    ConexionSQL.Execute(sqlinsert, new {
                                                        nombre_tipocosto = tipocosto.Nombre_TipoCosto,
                                                        codigo_tipocosto = tipocosto.Codigo_TipoCosto,
                                                        idusuario_pc = Environment.UserName,
                                                        idusuario = tipocosto.IdUsuario
                                                        });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Agregar", Ex);}
        }

        public string Actualizar_TipoCosto(LG_aTipoCosto tipocosto)
        {
            try
            {
                using (var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoCosto set Nombre_TipoCosto = @nombre_tipocosto, Codigo_TipoCosto = @codigo_tipocosto, " +
                                    " IdUsuario_PC = @idusurio_pc, idusuario = @idusuario where IdTipoCosto = @id ";
                    ConexionSql.Execute(sqlupdate, new {
                                                            id = tipocosto.IdTipoCosto, nombre_tipocosto = tipocosto.Nombre_TipoCosto,
                                                            codigo_tipocosto = tipocosto.Codigo_TipoCosto, idusuario_pc = Environment.UserName,
                                                            idusuario = tipocosto.IdUsuario
                                                        });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Actualizar", Ex);}
        }

        public string Eliminar_TipoCosto(Int32 idtipocosto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete LG_aTipoCosto where IdTipoCosto = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idtipocosto });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex);}
        }

        public IEnumerable<LG_aTipoCosto> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoCosto>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
