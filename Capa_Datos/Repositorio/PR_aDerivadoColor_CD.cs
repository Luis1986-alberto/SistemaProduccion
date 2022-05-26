using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aDerivadoColor_CD
    {
        public static readonly PR_aDerivadoColor_CD _Instancia = new PR_aDerivadoColor_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aDerivadoColor_CD Instancia
        { get { return PR_aDerivadoColor_CD._Instancia; } }

        public PR_aDerivadoColor_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aDerivadoColor> Lista_DerivadoColor()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdDerivadoColor, Nombre_DerivadoColor, Codigo_DerivadoColor from PR_aDerivadoColor";
                    return conexionsql.Query<PR_aDerivadoColor>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public IEnumerable<PR_aDerivadoColor> Traer_DerivadoColorPorId(Int32 idderivadocolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdDerivadoColor, Nombre_DerivadoColor, Codigo_DerivadoColor from PR_aDerivadoColor where IdDerivadoColor = @id";
                    return conexionsql.Query<PR_aDerivadoColor>(sql, new { id = idderivadocolor });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_DerivadoColor(PR_aDerivadoColor derivadocolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into PR_aDerivadoColor (Nombre_DerivadoColor, Codigo_DerivadoColor) value (@nombre_derivadocolor, @codigo_derivadocolor)";
                    conexionsql.ExecuteScalar(sqlinsert, new {
                        codigo_derivadocolor = derivadocolor.Codigo_DerivadoColor,
                        nombre_derivadocolor = derivadocolor.Nombre_DerivadoColor
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_DerivadaColor(PR_aDerivadoColor derivadocolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "update PR_aDerivadoColor set Nombre_DerivadoColor = nombre_derivadocolor, Codigo_DerivadoColor = @codigo_derivadocolor where IdDerivadoColor = @Idderivadocolor";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                        Idderivadocolor = derivadocolor.IdDerivadoColor,
                        codigo_derivadocolor = derivadocolor.Codigo_DerivadoColor,
                        nombre_derivadocolor = derivadocolor.Nombre_DerivadoColor,

                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Actualizar", ex); }
        }

        public string Eliminar_DerivadaColor(Int32 idderivadocolor)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aDerivadoColor where IdDerivadoColor = @Idderivadocolor";
                    conexionsql.ExecuteScalar(sqldelete, new { Idderivadocolor = idderivadocolor });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }


    }
}
