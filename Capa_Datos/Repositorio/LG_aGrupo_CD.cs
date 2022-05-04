using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos.Repositorio
{
    public class LG_aGrupo_CD
    {
        public static readonly LG_aGrupo_CD _Instancia = new LG_aGrupo_CD();
        private Inicio principal = new Inicio();
        private string cadenaconexion;

        private static LG_aGrupo_CD Instancia
        { get { return LG_aGrupo_CD._Instancia;} }

        public LG_aGrupo_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }


        public IEnumerable<LG_aGrupo>Lista_Grupos()
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Sselect IdGrupo, Nombre_Grupo, Codigo_Grupo, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aGrupo ";
                    return ConexionSQL.Query<LG_aGrupo>(sql);
                }
            }
            catch(Exception ex)
            {throw new Exception("Error al listar", ex);}
        }

        public LG_aGrupo TraerPorIdGrupos(Int32 idgrupo)
        {
            try
            {
                using(var ConexionSQL = new SqlConnection(cadenaconexion))
                {
                    var sql = "Sselect IdGrupo, Nombre_Grupo, Codigo_Grupo, IdUsuario_PC, Fecha_Servidor, IdUsuario from LG_aGrupo where IdGrupo = @id ";
                    return ConexionSQL.QueryFirst<LG_aGrupo>(sql, new { id = idgrupo });
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al listar", ex); }
        }

        public string Agregar_Grupos(LG_aGrupo grupos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "insert into LG_aGrupo (Nombre_Grupo, Codigo_Grupo, IdUsuario_PC, IdUsuario ) values " +
                        "                                 (@nombre_grupo, @codigo_grupo, @idusuario_pc, @idusuario)";
                    conexionsql.ExecuteScalar(sqlinsert, new { nombre_grupo = grupos.Nombre_Grupo, codigo_grupo = grupos.Codigo_Grupo,
                                                               idusuario_pc = Environment.UserName, idusuario = grupos.IdUsuario
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Actualizar_Grupos(LG_aGrupo grupos)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Update LG_aGrupo set Nombre_Grupo = @nombre_grupo, Codigo_grupo = @codigo_grupo, IdUsuario_PC = @idusuario_pc, " +
                                    " idusuario = @idusuario where IdGrupo = @id ";
                    conexionsql.ExecuteScalar(sqlinsert, new { id = grupos.IdGrupo, nombre_grupo = grupos.Nombre_Grupo, codigo_grupo = grupos.Codigo_Grupo,
                                                               idusuario_pc = Environment.UserName, idusuario = grupos.IdUsuario
                                                              });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al inserta", ex); }
        }

        public string Eliminar_Grupos(Int32 idgrupo)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "delete LG_aGrupo where IdGrupo = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new { id = idgrupo });
                    return "PROCESADO";
                }
            }
            catch(Exception ex) { throw new Exception("Error al momento de Eliminar", ex); }
        }
    }
}
