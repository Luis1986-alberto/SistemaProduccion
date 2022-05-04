using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aPieImprenta_CN
    {
        public static readonly PR_aPieImprenta_CN _Instancia = new PR_aPieImprenta_CN();

        public static PR_aPieImprenta_CN Instancia
        { get { return PR_aPieImprenta_CN._Instancia; } }

        public List<PR_aPieImprenta> Lista_PieImprenta()
        { return PR_aPieImprenta_CD._Instancia.Lista_PieImprenta().ToList(); }

        public IEnumerable<PR_aPieImprenta> TraerPorID(Int32 id)
        { return PR_aPieImprenta_CD._Instancia.Traer_PieImprentaPorId(id); }

        public IEnumerable<PR_aPieImprenta> Buscar_Descripcion(string descripcion)
        {
            var lista = PR_aPieImprenta_CD._Instancia.Lista_PieImprenta().ToList();
            return from buscar in lista where buscar.Descripcion == descripcion select buscar;
        }

        public string Agregar(PR_aPieImprenta pieimprenta)
        {
            if (Buscar_Descripcion(pieimprenta.Descripcion).Count() > 0) return "Existe un PieImprenta Registrado";
            return PR_aPieImprenta_CD._Instancia.Agregar_PieImprenta(pieimprenta);
        }

        public string Actualizar(PR_aPieImprenta pieimprenta)
        {
            if (Buscar_Descripcion(pieimprenta.Descripcion).Count() > 0) return "Existe un PieImprenta Registrado";
            return PR_aPieImprenta_CD._Instancia.Actualizar_PieImprenta(pieimprenta);
        }

        public string Eliminar(Int32 idpieimprenta)
        { return PR_aPieImprenta_CD._Instancia.Eliminar_PieImprenta(idpieimprenta); }

    }
}
