using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoSello_CD
    {
        public static readonly PR_aTipoSello_CD _Instancia = new PR_aTipoSello_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoSello_CD Instancia
        { get { return PR_aTipoSello_CD._Instancia; } }

        public PR_aTipoSello_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoSello> Lista_TipoSello()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoSello, Descripcion_TipoSello from PR_aTipoSello";
                    return conexionsql.Query<PR_aTipoSello>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoSello> Traer_TipoSelloPorId(Int32 idtiposello)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoSello, Descripcion_TipoSello from PR_aTipoSello where IdTipoSello = @id";
                    return conexionsql.Query<PR_aTipoSello>(sql, new { id = idtiposello });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoSello(PR_aTipoSello tiposello)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoSello (Descripcion_TipoSello) values (@descipcion_tiposello)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descipcion_tiposello = tiposello.Descripcion_TipoSello });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoSello(PR_aTipoSello tiposello)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoSello set Descripcion_TipoSello = @descripcion_tiposello where IdTipoSello = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tiposello.IdTipoSello, descripcion_tiposello = tiposello.Descripcion_TipoSello });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoSello(Int32 idtiposello)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoSello where IdTipoSello = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtiposello });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }



    }
}
