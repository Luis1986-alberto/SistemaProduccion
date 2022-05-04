using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aMezcladora_CD
    {
        public static readonly PR_aMezcladora_CD _Instancia = new PR_aMezcladora_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aMezcladora_CD Instancia
        { get { return PR_aMezcladora_CD._Instancia; } }

        public PR_aMezcladora_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aMezcladora> Lista_Mezcladora()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMezcladora, Nombre_Mezcladora, Capacidad_Mezcladora from PR_aMezcladora";
                    return conexionsql.Query<PR_aMezcladora>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }

        public IEnumerable<PR_aMezcladora> Traer_MezcladoraPorId(Int32 idmezcladora)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdMezcladora, Nombre_Mezcladora, Capacidad_Mezcladora from PR_aMezcladora where IdMezcladora = @id";
                    return conexionsql.Query<PR_aMezcladora>(sql, new { id = idmezcladora });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Mezcladora(PR_aMezcladora mezcladora)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aMezcladora (Nombre_Mezcladora, Capacidad_Mezcladora) values (@nombre_mezcladora, @capacidad_mezclarora)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_mezcladora = mezcladora.Nombre_Mezcladora, capacidad_mezclarora = mezcladora.Capacidad_Mezcladora });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_Mezcladora(PR_aMezcladora mezcladora)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aMezcladora set Nombre_Mezcladora = @nombre_mezcladora, Capacidad_Mezcladora = @capacidad_mezclarora where IdMezcladora = @id";
                    conexionsql.ExecuteScalar(sqledit, new {id = mezcladora.IdMezcladora, nombre_mezcladora = mezcladora.Nombre_Mezcladora, capacidad_mezclarora = mezcladora.Capacidad_Mezcladora });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_Mezcladora(Int32 idmezcladora)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aMezcladora where IdMezcladora = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idmezcladora });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }

        
    }
}
