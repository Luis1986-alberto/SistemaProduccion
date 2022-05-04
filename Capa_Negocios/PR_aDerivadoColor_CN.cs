using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aDerivadoColor_CN
    {
        public static readonly PR_aDerivadoColor_CN _Instancia = new PR_aDerivadoColor_CN();

        public static PR_aDerivadoColor_CN Instancia
        { get { return PR_aDerivadoColor_CN._Instancia; } }

        public List<PR_aDerivadoColor> Lista_Areas()
        { return PR_aDerivadoColor_CD._Instancia.Lista_DerivadoColor().ToList(); }

        public IEnumerable<PR_aDerivadoColor> TraerPorID(byte id)
        { return PR_aDerivadoColor_CD._Instancia.Traer_DerivadoColorPorId(id); }

        public IEnumerable<PR_aDerivadoColor> Buscar_Nombre(string nombre_derivadocolor)
        {
            var lst = PR_aDerivadoColor_CD._Instancia.Lista_DerivadoColor().ToList();
            return from AD in lst where AD.Nombre_DerivadoColor == nombre_derivadocolor select AD;
        }

        public string Agregar_DerivadoColor(PR_aDerivadoColor derivadocolor)
        {
            if (Buscar_Nombre(derivadocolor.Nombre_DerivadoColor).Count() > 0) return "Existe un Derivado Color Registrado";
            return PR_aDerivadoColor_CD._Instancia.Agregar_DerivadoColor(derivadocolor);
        }

        public string Actualizar_DerivadoColor(PR_aDerivadoColor derivadocolor)
        {
            if (Buscar_Nombre(derivadocolor.Nombre_DerivadoColor).Count() > 0) return "Existe Derivado Color Registrado";
            return PR_aDerivadoColor_CD._Instancia.Actualizar_DerivadaColor(derivadocolor);
        }

        public string Eliminar_DerivadoColor(Int32 idDerivadocolor)
        { return PR_aDerivadoColor_CD._Instancia.Eliminar_DerivadaColor(idDerivadocolor); }
    }
}
