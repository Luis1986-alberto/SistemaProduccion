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
    public class LG_aTipoTrabajoMaquina_CD
    {
        public static readonly LG_aTipoTrabajoMaquina_CD _Instancia = new LG_aTipoTrabajoMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aTipoTrabajoMaquina_CD Instancia
        { get { return LG_aTipoTrabajoMaquina_CD._Instancia; } }

        public LG_aTipoTrabajoMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoTrabajoMaquina> Lista_TipotrabajoMaquina()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTrabajoMaquina, Descripcion_TrabajoMaquina from LG_aTipoTrabajoMaquina ";
                    return ConexionSQL.Query<LG_aTipoTrabajoMaquina>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERROR AL LISTAR", Ex); }
        }

        public LG_aTipoTrabajoMaquina TraerPorIdtrabajoMaquina(Int32 idtrabajomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTrabajoMaquina, Descripcion_TrabajoMaquina from LG_aTipoTrabajoMaquina where IdTrabajoMaquina = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoTrabajoMaquina>(sql, new { id = idtrabajomaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERROR AL LISTAR", Ex); }
        }

        public string Agregar_TipoTrabajoMaquina(LG_aTipoTrabajoMaquina tipotrabajomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoTrabajoMaquina (Descripcion_TrabajoMaquina) values (@descripcion_trabajomaquina) ";
                    ConexionSQL.Execute(sqlinsert, new { descripcion_trabajomaquina = tipotrabajomaquina.Descripcion_TrabajoMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_TipoTrabajoMaquina(LG_aTipoTrabajoMaquina tipotrabajomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoTrabajoMaquina set Descripcion_TipoServicio = @descripcion_tiposervicio where IdTrabajoMaquina = @id ";
                    ConexionSQL.Execute(sqlupdate, new {id = tipotrabajomaquina.IdTrabajoMaquina, descripcion_tiposervicio = tipotrabajomaquina.Descripcion_TrabajoMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Eliminar_TipoTrabajoMaquina(Int32 idtipotrabajomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete LG_aTipoTrabajoMaquina where IdTrabajoMaquina = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idtipotrabajomaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            {throw new Exception("Error al Eliminar", Ex);}
        }

        public IEnumerable<LG_aTipoTrabajoMaquina> FiltroPorunCampo(IPredicate predicado)
        {
            var ConexionSQL = new SqlConnection(cadenaconexion);
            ConexionSQL.Open();
            var result = ConexionSQL.GetList<LG_aTipoTrabajoMaquina>(predicado);
            ConexionSQL.Close();
            return result;
        }

    }
}
