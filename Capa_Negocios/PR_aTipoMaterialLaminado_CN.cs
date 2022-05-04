using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoMaterialLaminado_CN
    {
        public static readonly PR_aTipoMaterialLaminado_CN _Instancia = new PR_aTipoMaterialLaminado_CN();

        public static PR_aTipoMaterialLaminado_CN Instancia
        { get { return PR_aTipoMaterialLaminado_CN._Instancia; } }

        public List<PR_aTipoMaterialLaminado> Lista_TipoMaterialLaminado()
        { return PR_aTipoMaterialLaminado_CD._Instancia.Lista_TipoMaterialLaminado().ToList(); }

        public IEnumerable<PR_aTipoMaterialLaminado> TraerPorID(Int32 id)
        { return PR_aTipoMaterialLaminado_CD._Instancia.Traer_TipoMaterialLaminadoPorId(id); }

        public IEnumerable<PR_aTipoMaterialLaminado> Buscar_TipoMaterialLaminado(string descripcion)
        {
            var lista = PR_aTipoMaterialLaminado_CD._Instancia.Lista_TipoMaterialLaminado().ToList();
            return from buscar in lista where buscar.Descripcion == descripcion select buscar;
        }

        public string Agregar_TipoMaterialLaminado(PR_aTipoMaterialLaminado tipomatlaminado)
        {
            if (Buscar_TipoMaterialLaminado(tipomatlaminado.Descripcion).Count() > 0) return "EXISTE TIPO MATERIAL LAMINACION";
            return PR_aTipoMaterialLaminado_CD._Instancia.Agregar_TipoMaterialLaminado(tipomatlaminado);
        }

        public string Actualizar_TipoMaterialLaminado(PR_aTipoMaterialLaminado tipomatlaminado)
        {
            if (Buscar_TipoMaterialLaminado(tipomatlaminado.Descripcion).Count() > 0) return "EXISTE TIPO MATERIAL LAMINACION";
            return PR_aTipoMaterialLaminado_CD._Instancia.Actualizar_TipoMaterialLaminado(tipomatlaminado);
        }

        public string Eliminar_TipoMaterialLaminado(Int32 idtipomatlaminado)
        {

            return PR_aTipoMaterialLaminado_CD._Instancia.Eliminar_TipoMaterialLaminado(idtipomatlaminado);
        }
    }
}
