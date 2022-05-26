using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aLocal_CD
    {
        public static readonly PR_aLocal_CD _Instancia = new PR_aLocal_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aLocal_CD Instancia
        { get { return PR_aLocal_CD._Instancia; } }

        public PR_aLocal_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aLocal> Lista_Locales()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLocal, Nombre_Local, Abreviatura_Local, Nave from  PR_aLocal";
                    return conexionsql.Query<PR_aLocal>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aLocal> Traer_LocalPorId(Int32 idlocal)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdLocal, Nombre_Local, Abreviatura_Local, Nave from PR_aLocal where IdLocal = @id";
                    return conexionsql.Query<PR_aLocal>(sql, new { id = idlocal });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Local(PR_aLocal alocal)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aLocal (Nombre_Local, Abreviatura_Local, Nave) values (@nombre_local, @abreviatura_local, @nave)";
                    conexionsql.Execute(sqlinsert, new {
                        nombre_local = alocal.Nombre_Local,
                        abreviatura_local = alocal.Abreviatura_Local,
                        nave = alocal.Nave
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_Local(PR_aLocal alocal)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aLocal set Nombre_Local = @nombre_local, Abreviatura_Local = @abreviatura_local, Nave = @nave where IdLocal = @id";
                    conexionsql.ExecuteScalar(sqledit, new {
                        id = alocal.IdLocal,
                        nombre_local = alocal.Nombre_Local,
                        abreviatura_local = alocal.Abreviatura_Local,
                        nave = alocal.Nave
                    });

                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_Local(Int32 idlocal)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_Adhesivo where IdLocal = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idlocal });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }


    }
}
