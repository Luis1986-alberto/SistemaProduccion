using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEmpaquetado_CD
    {
        public static readonly PR_aEmpaquetado_CD _Instancia = new PR_aEmpaquetado_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aDerivadoColor_CD Instancia
        { get { return PR_aDerivadoColor_CD._Instancia; } }

        public PR_aEmpaquetado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEmpaquetado> Lista_Empaquetado()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEmpaquetado, Descripcion from PR_aEmpaquetado";
                    return conexionsql.Query<PR_aEmpaquetado>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aEmpaquetado> Traer_EmpaquetadoPorId(Int32 idempaquetado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEmpaquetado, Descripcion from PR_aEmpaquetado where IdEmpaquetado = @id";
                    return conexionsql.Query<PR_aEmpaquetado>(sql, new { id = idempaquetado });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Empaquetado(PR_aEmpaquetado empaquetado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aEmpaquetado (Descripcion) values (@Descripcion)";
                    conexionsql.Execute(sqlinsert, new {descripcion = empaquetado.Descripcion });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Empaquetado(PR_aEmpaquetado empaquetado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aEmpaquetado set Descripcion = @descripcion where IdEmpaquetado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = empaquetado.IdEmpaquetado, descripcion = empaquetado.Descripcion});
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Empaquetador(Int32 idempaquetado)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEmpaquetado where IdEmpaquetado = @idempaquetado";
                    conexionsql.ExecuteScalar(sqldelete, new { idempaquetado = idempaquetado });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

        
    }
}
