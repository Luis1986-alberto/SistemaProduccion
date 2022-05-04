using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aLineaColor_CN
    {
        public static readonly PR_aLineaColor_CN _Instancia = new PR_aLineaColor_CN();

        public static PR_aLineaColor_CN Instancia
        { get { return PR_aLineaColor_CN._Instancia; } }

        public List<PR_aLineaColor> Lista_FormaEmpaquetado()
        { return PR_aLineaColor_CD._Instancia.Lista_LineaColor().ToList(); }

        public IEnumerable<PR_aLineaColor> TraerPorID(Int32 id)
        { return PR_aLineaColor_CD._Instancia.Traer_LineaColorPorId(id); }

        public IEnumerable<PR_aLineaColor> Buscar_Nombrelinea(string nombrelineacolor)
        {
            var lista = PR_aLineaColor_CD._Instancia.Lista_LineaColor().ToList();
            return from buscar in lista where buscar.Nombre_LineaColor == nombrelineacolor select buscar;
        }

        public string Agregar_LineaColor(PR_aLineaColor lineacolor)
        {
            if (Buscar_Nombrelinea(lineacolor.Nombre_LineaColor).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aLineaColor_CD._Instancia.Agregar_LineaColor(lineacolor);
        }

        public string Actualizar_LineaProduccion(PR_aLineaColor lineacolor)
        {
            if (Buscar_Nombrelinea(lineacolor.Nombre_LineaColor).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aLineaColor_CD._Instancia.Actualizar_LineaColor(lineacolor);
        }

        public string Eliminar_LineaProduccion(Int32 idlineacolor)
        { return PR_aLineaColor_CD._Instancia.Eliminar_LineaColor(idlineacolor); }


    }
}
