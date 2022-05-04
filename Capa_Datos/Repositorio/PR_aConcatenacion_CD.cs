using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aConcatenacion_CD
    {
        public static readonly PR_aConcatenacion_CD _Instancia = new PR_aConcatenacion_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aConcatenacion_CD Instancia
        { get { return PR_aConcatenacion_CD._Instancia; } }

        public PR_aConcatenacion_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aConcatenacion> Lista_Concatenacion()
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdConcatenacion, IdGProdProplast, OrdenConcatenacion, Flag_Concatenacion, IdEstandarIndustrial from PR_aConcatenacion";
                    return conexionsql.Query<PR_aConcatenacion>(sql);
                }
            }
            catch (Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aConcatenacion> Traer_ConcatenacionPorId(Int32 idconcatenacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdConcatenacion, IdGProdProplast, OrdenConcatenacion, Flag_Concatenacion, IdEstandarIndustrial from PR_aConcatenacion where IdConcatenacion = @id";
                    return conexionsql.Query<PR_aConcatenacion>(sql, new { id = idconcatenacion });
                }
            }
            catch (Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_Concatenacion(PR_aConcatenacion concatenacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aConcatenacion (IdGProdProplast, OrdenConcatenacion, Flag_Concatenacion, IdEstandarIndustrial) value " +
                                    " (@idgprodproplast, @ordenconcatenacion, @flag_concatenacion, @idestandarindustrial )";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                                                                idgprodproplast = concatenacion.IdGProdProplast,
                                                                ordenconcatenacion = concatenacion.OrdenConcatenacion,
                                                                flag_concatenacion = concatenacion.Flag_Concatenacion,
                                                                idestandarindustrial = concatenacion.IdEstandarIndustrial

                                                               });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Concatenacion(PR_aConcatenacion concatenacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aConcatenacion set IdGProdProplast = @idgprodproplast, OrdenConcatenacion = @ordenconcatenacion, Flag_Concatenacion = @flag_concatenacion, " +
                                    " idestandarindustrial = @IdEstandarIndustrial where IdConcatenacion = @idconcatenacion";
                    conexionsql.ExecuteScalar(sqlupdate, new
                                                            {
                                                                idconcatenacion = concatenacion.IdConcatenacion,
                                                                idgprodproplast = concatenacion.IdGProdProplast,
                                                                ordenconcatenacion = concatenacion.OrdenConcatenacion,
                                                                flag_concatenacion = concatenacion.Flag_Concatenacion,
                                                                idestandarindustrial = concatenacion.IdEstandarIndustrial
                                                            });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_Color(Int32 idconcatenacion)
        {
            try
            {
                using (var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete PR_aConcatenacion where IdConcatenacion = @idconcatenacion";
                    conexionsql.ExecuteScalar(sqlupdate, new { idconcatenacion = idconcatenacion });
                    return "PROCESADO";
                }
            }
            catch (Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }

      
    }
}
