using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aPieImprenta_CD
    {
        public static readonly PR_aPieImprenta_CD _Instancia = new PR_aPieImprenta_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aPieImprenta_CD Instancia
        { get { return PR_aPieImprenta_CD._Instancia; } }

        public PR_aPieImprenta_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aPieImprenta> Lista_PieImprenta()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPieImprenta, Descripcion from PR_aPieImprenta";
                    return conexionsql.Query<PR_aPieImprenta>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aPieImprenta> Traer_PieImprentaPorId(Int32 idpieimprenta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPieImprenta, Descripcion from PR_aPieImprenta where IdPieImprenta = @id";
                    return conexionsql.Query<PR_aPieImprenta>(sql, new { id = idpieimprenta });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_PieImprenta(PR_aPieImprenta pieimprenta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aPieImprenta (Descripcion) values(@descripcion)";
                    conexionsql.Execute(sqlinsert, new { descripcion = pieimprenta.Descripcion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_PieImprenta(PR_aPieImprenta pieimprenta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aPieImprenta set Descripcion = @descripcion where IdPieImprenta = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = pieimprenta.IdPieImprenta, descripcion = pieimprenta.Descripcion });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_PieImprenta(Int32 idpieimprenta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aPieImprenta where IdPieImprenta = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idpieimprenta });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
