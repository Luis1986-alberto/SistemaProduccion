using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aTipoSalida_CD
    {
        public static readonly LG_aTipoSalida_CD _Instancia = new LG_aTipoSalida_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_aTipoSalida_CD Instancia
        { get { return LG_aTipoSalida_CD._Instancia; } }

        public LG_aTipoSalida_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aTipoSalida> Lista_TipoSalida()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdTipoSalida, Nombre_TipoSalida from LG_aTipoSalida";
                    return conexionsql.Query<LG_aTipoSalida>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<LG_aTipoSalida> Traer_TipoSalidaPorId(Int32 idtiposalida)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoSalida, Nombre_TipoSalida from LG_aTipoSalida where IdTipoSalida = @id";
                    return conexionsql.Query<LG_aTipoSalida>(sql, new { id = idtiposalida });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoSalida(LG_aTipoSalida  tiposalidapt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aTipoSalida (Nombre_TipoSalida) values (@nombre_tiposalidapt)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tiposalidapt = tiposalidapt.Nombre_TipoSalida});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoSalida(LG_aTipoSalida tiposalidapt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aTipoSalida set Nombre_TipoSalida = @nombre_tiposalidatp where IdTipoSalida = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tiposalidapt.IdTipoSalida, nombre_tiposalidatp = tiposalidapt.Nombre_TipoSalida});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoSalidaPT(Int32 idtiposalidapt)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aTipoSalida where IdTipoSalida = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtiposalidapt });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       

    }
}
