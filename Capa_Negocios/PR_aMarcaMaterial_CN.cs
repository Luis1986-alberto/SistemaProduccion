using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aMarcaMaterial_CN
    {
        public static readonly PR_aMarcaMaterial_CN _Instancia = new PR_aMarcaMaterial_CN();

        public static PR_aMarcaMaterial_CN Instancia
        { get { return PR_aMarcaMaterial_CN._Instancia; } }

        public List<MP_aMarcaMaterial> Lista_FormaEmpaquetado()
        { return PR_aMarcaMaterial_CD._Instancia.Lista_aMarcaMaterial().ToList(); }

        public IEnumerable<MP_aMarcaMaterial> TraerPorID(Int32 id)
        { return PR_aMarcaMaterial_CD._Instancia.Traer_MarcaMaterialPorId(id); }

        public IEnumerable<MP_aMarcaMaterial> Buscar_Descripcion(string descripcion)
        {
            var lista = PR_aMarcaMaterial_CD._Instancia.Lista_aMarcaMaterial().ToList();
            return from buscar in lista where buscar.Descripcion == descripcion select buscar;
        }

        public string Agregar_MarcaMaterialr(MP_aMarcaMaterial marcamaterial)
        {
            if (Buscar_Descripcion(marcamaterial.Descripcion).Count() > 0) return "Existe una Marca Material Registrado";
            return PR_aMarcaMaterial_CD._Instancia.Agregar_MarcaMaterial(marcamaterial);
        }

        public string Actualizar_LineaProduccion(MP_aMarcaMaterial marcamaterial)
        {
            if (Buscar_Descripcion(marcamaterial.Descripcion).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aMarcaMaterial_CD._Instancia.Actualizar_MarcaMaterial(marcamaterial);
        }

        public string Eliminar_LineaProduccion(Int32 idlineacolor)
        { return PR_aMarcaMaterial_CD._Instancia.Eliminar_MarcaMaterial(idlineacolor); }


    }
}
