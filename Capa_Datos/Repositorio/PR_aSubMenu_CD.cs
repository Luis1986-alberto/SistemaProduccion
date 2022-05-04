using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aSubMenu_CD
    {
        public static readonly PR_aSubMenu_CD _Intancia = new PR_aSubMenu_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aSubMenu_CD Intancia
        { get { return PR_aSubMenu_CD._Intancia; } }

        public PR_aSubMenu_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aSubMenu> Lista_SubMenu()
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSubMenu, Detalle_SubMenu, SubMenu, Orden_SubMenu from PR_aSubMenu";
                    return conexionsql.Query<PR_aSubMenu>(sql);
                }
            }
            catch(Exception ex)
            { throw new Exception("error al listar", ex); }
        }

        public IEnumerable<PR_aAsa> Traer_AsaPorId(Int32 idsubmenu)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdSubMenu, Detalle_SubMenu, SubMenu, Orden_SubMenu from PR_aSubMenu where IdSubMenu = @id";
                    return conexionsql.Query<PR_aAsa>(sql, new { id = idsubmenu });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_SubMenu(PR_aSubMenu submenu)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aSubMenu (Detalle_SubMenu, Orden_SubMenu, SubMenu ) values(@detalle_submenu, @orden_submenu, @submenu)";
                    conexionsql.ExecuteScalar(sqlinsert, new { detalle_submenu = submenu.Detalle_SubMenu,
                                                                orden_submenu = submenu.Orden_SubMenu,
                                                                submenu = submenu.SubMenu
                                                             });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_SubMenu(PR_aSubMenu submenu)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aSubMenu set Detalle_SubMenu = @detalle_submenu, Orden_SubMenu = @orden_submenu, SubMenu = @submenu where IdSubMenu = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = submenu.IdSubMenu,
                                                                detalle_submenu = submenu.Detalle_SubMenu,
                                                                orden_submenu = submenu.Orden_SubMenu,
                                                                submenu = submenu.SubMenu
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_SubMenu(Int32 idsubmenu)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aSubMenu where IdSubMenu = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idsubmenu });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }

        
    }
}
