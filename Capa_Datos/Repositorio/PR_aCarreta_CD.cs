using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aCarreta_CD
    {
        public static readonly PR_aCarreta_CD _Instancia = new PR_aCarreta_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aCarreta_CD Instancia
        {get{ return PR_aCarreta_CD._Instancia; } }

        public PR_aCarreta_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aCarreta>Lista_carretas()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCarreta, Pesos_Kilos from PR_aCarreta";
                   return conexionsql.Query<PR_aCarreta>(sql);
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al listar", ex);}
        }

        public IEnumerable<PR_aCarreta> Traer_CarretaPorId(Int32 idcarreta)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdCarreta, Pesos_Kilos from PR_aCarreta where IdCarreta = @id";
                    return conexionsql.Query<PR_aCarreta>(sql, new { id = idcarreta });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Carretas(PR_aCarreta carreta)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert into PR_aCarreta (Pesos_Kilos) values(@peso_kilos)";
                    conexionsql.ExecuteScalar(sqlinsert, new { peso_kilos = carreta.Pesos_Kilos });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            {throw new Exception("Error al agregar la carreta", ex);}
        }

        public string Actualizar_Carretas(PR_aCarreta carreta)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update PR_aCarreta set Pesos_Kilos = @peso_kilos where IdCarreta =@idcarreta";
                    conexionsql.ExecuteScalar(sqlinsert, new {idcarreta = carreta.IdCarreta,  peso_kilos = carreta.Pesos_Kilos });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al actualizar la carreta", ex); }
        }

        public string Eliminar_Carretas(Int32  idcarreta)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "delete PR_aCarreta where IdCarreta =@id";
                    conexionsql.ExecuteScalar(sqlinsert, new { id = idcarreta });
                    return "PROCESADO";
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al actualizar la carreta", ex); }
        }

       
    }
}
