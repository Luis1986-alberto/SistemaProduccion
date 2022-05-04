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
    public class LG_aTipoServicioMaquina_CD
    {
        public static readonly LG_aTipoServicioMaquina_CD _Instancia = new LG_aTipoServicioMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aTipoServicioMaquina_CD Instancia
        { get { return LG_aTipoServicioMaquina_CD._Instancia; } }

        public LG_aTipoServicioMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoServicioMaquina>Lista_ServicioMaquina()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoServicio, Descripcion_TipoServicio from LG_aTipoServicioMaquina ";
                    return ConexionSQL.Query<LG_aTipoServicioMaquina>(sql);
                }
            }
            catch(Exception Ex)
            {throw new Exception("ERROR AL LISTAR", Ex);}
        }

        public LG_aTipoServicioMaquina TraerPorIdServicioMaquina(Int32 idserviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoServicio, Descripcion_TipoServicio from LG_aTipoServicioMaquina where IdTipoServicio = @id ";
                    return ConexionSQL.QueryFirst<LG_aTipoServicioMaquina>(sql, new { id = idserviciomaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("ERROR AL LISTAR", Ex); }
        }

        public string Agregar_ServicioMaquina(LG_aTipoServicioMaquina tiposerviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoServicioMaquina (Descripcion_TipoServicio) values (@descripcion_tiposervicio) ";
                    ConexionSQL.Execute(sqlinsert, new { descripcion_tiposervicio = tiposerviciomaquina.Descripcion_TipoServicio });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al Agregar", ex);}
        }

        public string Actualizar_ServicioMaquina(LG_aTipoServicioMaquina tiposerviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoServicioMaquina set Descripcion_TipoServicio = @descripcion_tiposervicio where IdTipoServicio = @id ";
                    ConexionSQL.Execute(sqlupdate, new {id = tiposerviciomaquina.IdTipoServicio,
                                                        descripcion_tiposervicio = tiposerviciomaquina.Descripcion_TipoServicio });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Eliminar_ServicioMaquina(Int32 idtiposerviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "Delete LG_aTipoServicioMaquina where IdTipoServicio = @id ";
                    ConexionSQL.Execute(sqldelete, new { id =idtiposerviciomaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

    }
}
