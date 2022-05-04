using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoTrabajador_CD
    {
        public static readonly PR_aTipoTrabajador_CD _Instancia = new PR_aTipoTrabajador_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoTrabajador_CD Instancia
        { get { return PR_aTipoTrabajador_CD._Instancia; } }

        public PR_aTipoTrabajador_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoTrabajador> Lista_TipoTrabajador()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTrabajador, Nombre_TipoTrabajador from PR_aTipoTrabajador";
                    return conexionsql.Query<PR_aTipoTrabajador>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoTrabajador> Traer_TipoTrabajadorPorId(Int32 idtipotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoTrabajador, Nombre_TipoTrabajador from PR_aTipoTrabajador where idtipotrabajador = @id";
                    return conexionsql.Query<PR_aTipoTrabajador>(sql, new { id = idtipotrabajador });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoTrabajador(PR_aTipoTrabajador tipotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoTrabajador (Nombre_TipoTrabajador) values(@nombre_tipotrabajador)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_tipotrabajador = tipotrabajador.Nombre_TipoTrabajador });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoTrabajador(PR_aTipoTrabajador tipotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoTrabajador set Nombre_TipoTrabajador = @nombre_tipotrabajador where IdTipoTrabajador = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipotrabajador.IdTipoTrabajador, nombre_tipotrabajador = tipotrabajador.Nombre_TipoTrabajador });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoTrabajador(Int32 idtipotrabajador)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoTrabajador where IdTipoTrabajador = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipotrabajador });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        

    }
}
