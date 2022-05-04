using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoMaterialMezclar_CN
    {
        public static readonly PR_aTipoMaterialMezclar_CN _Instancia = new PR_aTipoMaterialMezclar_CN();

        public static PR_aTipoMaterialMezclar_CN Instancia
        { get { return PR_aTipoMaterialMezclar_CN._Instancia; } }

        public List<PR_aTipoMaterialMezclar> Lista_Material()
        { return PR_aTipoMaterialMezclar_CD._Instancia.Lista_TipomaterialMezclar().ToList(); }

        public IEnumerable<PR_aTipoMaterialMezclar> TraerPorID(Int32 id)
        { return PR_aTipoMaterialMezclar_CD._Instancia.Traer_TipoMaterialMezclarPorId(id); }

        public IEnumerable<PR_aTipoMaterialMezclar> Buscar_MaterialMezclar(string materialmezclar)
        {
            var lista = PR_aTipoMaterialMezclar_CD._Instancia.Lista_TipomaterialMezclar().ToList();
            return from buscar in lista where buscar.Descripcion_MaterialMezclar == materialmezclar select buscar;
        }

        public string Agregar_TipoMaterialMezclar(PR_aTipoMaterialMezclar tipomaterialmezclar)
        {
            if (Buscar_MaterialMezclar(tipomaterialmezclar.Descripcion_MaterialMezclar).Count() > 0) return "EXISTE TIPO MATERIAL MEZCLAR";
            return PR_aTipoMaterialMezclar_CD._Instancia.Agregar_TipoMaterialMezclar(tipomaterialmezclar);
        }

        public string Actualizar_TipoMaterialMezclar(PR_aTipoMaterialMezclar tipomaterialmezclar)
        {
            if (Buscar_MaterialMezclar(tipomaterialmezclar.Descripcion_MaterialMezclar).Count() > 0) return "EXISTE TIPO MATERIAL MEZCLAR";
            return PR_aTipoMaterialMezclar_CD._Instancia.Actualizar_TipoMaterialMezclar(tipomaterialmezclar);
        }

        public string Eliminar_TipoMaterialMezclar(Int32 idtipomatmezclar)
        { return PR_aTipoMaterialMezclar_CD._Instancia.Eliminar_TipoMaterialMezclar(idtipomatmezclar); }

    }
}
