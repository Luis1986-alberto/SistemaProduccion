using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoTratado_CD
    {
        public static readonly PR_aTipoTratado_CD _Instancia = new PR_aTipoTratado_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoTratado_CD Instancia
        { get { return PR_aTipoTratado_CD._Instancia; } }

        public PR_aTipoTratado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoTratado>Lista_TipoTratado()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = " select IdTipoTratado, Tipo_Tratado From PR_aTipoTratado ";
                    return conexionsql.Query<PR_aTipoTratado>(sql);
                }
            }
            catch(Exception ex) { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aTipoTratado>Lista_TipoTratadoPorId(Int32 idtipotratado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = " select IdTipoTratado, Tipo_Tratado From PR_aTipoTratado where IdTipoTratado = @id ";
                    return conexionsql.Query<PR_aTipoTratado>(sql, new { id = idtipotratado } );
                }
            }
            catch(Exception ex) { throw new Exception("Error al listar", ex); }
        }


        public string Agregar_TipoTratado(PR_aTipoTratado tipotratado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoTratado (Tipo_Tratado) values(@tipo_tratado)";
                    conexionsql.ExecuteScalar(sqlinsert, new { tipo_tratado = tipotratado.Tipo_Tratado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoTratado(PR_aTipoTratado tipotratado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoTratado set Tipo_Tratado = @tipo_tratado where IdTipoTratado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipotratado.IdTipoTratado, tipo_tratado = tipotratado.Tipo_Tratado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoTratado(Int32 idtipotratado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoTratado where IdTipoTratado = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipotratado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
