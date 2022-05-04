using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aConcepto_CD
    {
        public static readonly LG_aConcepto_CD _Instancia = new LG_aConcepto_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        public static LG_aConcepto_CD Instancia
        { get { return LG_aConcepto_CD._Instancia; } }

        public LG_aConcepto_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aConcepto> Lista_Concepto()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdConcepto, Tipo_Concepto from LG_aConcepto ";
                    return ConexionSQL.Query<LG_aConcepto>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public LG_aConcepto TraerPorIdConcepto(Int32 idconcepto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Select IdConcepto, Tipo_Concepto from LG_aConcepto where IdConcepto = @id ";
                    return ConexionSQL.QueryFirst<LG_aConcepto>(sql, new { id = idconcepto });
                }
            }
            catch(Exception ex)
            { throw new Exception("error al Listar", ex); }
        }

        public string Agregar_Concepto(LG_aConcepto concepto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into LG_aConcepto (Tipo_Concepto) value (@tipo_concepto) ";
                    ConexionSQL.Execute(sqlinsert, new { tipo_concepto = concepto.Tipo_Concepto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_Concepto(LG_aConcepto concepto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update LG_aConcepto set Tipo_Concepto = @tipo_concepto where IdConcepto = @id ";
                    ConexionSQL.ExecuteScalar(sqlupdate, new { id = concepto.IdConcepto, descripcion_claseservicio = concepto.Tipo_Concepto });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Actualizar", Ex); }
        }


        public string Eliminar_Concepto(Int32 idconcepto)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete LG_aConcepto where IdConcepto = @id ";
                    ConexionSQL.Execute(sqldelete, new { id = idconcepto });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al eliminar", ex); }
        }


    }
}
