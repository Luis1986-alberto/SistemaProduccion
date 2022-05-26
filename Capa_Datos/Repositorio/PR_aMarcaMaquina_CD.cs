using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aMarcaMaquina_CD
    {
        public static readonly PR_aMarcaMaquina_CD _Instancia = new PR_aMarcaMaquina_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aMarcaMaquina_CD Instancia
        { get { return PR_aMarcaMaquina_CD._Instancia; } }

        public PR_aMarcaMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aMarcaMaquina> Lista_MarcaMaquina()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaquina, Descripcion_MarcaMaquina, Abreviatura_MarcaMaquina from PR_aMarcaMaquina";
                    return conexionsql.Query<PR_aMarcaMaquina>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aMarcaMaquina> Traer_MarcaMaquinaPorId(Int32 idmarcamaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMarcaMaquina, Descripcion_MarcaMaquina, Abreviatura_MarcaMaquina from PR_aMarcaMaquina where IdMarcaMaquina = @id";
                    return conexionsql.Query<PR_aMarcaMaquina>(sql, new { id = idmarcamaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_MarcaMaquina(PR_aMarcaMaquina marcamaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aMarcaMaquina (Descripcion_MarcaMaquina, Abreviatura_MarcaMaquina) values (@descripcion_marcamaquina, @abreviatura_marcamaquina)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_marcamaquina = marcamaquina.Descripcion_MarcaMaquina, abreviatura_marcamaquina = marcamaquina.Abreviatura_MarcaMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_MarcaMaquina(PR_aMarcaMaquina marcamaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aMarcaMaquina set Descripcion_MarcaMaquina = @descripcion_marcamaquina, Abreviatura_MarcaMaquina = @abreviatura_marcamaquina where IdMarcaMaquina = @id";
                    conexionsql.ExecuteScalar(sqledit, new { id = marcamaquina.IdMarcaMaquina, descripcion_marcamaquina = marcamaquina.Descripcion_MarcaMaquina, abreviatura_marcamaquina = marcamaquina.Abreviatura_MarcaMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_MarcaMaquina(Int32 idmarcamaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aMarcaMaquina where IdMarcaMaquina = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmarcamaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }




    }
}
