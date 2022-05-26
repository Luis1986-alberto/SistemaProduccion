using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aEstadoOrdenProduccion_Programa_CD
    {
        public static readonly PR_aEstadoOrdenProduccion_Programa_CD _Instancia = new PR_aEstadoOrdenProduccion_Programa_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aEstadoOrdenProduccion_Programa_CD Instancia
        { get { return PR_aEstadoOrdenProduccion_Programa_CD._Instancia; } }

        public PR_aEstadoOrdenProduccion_Programa_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aEstadoOrdenProduccion_Programa> Lista_EstadoOrenProduccion_Programa()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoOrdenProduccion_Programa, EstadoOrdenProduccion_Programa, Sigla_EstadoOP_Programa from  PR_aEstadoOrdenProduccion_Programa";
                    return conexionsql.Query<PR_aEstadoOrdenProduccion_Programa>(sql);
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al listar", Ex); }
        }
        public IEnumerable<PR_aEstadoOrdenProduccion_Programa> Traer_EstadoOrdenProduccionPorId(Int32 idestadoordenproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdEstadoOrdenProduccion_Programa, EstadoOrdenProduccion_Programa, Sigla_EstadoOP_Programa from  PR_aEstadoOrdenProduccion_Programa where IdEstadoOrdenProduccion_Programa = @id";
                    return conexionsql.Query<PR_aEstadoOrdenProduccion_Programa>(sql, new { id = idestadoordenproduccion });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_EstadoOrdenProduccion_Programa(PR_aEstadoOrdenProduccion_Programa aestadoordenproduccion_programa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aEstadoOrdenProduccion_Programa (EstadoOrdenProduccion_Programa, Sigla_EstadoOP_Programa ) valueS " +
                                                                                  " (@estadoordenproduccion, @sigla_estadoop_programa)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                        estadoordenproduccion = aestadoordenproduccion_programa.EstadoOrdenProduccion_Programa,
                        sigla_estadoop_programa = aestadoordenproduccion_programa.Sigla_EstadoOP_Programa
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Insertar", Ex); }
        }

        public string Actualizar_EstadoOrdenProduccion_Programa(PR_aEstadoOrdenProduccion_Programa aestadoordenproduccion_programa)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqledit = "update PR_aEstadoOrdenProduccion_Programa set EstadoOrdenProduccion_Programa = @estadoordenproduccion, " +
                                  " Sigla_EstadoOP_Programa = @sigla_estadoop_programa where IdEstadoOrdenProduccion_Programa = @id";
                    conexionsql.ExecuteScalar(sqledit, new {
                        id = aestadoordenproduccion_programa.IdEstadoOrdenProduccion_Programa,
                        estadoordenproduccion = aestadoordenproduccion_programa.EstadoOrdenProduccion_Programa,
                        sigla_estadoop_programa = aestadoordenproduccion_programa.Sigla_EstadoOP_Programa,
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al Actualizar", Ex); }
        }

        public string Eliminar_EstadoOrdenProduccion_Programa(Int32 idestadoordenproduccion)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aEstadoOrdenProduccion_Programa where IdEstadoOrdenProduccion_Programa = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idestadoordenproduccion });
                    return "PROCESADO";
                }
            }
            catch(Exception Ex) { throw new Exception("Error al eliminar", Ex); }
        }


    }
}
