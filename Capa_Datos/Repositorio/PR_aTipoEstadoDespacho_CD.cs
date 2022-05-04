using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoEstadoDespacho_CD
    {
        public static readonly PR_aTipoEstadoDespacho_CD _Instancia = new PR_aTipoEstadoDespacho_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoEstadoDespacho_CD Instancia
        { get { return PR_aTipoEstadoDespacho_CD._Instancia; } }

        public PR_aTipoEstadoDespacho_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoEstadoDespacho> Lista_TipoEstadoDespacho()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoEstadoDespacho, TipoEstadoDespacho from PR_aTipoEstadoDespacho";
                    return conexionsql.Query<PR_aTipoEstadoDespacho>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoEstadoDespacho> Traer_TipoEstadoDespachoPorId(Int32 idtipoestado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoEstadoDespacho, TipoEstadoDespacho from PR_aTipoEstadoDespacho where IdTipoEstadoDespacho = @id";
                    return conexionsql.Query<PR_aTipoEstadoDespacho>(sql, new { id = idtipoestado });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoEstadoDespacho(PR_aTipoEstadoDespacho tipoestadodespacho)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoEstadoDespacho (TipoEstadoDespacho) values(@tipodespacho)";
                    conexionsql.ExecuteScalar(sqlinsert, new { tipodespacho = tipoestadodespacho.TipoEstadoDespacho });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoDespacho(PR_aTipoEstadoDespacho tipoestadodespacho)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoEstadoDespacho set TipoEstadoDespacho = @tipoestadodespacho where IdTipoEstadoDespacho = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipoestadodespacho.IdTipoEstadoDespacho, tipoestadodespacho = tipoestadodespacho.TipoEstadoDespacho });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoDespacho(Int32 idtipoestado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoEstadoDespacho where IdTipoEstadoDespacho = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipoestado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

       
    }
}
