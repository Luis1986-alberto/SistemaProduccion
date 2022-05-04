using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipoIngreso_CD
    {
        public static readonly LG_aTipoIngreso_CD _Instancia = new LG_aTipoIngreso_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_aTipoIngreso_CD Instancia
        { get { return LG_aTipoIngreso_CD._Instancia; } }

        public LG_aTipoIngreso_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoIngreso> Lista_TipoIngresos()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoIngreso, Nombre_TipoIngreso from LG_aTipoIngreso";
                    return conexionsql.Query<LG_aTipoIngreso>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<LG_aTipoIngreso> Traer_TipoIngresoPorId(Int32 idtipoingreso)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoIngreso, Nombre_TipoIngreso from LG_aTipoIngreso where IdTipoIngreso = @id";
                    return conexionsql.Query<LG_aTipoIngreso>(sql, new { id = idtipoingreso });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoIngreso(LG_aTipoIngreso tipoingreso)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoIngreso (Nombre_TipoIngreso) values (@nombre_tipoingreso)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tipoingreso = tipoingreso.Nombre_TipoIngreso });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoIngreso(LG_aTipoIngreso tipoingreso)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoIngreso set Nombre_TipoIngreso = @nombre_tipoingreso where IdTipoIngreso = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipoingreso.IdTipoIngreso, nombre_tipoingreso = tipoingreso.Nombre_TipoIngreso});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoIngreso(Int32 idtipofuelle)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aTipoIngreso where IdTipoIngreso = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipofuelle });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
