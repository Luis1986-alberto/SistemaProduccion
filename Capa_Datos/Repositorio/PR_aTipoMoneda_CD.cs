using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoMoneda_CD
    {
        public static readonly PR_aTipoMoneda_CD _Instancia = new PR_aTipoMoneda_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoMoneda_CD Instancia
        { get { return PR_aTipoMoneda_CD._Instancia; } }

        public PR_aTipoMoneda_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoMoneda> Lista_TipoMoneda()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMoneda, Tipo_Moneda, Sigla from PR_aTipoMoneda";
                    return conexionsql.Query<PR_aTipoMoneda>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoMoneda> Traer_TipoMOnedaPorId(Int32 idtipomoneda)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMoneda, Tipo_Moneda, Sigla from PR_aTipoMoneda where IdTipoMoneda = @id";
                    return conexionsql.Query<PR_aTipoMoneda>(sql, new { id = idtipomoneda });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoMoneda(PR_aTipoMoneda tipomoneda)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoMoneda (Tipo_Moneda, Sigla) values(@tipo_moneda, @sigla)";
                    conexionsql.ExecuteScalar(sqlinsert, new { tipo_moneda = tipomoneda.Tipo_Moneda, sigla = tipomoneda.Sigla });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoMoneda(PR_aTipoMoneda tipomoneda)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoMoneda set Tipo_Moneda = @tipo_moneda, Sigla = @sigla where IdTipoMoneda = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipomoneda.IdTipoMoneda, tipo_moneda = tipomoneda.Tipo_Moneda, sigla = tipomoneda.Sigla });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMoneda(Int32 idtipomoneda)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoMoneda where IdTipoMoneda = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipomoneda });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
