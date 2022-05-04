using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aPrecisionBalanza_CN
    {
        public static readonly PR_aPrecisionBalanza_CN _Instancia = new PR_aPrecisionBalanza_CN();

        public static PR_aPrecisionBalanza_CN Instancia
        { get { return PR_aPrecisionBalanza_CN._Instancia; } }

        public List<PR_aPrecisionBalanza> Lista_PresicionBalanza()
        { return PR_aPrecisionBalanza_CD._Instancia.Lista_PrecisionBalanza().ToList(); }

        public IEnumerable<PR_aPrecisionBalanza> TraerPorID(Int32 id)
        { return PR_aPrecisionBalanza_CD._Instancia.Traer_PrecisionBalanzaPorId(id); }

        public IEnumerable<PR_aPrecisionBalanza> Buscar_PresicionBalanza(decimal presicionbalanza)
        {
            var lista = PR_aPrecisionBalanza_CD._Instancia.Lista_PrecisionBalanza().ToList();
            return from buscar in lista where buscar.Precision_Balanza == presicionbalanza select buscar;
        }

        public string Agregar_PresicionBalanza(PR_aPrecisionBalanza precisionbalanza)
        {
            if (Buscar_PresicionBalanza(precisionbalanza.Precision_Balanza).Count() > 0) return "Existe una precision ya Registrado";
            return PR_aPrecisionBalanza_CD._Instancia.Agregar_PresicionBalanza(precisionbalanza);
        }

        public string Actualizar_PresicionBalanza(PR_aPrecisionBalanza precisionbalanza)
        {
            if (Buscar_PresicionBalanza(precisionbalanza.Precision_Balanza).Count() > 0) return "Existe una precision ya Registrado";
            return PR_aPrecisionBalanza_CD._Instancia.Actualizar_PresicionBalanza(precisionbalanza);
        }

        public string Eliminar_PresicionBalanza(Int32 idpresicionbalanza)
        { return PR_aPrecisionBalanza_CD._Instancia.Eliminar_Presicionbalanza(idpresicionbalanza); }

    }
}
