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
    public class LG_aPropietario_CD
    {
        public static readonly LG_aPropietario_CD _Instancia = new LG_aPropietario_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aPropietario_CD Instancia
        { get { return LG_aPropietario_CD._Instancia; } }

        public LG_aPropietario_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aPropietario>Lista_Propietarios()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdPropietario, Nombre_Completo from LG_aPropietario ";
                    return ConexionSQL.Query<LG_aPropietario>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Listar", Ex);}
        }

        public LG_aPropietario TraerPorIdPropietario(Int32 idpropietario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdPropietario, Nombre_Completo from LG_aPropietario where IdPropietario = @id ";
                    return ConexionSQL.QueryFirst<LG_aPropietario>(sql, new { id = idpropietario });
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al traer por Id", Ex);}
        }

        public string Agregar_Propietario(LG_aPropietario propietario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aPropietario (Nombre_Completo) values (@nombre_completo)";
                    ConexionSQL.Execute(sqlinsert, new { nombre_completo = propietario.Nombre_Completo });
                    return "PROCESADO"; 
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Agregar", Ex);}
        }

        public string Actualizar_Propietario(LG_aPropietario propietario)
        {
            try
            {
                using(var ConexionSql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aPropietario set Nombre_Completo = @nombre_completo where IdPropietario = @id ";
                    ConexionSql.Execute(sqlupdate, new { id = propietario.IdPropietario, nombre_completo = propietario.Nombre_Completo });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Actualizar", Ex);}
        }

        public String Eliminar_Propietario(Int32 idpropietario)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aPropietario where IdPropietario = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idpropietario });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex);}
        }

        public IEnumerable<LG_aPropietario> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aPropietario>(predicado);
            ConexionSQL.Close();
            return result;
        }


    }
}
