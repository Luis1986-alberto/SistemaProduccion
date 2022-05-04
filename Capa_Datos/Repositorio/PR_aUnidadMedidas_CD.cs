using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aUnidadMedidas_CD
    {
        public static readonly PR_aUnidadMedidas_CD _Instancia = new PR_aUnidadMedidas_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aUnidadMedidas_CD Instancia
        { get { return PR_aUnidadMedidas_CD._Instancia; } }

        public PR_aUnidadMedidas_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aUnidadMedidas> Lista_UnidadMedida()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUnidadMedida, Sigla_Unidad, Nombre_Unidad, Flag_Espesor from PR_aUnidadMedidas";
                    return conexionsql.Query<PR_aUnidadMedidas>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aUnidadMedidas> Traer_UnidadMedidaPorId(Int32 idunidadmedida)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdUnidadMedida, Sigla_Unidad, Nombre_Unidad, Flag_Espesor from PR_aUnidadMedidas where IdUnidadMedida = @id";
                    return conexionsql.Query<PR_aUnidadMedidas>(sql, new { id = idunidadmedida });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_UnidadMedida(PR_aUnidadMedidas unidadmedida)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aUnidadMedidas (Nombre_Unidad, Sigla_Unidad, Flag_Espesor ) values(@nombre_unidad, @sigla_unidad, @flag_espesor)";
                    conexionsql.ExecuteScalar(sqlinsert, new { 
                                                                nombre_unidad = unidadmedida.Nombre_Unidad,
                                                                sigla_unidad = unidadmedida.Sigla_Unidad,
                                                                flag_espesor = unidadmedida.Flag_Espesor
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_UnidadMedida(PR_aUnidadMedidas unidadmedida)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aUnidadMedidas set Nombre_Unidad = @nombre_unidad, Sigla_Unidad = @sigla_unidad, Flag_Espesor = flag_espesor where IdUnidadMedida = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = unidadmedida.IdUnidadMedida,
                                                                nombre_unidad = unidadmedida.Nombre_Unidad,
                                                                sigla_unidad = unidadmedida.Sigla_Unidad,
                                                                flag_espesor = unidadmedida.Flag_Espesor
                        });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_UnidadMedida(Int32 idunidadmedida)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aUnidadMedidas where IdUnidadMedida = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idunidadmedida });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
