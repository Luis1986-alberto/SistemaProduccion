using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class MP_aTipoCompraMaterial_CD
    {
        public static readonly MP_aTipoCompraMaterial_CD _Instancia = new MP_aTipoCompraMaterial_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        private static MP_aTipoCompraMaterial_CD Instancia
        { get { return MP_aTipoCompraMaterial_CD._Instancia; } }

        public MP_aTipoCompraMaterial_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<MP_aTipoCompraMaterial> Listar_TipoCompraMaterial()
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoCompraMaterial, Descripcion_TipoCompra from MP_aTipoCompraMaterial";
                    return ConexionSql.Query<MP_aTipoCompraMaterial>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Listar", Ex); }
        }

        public MP_aTipoCompraMaterial TraerPorIdTipoCompraMaterial(Int32 idtipocompramaterial)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoCompraMaterial, Descripcion_TipoCompra from MP_aTipoCompraMaterial where IdTipoCompraMaterial = @id";
                    return ConexionSQL.QueryFirst<MP_aTipoCompraMaterial>(sql, new { id = idtipocompramaterial });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por Id", Ex); }
        }

        public String Agregar(MP_aTipoCompraMaterial tipocompramaterial)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var SqlInsert = "Insert Into MP_aTipoCompraMaterial (Descripcion_TipoCompra) values (@descripcion_tipocompra) ";
                    ConexionSql.Execute(SqlInsert, new { descripcion_tipocompra = tipocompramaterial.Descripcion_TipoCompra });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Ingresar", Ex); }
        }

        public String Actualizar(MP_aTipoCompraMaterial tipocompramaterial)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlUpdate = "Update MP_aTipoCompraMaterial set Descripcion_TipoCompra = @descripcion_tipocompra where IdTipoCompraMaterial = @id ";
                    ConexionSql.Execute(sqlUpdate, new { id = tipocompramaterial.IdTipoCompraMaterial, descripcion_tipocompra = tipocompramaterial.Descripcion_TipoCompra });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERROR AL ACTUALIZAR", Ex); }
        }

        public String Eliminar(Int32 idTipoCompraMaterial)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aTipoCompraMaterial where IdTipoCompraMaterial = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idTipoCompraMaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Eliminar", Ex); }
        }


    }
}
