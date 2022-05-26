using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoMaquina_CD
    {
        public static readonly PR_aTipoMaquina_CD _Instancia = new PR_aTipoMaquina_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoMaquina_CD Instancia
        { get { return PR_aTipoMaquina_CD._Instancia; } }

        public PR_aTipoMaquina_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoMaquina> Lista_TipoMaquina()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaquina, Nombre_TipoMaquina, Abreviatura_TipoMaquina from PR_aTipoMaquina";
                    return conexionsql.Query<PR_aTipoMaquina>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoMaquina> Traer_TipoMaquinaPorId(Int32 idtipomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaquina, Nombre_TipoMaquina, Abreviatura_TipoMaquina from PR_aTipoMaquina where IdTipoMaquina = @id";
                    return conexionsql.Query<PR_aTipoMaquina>(sql, new { id = idtipomaquina });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoMaquina(PR_aTipoMaquina tipomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoMaquina (Nombre_TipoMaquina, Abreviatura_TipoMaquina ) values(@nombre_tipomaquina, @abreviatura_tipomaquina)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tipomaquina = tipomaquina.Nombre_TipoMaquina, abreviatura_tipomaquina = tipomaquina.Abreviatura_TipoMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoMaquina(PR_aTipoMaquina tipomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoMaquina set Nombre_TipoMaquina = @nombre_tipomaquina, Abreviatura_TipoMaquina = @abreviatura_tipomaquina where IdTipoMaquina = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipomaquina.IdTipoMaquina, nombre_tipomaquina = tipomaquina.Nombre_TipoMaquina, abreviatura_tipomaquina = tipomaquina.Abreviatura_TipoMaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMaquina(Int32 idtipomaquina)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoMaquina where IdTipoMaquina = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipomaquina });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
