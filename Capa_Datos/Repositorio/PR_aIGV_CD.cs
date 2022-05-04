using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aIGV_CD
    {
        public static readonly PR_aIGV_CD _Instancia = new PR_aIGV_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aIGV_CD Instancia
        { get { return PR_aIGV_CD._Instancia; } }

        public PR_aIGV_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aIGV> Lista_Igv()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdIGV, Porcentaje, Flag_Activo from PR_aIGV";
                    return conexionsql.Query<PR_aIGV>(sql);
                }
            }
            catch(Exception ex) { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aIGV> Traer_IGVPorId(Int32 idigv)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdIGV, Porcentaje, Flag_Activo from PR_aIGV where IdIGV = @id";
                    return conexionsql.Query<PR_aIGV>(sql, new { id = idigv });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Igv(PR_aIGV aIgv)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aIGV (Porcentaje, Flag_Activo ) values (@porcentaje, @flag_activo)";
                    conexionsql.ExecuteScalar(sqlinsert, new { porcentaje = aIgv.Porcentaje, flag_activo = aIgv.Flag_Activo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_IGV(PR_aIGV aIgv)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aIGV set Porcentaje = @porcentaje, Flag_Activo = @flag_activo where IdIGV = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = aIgv.IdIGV, porcentaje = aIgv.Porcentaje, flag_activo = aIgv.Flag_Activo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public String Eliminar_IGV(Int32 idigv)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aIGV where IdIGV = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idigv });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de eliminar", ex); }
        }

    }
}
