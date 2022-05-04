using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoProcesoCorte_CN
    {
        public static readonly PR_aTipoProcesoCorte_CN _Instancia = new PR_aTipoProcesoCorte_CN();

        public static PR_aTipoProcesoCorte_CN Instancia
        { get { return PR_aTipoProcesoCorte_CN._Instancia; } }

        public List<PR_aTipoProcesoCorte> Lista_TipoProcesoCorte()
        { return PR_aTipoProcesoCorte_CD._Instancia.Lista_TipoProcesoCorte().ToList(); }

        public IEnumerable<PR_aTipoProcesoCorte> TraerPorID(Int32 id)
        { return PR_aTipoProcesoCorte_CD._Instancia.Traer_TipoProcesoCortePorId(id); }

        public IEnumerable<PR_aTipoProcesoCorte> Buscar_TipoProcesoCorte(string tipoprocesocorte)
        {
            var lista = PR_aTipoProcesoCorte_CD._Instancia.Lista_TipoProcesoCorte().ToList();
            return from buscar in lista where buscar.Nombre_TipoProcesoCorte == tipoprocesocorte select buscar; 
        }

        public string Agregar_TipoProcesoCorte(PR_aTipoProcesoCorte tipoprocesocorte)
        {
            if (Buscar_TipoProcesoCorte(tipoprocesocorte.Nombre_TipoProcesoCorte).Count() > 0) return "EXISTE TIPO PROCESO CORTE";
            return PR_aTipoProcesoCorte_CD._Instancia.Agregar_TipoProcesoCorte(tipoprocesocorte);
        }

        public string Actualizar_TipoProcesoCorte(PR_aTipoProcesoCorte tipoprocesocorte)
        {
            if (Buscar_TipoProcesoCorte(tipoprocesocorte.Nombre_TipoProcesoCorte).Count() > 0) return "EXISTE TIPO PROCESO CORTE";
            return PR_aTipoProcesoCorte_CD._Instancia.Actualizar_TipoProcesoCorte(tipoprocesocorte);
        }

        public string Eliminar_TipoProcesoCorte(Int32 idtipoprocesocorte)
        { return PR_aTipoProcesoCorte_CD._Instancia.Eliminar_TipoProcesoCorte(idtipoprocesocorte); }
    }
}
