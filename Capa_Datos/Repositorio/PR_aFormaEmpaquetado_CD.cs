using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aFormaEmpaquetado_CD
    {
        public static readonly PR_aFormaEmpaquetado_CD _Instancia = new PR_aFormaEmpaquetado_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aFormaEmpaquetado_CD Instancia
        { get { return PR_aFormaEmpaquetado_CD._Instancia; } }

        public PR_aFormaEmpaquetado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aFormaEmpaquetado> Lista_FormaEmpaquetado()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFormaEmpaquetado, Detalle_Empaquetado from PR_aFormaEmpaquetado";
                    return conexionsql.Query<PR_aFormaEmpaquetado>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aFormaEmpaquetado> Traer_FormaEmpaquetadoPorId(Int32 idformaempaquetado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdFormaEmpaquetado, Detalle_Empaquetado from PR_aFormaEmpaquetado where IdFormaEmpaquetado = @id";
                    return conexionsql.Query<PR_aFormaEmpaquetado>(sql, new { id = idformaempaquetado });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_FormaEmpaquetado(PR_aFormaEmpaquetado aformaempaquetado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aFormaEmpaquetado (Detalle_Empaquetado) values(@detalle_empaquetado)";
                    conexionsql.ExecuteScalar(sqlinsert, new { detalle_empaquetado = aformaempaquetado.Detalle_Empaquetado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_FormaEmpaquetado(PR_aFormaEmpaquetado aformaempaquetado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aFormaEmpaquetado set Detalle_Empaquetado = @detalle_empaquetado where IdFormaEmpaquetado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = aformaempaquetado.IdFormaEmpaquetado, detalle_empaquetado = aformaempaquetado.Detalle_Empaquetado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_FormaEmpaquetado(Int32 idformaempaquetado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aFormaEmpaquetado where IdFormaEmpaquetado = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idformaempaquetado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
