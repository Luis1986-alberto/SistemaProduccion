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
    public class LG_aTipoProveedor_CD
    {
        public static readonly LG_aTipoProveedor_CD _Instancia = new LG_aTipoProveedor_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aTipoProveedor_CD Instancia
        { get { return LG_aTipoProveedor_CD._Instancia; } }

        public LG_aTipoProveedor_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoProveedor>Lista_TipoProveedor()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoProveedor, Tipo_Proveedor from LG_aTipoProveedor";
                    return ConexionSQL.Query<LG_aTipoProveedor>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("ERROR AL LISTAR", Ex);}
        }

        public LG_aTipoProveedor TraerPorIdTipoProveedor(Int32 idtipoproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoProveedor, Tipo_Proveedor from LG_aTipoProveedor where IdTipoProveedor = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoProveedor>(sql, new { id = idtipoproveedor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERROR AL LISTAR", Ex); }
        }

        public string Agregar_TipoProveedor(LG_aTipoProveedor tipoproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoProveedor (Tipo_Proveedor) values (@tipo_proveedor)";
                    ConexionSQL.Execute(sqlinsert, new { tipo_proveedor = tipoproveedor.Tipo_Proveedor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            {throw new Exception("ERROR AL AGREGAR", ex);}
        }

        public string Actualizar_TipoProveedor(LG_aTipoProveedor tipoproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoProveedor set Tipo_Proveedor =  @tipo_proveedor where IdTipoProveedor = @id";
                    ConexionSQL.Execute(sqlupdate, new {id = tipoproveedor.IdTipoProveedor, tipo_proveedor = tipoproveedor.Tipo_Proveedor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("ERROR AL AGREGAR", ex); }
        }

        public string Eliminar_TipoProveedor(Int32 idtipoproveedor)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aTipoProveedor where IdTipoProveedor = @id";
                    ConexionSQL.Execute(sqlupdate, new { id = idtipoproveedor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("ERROR AL AGREGAR", ex); }
        }

        public IEnumerable<LG_aTipoProveedor> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoProveedor>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
