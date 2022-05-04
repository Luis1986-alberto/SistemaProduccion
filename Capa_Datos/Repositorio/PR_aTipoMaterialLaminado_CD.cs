using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoMaterialLaminado_CD
    {
        public static readonly PR_aTipoMaterialLaminado_CD _Instancia = new PR_aTipoMaterialLaminado_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoMaterialLaminado_CD Instancia
        { get { return PR_aTipoMaterialLaminado_CD._Instancia; } }

        public PR_aTipoMaterialLaminado_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoMaterialLaminado> Lista_TipoMaterialLaminado()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterialLaminado, Descripcion, Abreviatura, Orden_Gerencia, Gramaje_Lineal from PR_aTipoMaterialLaminado";
                    return conexionsql.Query<PR_aTipoMaterialLaminado>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoMaterialLaminado> Traer_TipoMaterialLaminadoPorId(Int32 idtipomateriallaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterialLaminado, Descripcion, Abreviatura, Orden_Gerencia, Gramaje_Lineal from PR_aTipoMaterialLaminado where IdTipoMaterialLaminado = @id";
                    return conexionsql.Query<PR_aTipoMaterialLaminado>(sql, new { id = idtipomateriallaminado });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoMaterialLaminado(PR_aTipoMaterialLaminado tipomateriallaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoMaterialLaminado (Descripcion, Abreviatura, Gramaje_Lineal, Orden_Gerencia) values(@descripcion, @abreviatura, @gramaje_lineal, @orden_gerencia)";
                    conexionsql.Execute(sqlinsert, new {
                                                                descripcion = tipomateriallaminado.Descripcion,
                                                                abreviatura = tipomateriallaminado.Abreviatura,
                                                                gramaje_lineal = tipomateriallaminado.Gramaje_Lineal,
                                                                orden_gerencia = tipomateriallaminado.Orden_Gerencia
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoMaterialLaminado(PR_aTipoMaterialLaminado tipomateriallaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoMaterialLaminado set Descripcion = @descripcion, Abreviatura = @abreviatura, Gramaje_Lineal = @gramaje_lineal, " +
                                    " Orden_Gerencia = @orden_gerencia where IdTipoMaterialLaminado = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = tipomateriallaminado.IdTipoMaterialLaminado,
                                                                descripcion = tipomateriallaminado.Descripcion,
                                                                abreviatura = tipomateriallaminado.Abreviatura,
                                                                gramaje_lineal = tipomateriallaminado.Gramaje_Lineal,
                                                                orden_gerencia = tipomateriallaminado.Orden_Gerencia
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMaterialLaminado(Int32 idtipomateriallaminado)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoMaterialLaminado where IdTipoMaterialLaminado = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipomateriallaminado });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
