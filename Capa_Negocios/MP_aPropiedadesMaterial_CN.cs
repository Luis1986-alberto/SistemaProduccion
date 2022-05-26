using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class MP_aPropiedadesMaterial_CN
    {
        public static readonly MP_aPropiedadesMaterial_CN _Instancia = new MP_aPropiedadesMaterial_CN();

        public static MP_aPropiedadesMaterial_CN Instacnia
        { get { return MP_aPropiedadesMaterial_CN._Instancia; } }


        public List<MP_aPropiedadesMaterial> Lista_PropiedadMaterial()
        { return MP_aPropiedadMaterial_CD._Instancia.Lista_PropiedadMaterial().ToList(); }

        public MP_aPropiedadesMaterial TraerPorID(Int32 idpropiedadmaterial)
        { return MP_aPropiedadMaterial_CD._Instancia.TraerPorIdPropiedadMaterial(idpropiedadmaterial); }

        public IEnumerable<MP_aPropiedadesMaterial> FiltrarPorDescripcion(string descripcion)
        {
            var lista = MP_aPropiedadMaterial_CD._Instancia.Lista_PropiedadMaterial();
            return from ad in lista where ad.Propiedad_Material == descripcion select ad;
        }

        public string Agregar(MP_aPropiedadesMaterial propiedadesmaterial)
        {
            if (FiltrarPorDescripcion(propiedadesmaterial.Propiedad_Material).Count() > 0) return "EXISTE ESTA PROPIEDAD REGISTRADA";
            return MP_aPropiedadMaterial_CD._Instancia.Agregar(propiedadesmaterial);
        }

        public string Actualizar(MP_aPropiedadesMaterial propiedadesmaterial)
        {
            if (FiltrarPorDescripcion(propiedadesmaterial.Propiedad_Material).Count() > 0) return "EXISTE ESTA PROPIEDAD REGISTRADA";
            return MP_aPropiedadMaterial_CD._Instancia.Actualizar(propiedadesmaterial);
        }

        public string Eliminar(Int32 idpropiedadmaterial)
        { return MP_aPropiedadMaterial_CD._Instancia.Eliminar(idpropiedadmaterial); }

    }
}
