using Capa_Entidades.Tablas;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capa_Datos.Repositorio
{
    public class PR_aTipoMaterialMezclar_CD
    {
        public static readonly PR_aTipoMaterialMezclar_CD _Instancia = new PR_aTipoMaterialMezclar_CD();
        public Inicio principal = new Inicio();
        private string cadenaconexion = "";

        public static PR_aTipoMaterialMezclar_CD Instancia
        { get { return PR_aTipoMaterialMezclar_CD._Instancia; } }

        public PR_aTipoMaterialMezclar_CD()
        {
            principal.LeerConfiguracion();
            cadenaconexion = principal.CadenaConexion;
        }

        public IEnumerable<PR_aTipoMaterialMezclar> Lista_TipomaterialMezclar()
        {
           List<PR_aTipoMaterialMezclar> lst_tipomaterial = null;
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    conexionsql.Open();
                    SqlCommand cmd = new SqlCommand("select TMM.IdTipoMaterialMezclar, TMM.Descripcion_MaterialMezclar, TMM.Abreviatura, TMM.Orden_Gerencia, TMM.Codigo_Sustrato, TMM.IdClaseMaterial, CLM.Clase_Material " +
                                                    " from PR_aTipoMaterialMezclar as TMM inner join PR_aClaseMaterial as CLM on TMM.IdClaseMaterial = CLM.IdClaseMaterial", conexionsql);
                    cmd.CommandType = System.Data.CommandType.Text;

                    lst_tipomaterial = new List<PR_aTipoMaterialMezclar>();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        PR_aTipoMaterialMezclar t = new PR_aTipoMaterialMezclar();
                        t.IdTipoMaterialMezclar = byte.Parse(dr["IdTipoMaterialMezclar"].ToString());
                        t.Codigo_Sustrato = dr["Codigo_Sustrato"].ToString();
                        t.Descripcion_MaterialMezclar = dr["Descripcion_MaterialMezclar"].ToString();
                        t.Abreviatura = dr["Abreviatura"].ToString();
                        t.Orden_Gerencia = byte.Parse(dr["Orden_Gerencia"].ToString());
                        t.IdClaseMaterial = Int32.Parse(dr["IdClaseMaterial"].ToString());
                        t.Clase_Material = dr["Clase_Material"].ToString();
                        lst_tipomaterial.Add(t);
                    }
                }
                return lst_tipomaterial;
            }
            catch(Exception ex)
            {throw new Exception ("Error al listar", ex);}
        }

        public IEnumerable<PR_aTipoMaterialMezclar> Traer_TipoMaterialMezclarPorId(Int32 idtipomaterialmez)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sql = "select IdTipoMaterialMezclar, Descripcion_MaterialMezclar, Abreviatura, Orden_Gerencia, Codigo_Sustrato, IdClaseMaterial " +
                              " from PR_aTipoMaterialMezclar where IdTipoMaterialMezclar = @id ";
                    return conexionsql.Query<PR_aTipoMaterialMezclar>(sql, new { id = idtipomaterialmez });
                }
            }
            catch(Exception Ex)
            { throw new Exception("Error al Traer por ID", Ex); }
        }

        public string Agregar_TipoMaterialMezclar(PR_aTipoMaterialMezclar tipomaterialmezclar)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlinsert = "Insert Into PR_aTipoMaterialMezclar (Codigo_Sustrato, Descripcion_MaterialMezclar, Abreviatura, Orden_Gerencia, IdClaseMaterial) values " +
                                    " (@codigo_sustrato, @descripcion_materialmezclar, @abreviatura, orden_gerencia, idclasematerial)";
                    conexionsql.ExecuteScalar(sqlinsert, new { codigo_sustrato = tipomaterialmezclar.Codigo_Sustrato,
                                                               descripcion_materialmezclar = tipomaterialmezclar.Descripcion_MaterialMezclar,
                                                               abreviatura = tipomaterialmezclar.Abreviatura,
                                                               orden_gerencia = tipomaterialmezclar.Orden_Gerencia,
                                                               idclasematerial = tipomaterialmezclar.IdClaseMaterial                                                          
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error asl agregar", ex); }
        }

        public string Actualizar_TipoMaterialMezclar(PR_aTipoMaterialMezclar tipomaterialmezclar)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqlupdate = "Update PR_aTipoMaterialMezclar set Codigo_Sustrato = codigo_sustrato,  Descripcion_MaterialMezclar = @descripcion_materialmezclar, " +
                                    " Abreviatura = @abreviatura, Orden_Gerencia = @ordengerencia, IdClaseMaterial = @IdClaseMaterial where IdTipoMaterialMezclar = @id";
                    conexionsql.ExecuteScalar(sqlupdate, new {
                                                                id = tipomaterialmezclar.IdTipoMaterialMezclar,
                                                                codigo_sustrato = tipomaterialmezclar.Codigo_Sustrato,
                                                                descripcion_materialmezclar = tipomaterialmezclar.Descripcion_MaterialMezclar,
                                                                abreviatura = tipomaterialmezclar.Abreviatura,
                                                                orden_gerencia = tipomaterialmezclar.Orden_Gerencia,
                                                                idclasematerial = tipomaterialmezclar.IdClaseMaterial
                                                            });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Actualizar", ex); }
        }

        public string Eliminar_TipoMaterialMezclar(Int32 idtipomaterialmezclar)
        {
            try
            {
                using(var conexionsql = new SqlConnection(cadenaconexion))
                {
                    var sqldelete = "delete PR_aTipoMaterialMezclar where IdTipoMaterialMezclar = @id";
                    conexionsql.ExecuteScalar(sqldelete, new { id = idtipomaterialmezclar });
                    return "PROCESADO";
                }
            }
            catch(Exception ex)
            { throw new Exception("Error al Eliminar", ex); }
        }


    }
}
