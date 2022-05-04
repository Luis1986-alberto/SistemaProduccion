using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aAño_CD
    {
        public static readonly PR_aAño_CD _Instancia = new PR_aAño_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aAño_CD Instancia
        { get { return PR_aAño_CD._Instancia; }}

        public PR_aAño_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aAño>Lista_aAños()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAño, Año from PR_aAño";
                    return conexionsql.Query<PR_aAño>(sql);
                }
            }
            catch(Exception ex){ throw new Exception("Error al listar", ex);}
        }

        public IEnumerable<PR_aAño> Traer_AñoPorId(Int32 idaño)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAño, Año from PR_aAño where IdAño = @id";
                    return conexionsql.Query<PR_aAño>(sql, new { id = idaño });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Año(PR_aAño aAño)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aAño (Año) values (@año)";
                    conexionsql.ExecuteScalar(sqlinsert, new { año = aAño.Año });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Año(PR_aAño aAño) 
        {
            try
            { 
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aAño set Año = @año where Idaño = @idaño";
                    conexionsql.ExecuteScalar(sqlupdate, new { idaño = aAño.IdAño, año = aAño.Año }) ;
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }
        
        public String Eliminar_Año(Int32 idaño)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aAño where IdAño = @idaño";
                    conexionsql.ExecuteScalar(sqldelete, new { idaño = idaño });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de eliminar", ex); }
        }

    }
}
