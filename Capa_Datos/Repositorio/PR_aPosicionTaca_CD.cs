using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class PR_aPosicionTaca_CD
    {
        public static readonly PR_aPosicionTaca_CD _Instancia = new PR_aPosicionTaca_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aPosicionTaca_CD Instancia
        { get { return PR_aPosicionTaca_CD._Instancia; } }

        public PR_aPosicionTaca_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aPosicionTaca>Lista_PosicionTaca()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPosicionTaca, Posicion_Taca from PR_aPosicionTaca ";
                    return conexionsql.Query<PR_aPosicionTaca>(sql);
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al listar", ex);}
        }

        public IEnumerable<PR_aPosicionTaca> Traer_PosicionTacaPorID(byte idposiciontaca)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdPosicionTaca, Posicion_Taca from PR_aPosicionTaca where IdPosicionTaca = @id";
                    return conexionsql.Query<PR_aPosicionTaca>(sql, new { id = idposiciontaca });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public String Agregar_PosicionTaca(PR_aPosicionTaca posiciontaca)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert into PR_aPosicionTaca (Posicion_Taca) values (@posicion_taca)";
                    conexionsql.Execute(sqlinsert, new { posicion_taca = posiciontaca.Posicion_Taca });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al agregar", ex);}
        }

        public String Actualizar_PosicionTaca(PR_aPosicionTaca posiciontaca)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aPosicionTaca set Posicion_Taca = @posicion_taca where IdPosicionTaca = @id";
                    conexionsql.Execute(sqlupdate, new {id = posiciontaca.IdPosicionTaca, posicion_taca = posiciontaca.Posicion_Taca });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al agregar", ex); }
        }

        public String Eliminar_PosicionTaca(byte idposiciontaca)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aPosicionTaca where IdPosicionTaca = @id";
                    conexionsql.Execute(sqldelete, new { id = idposiciontaca});
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al agregar", ex); }
        }


    }
}
