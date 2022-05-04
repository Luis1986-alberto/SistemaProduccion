using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class MP_aPropiedadesMaterial
    {
        public byte IdPropiedadMaterial { get; set; }
        public string Propiedad_Material { get; set; }
        public string Codigo_PropiedadMaterial { get; set; }

        public MP_aPropiedadesMaterial()
        { }

        public MP_aPropiedadesMaterial(byte idpropiedadmaterial, string propiedad_material, string codigo_propiedadmaterial)
        {
            this.IdPropiedadMaterial = idpropiedadmaterial;
            this.Propiedad_Material = propiedad_material;
            this.Codigo_PropiedadMaterial = codigo_propiedadmaterial;
        }

    }
}
