using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class LG_aAño_CD
    {
        public static readonly LG_aAño_CD _Instancia = new LG_aAño_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static LG_aAño_CD Instancia
        { get { return LG_aAño_CD._Instancia; } }

        public LG_aAño_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<LG_aAño> Lista_aAños()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAño, Año from LG_aAño";
                    return conexionsql.Query<LG_aAño>(sql);
                }
            }
            catch(Exception ex) { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<LG_aAño> Traer_AñoPorId(Int32 idaño)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdAño, Año from LG_aAño where IdAño = @id";
                    return conexionsql.Query<LG_aAño>(sql, new { id = idaño });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Año(LG_aAño aAño)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aAño (Año) values (@año)";
                    conexionsql.ExecuteScalar(sqlinsert, new { año = aAño.Año });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Año(LG_aAño aAño)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update LG_aAño set Año = @año where Idaño = @idaño";
                    conexionsql.ExecuteScalar(sqlupdate, new { idaño = aAño.IdAño, año = aAño.Año });
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
                    var sqldelete = "delete LG_aAño where IdAño = @idaño";
                    conexionsql.ExecuteScalar(sqldelete, new { idaño = idaño });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de eliminar", ex); }
        }

    }
}
