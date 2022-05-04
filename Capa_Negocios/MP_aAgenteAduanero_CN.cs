using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class MP_aAgenteAduanero_CN
    {
        public static readonly MP_aAgenteAduanero_CN Instancia = new MP_aAgenteAduanero_CN();

        public static MP_aAgenteAduanero_CN _Instancia
        { get { return MP_aAgenteAduanero_CN.Instancia; } }

        public List<MP_aAgenteAduanero>Lista_AgenteAduanero()
        { return MP_aAgenteAduanero_CD.Instancia.Lista_AgenteAduanero().ToList(); }

        public List<MP_aAgenteAduanero>TraerPorId(Int32 idagenteaduanero)
        { return MP_aAgenteAduanero_CD.Instancia.Traer_AgenteAduaneroPorId(idagenteaduanero).ToList(); }


        public IEnumerable<MP_aAgenteAduanero>Buscar_RazonSocialAgente(string razonsocialagente)
        {
            var lista = MP_aAgenteAduanero_CD.Instancia.Lista_AgenteAduanero();
            return from AD in lista where AD.Razon_Social_Agente == razonsocialagente select AD;
        }
        public IEnumerable<MP_aAgenteAduanero> Buscar_RUC(string RUC)
        {
            var lista = MP_aAgenteAduanero_CD.Instancia.Lista_AgenteAduanero();
            return from AD in lista where AD.Numero_RUC_Agente == RUC select AD;
        }

        public string Agregar(MP_aAgenteAduanero agenteaduanero)
        {
            if (Buscar_RazonSocialAgente(agenteaduanero.Razon_Social_Agente).Count() > 0) return "EXISTE ESTE AGENTE REGISTRADO";
            if (Buscar_RUC(agenteaduanero.Numero_RUC_Agente).Count() > 0) return "EXISTE ESTE AGENTE REGISTRADO";
            return MP_aAgenteAduanero_CD._instancia.Agregar_AgenteAduanero(agenteaduanero);
        }

        public string Actualizar(MP_aAgenteAduanero agenteaduanero)
        {
            if (Buscar_RazonSocialAgente(agenteaduanero.Razon_Social_Agente).Count() > 0) return "EXISTE ESTE AGENTE REGISTRADO";
            return MP_aAgenteAduanero_CD._instancia.Actualizar_AgenteAduanero(agenteaduanero);
        }

        public string Eliminar(Int32 idagenteaduanero)
        {   
            return MP_aAgenteAduanero_CD._instancia.Eliminar_AgenteAduanero(idagenteaduanero);
        }

    }
}
