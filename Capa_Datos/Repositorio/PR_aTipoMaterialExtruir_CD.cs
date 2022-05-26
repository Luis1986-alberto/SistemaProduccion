using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoMaterialExtruir_CD
    {
        public static readonly PR_aTipoMaterialExtruir_CD _Instancia = new PR_aTipoMaterialExtruir_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoMaterialExtruir_CD Instancia
        { get { return PR_aTipoMaterialExtruir_CD._Instancia; } }

        public PR_aTipoMaterialExtruir_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoMaterialExtruir> Lista_TipoMaterialExtruir()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterialExtruir, Descripcion_MaterialExtruir, Abreviatura from PR_aTipoMaterialExtruir";
                    return conexionsql.Query<PR_aTipoMaterialExtruir>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aTipoMaterialExtruir> Traer_TipoMaterialExtruirPorId(Int32 idtipomaterialextruir)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterialExtruir, Descripcion_MaterialExtruir, Abreviatura from PR_aTipoMaterialExtruir where IdTipoMaterialExtruir = @id";
                    return conexionsql.Query<PR_aTipoMaterialExtruir>(sql, new { id = idtipomaterialextruir });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoMaterialExtruir(PR_aTipoMaterialExtruir tipomaterialextruir)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoMaterialExtruir (Descripcion_MaterialExtruir, Abreviatura) values(@descripcion_materialextruir, @abreviatura)";
                    conexionsql.ExecuteScalar(sqlinsert, new { descripcion_materialextruir = tipomaterialextruir.Descripcion_MaterialExtruir, abreviatura = tipomaterialextruir.Abreviatura });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoMaterialExtruir(PR_aTipoMaterialExtruir tipomaterialextruir)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoMaterialExtruir set Descripcion_MaterialExtruir = @descripcion_materialextruir, Abreviatura = @abreviatura where IdTipoMaterialExtruir = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = tipomaterialextruir.IdTipoMaterialExtruir, descripcion_materialextruir = tipomaterialextruir.Descripcion_MaterialExtruir, abreviatura = tipomaterialextruir.Abreviatura });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMaterialExtruir(Int32 idtipomaterialextruir)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoMaterialExtruir where IdTipoMaterialExtruir = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipomaterialextruir });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

    }
}
