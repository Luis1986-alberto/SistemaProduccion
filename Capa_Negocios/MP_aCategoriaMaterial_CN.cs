using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class MP_aCategoriaMaterial_CN
    {
        public static readonly MP_aCategoriaMaterial_CN Instancia = new MP_aCategoriaMaterial_CN();

        public static MP_aCategoriaMaterial_CN _Instancia
        { get { return MP_aCategoriaMaterial_CN.Instancia; } }

        public List<MP_aCategoriaMaterial> Lista_CategoriaMaterial()
        { return MP_aCategoriaMaterial_CD.Intancia.Lista_CategoriaMaterial().ToList(); }

        public IEnumerable<MP_aCategoriaMaterial> TraerPorID(Int32 idcategoriamaterial)
        { return MP_aCategoriaMaterial_CD.Intancia.Traer_CategoriaMaterialPorId(idcategoriamaterial); }

        public IEnumerable<MP_aCategoriaMaterial> Buscar_NombreCategoria(string nombrecategoria)
        {
            var lista = MP_aCategoriaMaterial_CD.Intancia.Lista_CategoriaMaterial();
            return from cat in lista where cat.Nombre_Categoria_Material == nombrecategoria select cat;
        }

        public string Agregar(MP_aCategoriaMaterial categoriamaterial)
        {
            if (Buscar_NombreCategoria(categoriamaterial.Nombre_Categoria_Material).ToList().Count > 0) return "YA EXISTE ESTA CATEGORIA";
            return MP_aCategoriaMaterial_CD._Intancia.Agregar_CategoriaMaterial(categoriamaterial);
        }

        public string Actualizar(MP_aCategoriaMaterial categoriamaterial)
        {
            if (Buscar_NombreCategoria(categoriamaterial.Nombre_Categoria_Material).ToList().Count > 0) return "YA EXISTE ESTA CATEGORIA";
            return MP_aCategoriaMaterial_CD._Intancia.Actualizar_CategoriaMaterial(categoriamaterial);
        }

        public string Eliminar(Int32 idcategoriamaterial)
        {
            return MP_aCategoriaMaterial_CD._Intancia.Eliminar_CategoriaMaterial(idcategoriamaterial);
        }


    }
}
