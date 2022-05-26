using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aClaseServicioMaquina_CD
    {
        public static readonly LG_aClaseServicioMaquina_CD _Instancia = new LG_aClaseServicioMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aClaseServicioMaquina_CD instancia
        { get { return LG_aClaseServicioMaquina_CD._Instancia; } }

        public LG_aClaseServicioMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aClaseServicioMaquina> Lista_ClaseServicioMaquina()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdClaseServicioMaquina, Descripcion_ClaseServicio from LG_aClaseServicioMaquina ";
                    return ConexionSQL.Query<LG_aClaseServicioMaquina>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public LG_aClaseServicioMaquina TraerPorIdClaseServicioMaquina(Int32 idclaseserviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdClaseServicioMaquina, Descripcion_ClaseServicio from LG_aClaseServicioMaquina where IdClaseServicioMaquina = @id ";
                    return ConexionSQL.QueryFirst<LG_aClaseServicioMaquina>(sql, new { id = idclaseserviciomaquina });
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public string Agregar_ClaseServicioMaquina(LG_aClaseServicioMaquina claseserviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aClaseServicioMaquina (Descripcion_ClaseServicio) value (@descripcion_claseservicio) ";
                    ConexionSQL.Execute(sqlinsert, new { descripcion_claseservicio = claseserviciomaquina.Descripcion_ClaseServicio });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }


        public string Actualizar_ClaseServicioMaquina(LG_aClaseServicioMaquina claseserviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aClaseServicioMaquina set Descripcion_ClaseServicio = @descripcion_claseservicio where IdClaseServicioMaquina = @id ";
                    ConexionSQL.ExecuteScalar(sqlupdate, new { id = claseserviciomaquina.IdClaseServicioMaquina, descripcion_claseservicio = claseserviciomaquina.Descripcion_ClaseServicio });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Actualizar", Ex); }
        }


        public string Eliminar_ClaseServicioMaquina(Int32 idclaseserviciomaquina)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aClaseServicioMaquina where IdClaseServicioMaquina = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idclaseserviciomaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al eliminar", ex); }
        }

    }
}
