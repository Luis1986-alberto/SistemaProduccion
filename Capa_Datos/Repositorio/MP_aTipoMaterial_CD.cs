using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class MP_aTipoMaterial_CD
    {
        public static readonly MP_aTipoMaterial_CD _Instancia = new MP_aTipoMaterial_CD();
        private Inicio Principal = new Inicio();
        private string cadenaconexion;

        public static MP_aTipoMaterial_CD Instancia
        { get { return MP_aTipoMaterial_CD._Instancia; } }

        public MP_aTipoMaterial_CD()
        {
            Principal.LeerConfiguracion();
            cadenaconexion = Principal.CadenaConexion;
        }

        public IEnumerable<MP_aTipoMaterial> Lista_TipoMaterial()
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterial, Descripcion, Abreviatura, Orden_Gerencia, Codigo_Sustrato from MP_aTipoMaterial";
                    return conexionSQL.Query<MP_aTipoMaterial>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Listar", ex); }
        }

        public MP_aTipoMaterial TipoMaterialPorId(Int32 idtipomaterial)
        {
            try
            {
                using(var conexionSql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterial, Descripcion, Abreviatura, Orden_Gerencia, Codigo_Sustrato from MP_aTipoMaterial where IdTipoMaterial = @id";
                    return conexionSql.QueryFirst<MP_aTipoMaterial>(sql, new { id = idtipomaterial });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Traer Por Id", ex); }
        }

        public string Agregar_TipoMaterial(MP_aTipoMaterial tipomaterial)
        {
            try
            {
                using(var conexionSQl = new SqlConnection(cadenaconexion))
                {
                    var sqlInsert = "Insert Into MP_aTipoMaterial (Descripcion, Abreviatura, Orden_Gerencia, Codigo_Sustrato) values (@descripcion, @abreviatura, @orden_gerencia, @codigo_sustrato)";
                    conexionSQl.Execute(sqlInsert, new {
                        descripcion = tipomaterial.Descripcion,
                        abreviatura = tipomaterial.Abreviatura,
                        orden_gerencia = tipomaterial.Orden_Gerencia,
                        codigo_sustrato = tipomaterial.Codigo_Sustrato
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Agregar", ex); }
        }

        public string Actualizar_TipoMaterial(MP_aTipoMaterial tipomaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update MP_aTipoMaterial set Descripcion = @descripcion, Abreviatura = @abreviatura, Orden_Gerencia = @orden_gerencia, Codigo_Sustrato = @codigo_sustrato where IdTipoMaterial = @id";
                    conexionSQL.ExecuteScalar(sqlupdate, new {
                        id = tipomaterial.IdTipoMaterial,
                        descripcion = tipomaterial.Descripcion,
                        abreviatura = tipomaterial.Abreviatura,
                        orden_gerencia = tipomaterial.Orden_Gerencia,
                        codigo_sustrato = tipomaterial.Codigo_Sustrato
                    });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMaterial(Int32 idtipomaterial)
        {
            try
            {
                using(var conexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete MP_aTipoMaterial where IdGerencia = @id";
                    conexionSQL.Execute(sqldelete, new { id = idtipomaterial });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
