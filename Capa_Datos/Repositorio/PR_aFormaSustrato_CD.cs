using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aFormaSustrato_CD
    {
        public static readonly PR_aFormaSustrato_CD _Instancia = new PR_aFormaSustrato_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aFormaSustrato_CD Instancia
        { get { return PR_aFormaSustrato_CD._Instancia; } }

        public PR_aFormaSustrato_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aFormaSustrato> Lista_FormaSustrato()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFormaSustrato, Descripcion_Forma from PR_aFormaSustrato";
                    return conexionsql.Query<PR_aFormaSustrato>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aFormaSustrato> Traer_FormaSustratoPorId(Int32 idformasustrato)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFormaSustrato, Descripcion_Forma from PR_aFormaSustrato where IdFormaSustrato = @id";
                    return conexionsql.Query<PR_aFormaSustrato>(sql, new { id = idformasustrato });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_FormaSustrato(PR_aFormaSustrato formasustrato)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aFormaSustrato (Descripcion_Forma) values(@descripcion_forma)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_forma = formasustrato.Descripcion_Forma });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_FormaSustrato(PR_aFormaSustrato formasustrato)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aFormaSustrato set Descripcion_Forma = @descripcion_forma where IdFormaSustrato = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = formasustrato.IdFormaSustrato, descripcion_forma = formasustrato.Descripcion_Forma });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_FormaSustrato(Int32 idformasustrato)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aFormaSustrato where IdFormaSustrato = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idformasustrato });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }



    }
}
