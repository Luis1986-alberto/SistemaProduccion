using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aCodigoEvento_CN
    {
        public static readonly PR_aCodigoEvento_CN _Instancia = new PR_aCodigoEvento_CN();

        public static PR_aCodigoEvento_CN Instancia
        { get { return PR_aCodigoEvento_CN._Instancia; } }

        public List<PR_aCodigoEvento> Lista_CodigoEvento()
        { return PR_aCodigoEvento_CD._Instancia.Lista_CodigoEvento().ToList(); }

        public IEnumerable<PR_aCodigoEvento> TraerID(byte idcodigoevento)
        { return PR_aCodigoEvento_CD._Instancia.Traer_CodigoEventoPorId(idcodigoevento); }

        public IEnumerable<PR_aCodigoEvento> Buscar_Codigo(string codigo)
        {
            var lst = PR_aCodigoEvento_CD._Instancia.Lista_CodigoEvento().ToList();
            return from AD in lst where AD.Codigo_Evento == codigo select AD;
        }

        public string Agregar_CodigoEvento(PR_aCodigoEvento codigoevento)
        {
            if (Buscar_Codigo(codigoevento.Codigo_Evento).Count() > 0) return "Existe codigo Registrado";
            return PR_aCodigoEvento_CD._Instancia.Agregar_CodigoEvento(codigoevento);
        }

        public string Actualizar_CodigoEvento(PR_aCodigoEvento codigoevento)
        {
            if (Buscar_Codigo(codigoevento.Codigo_Evento).Count() > 0) return "Existe codigo Registrado";
            return PR_aCodigoEvento_CD._Instancia.Actualizar_CodigoEvento(codigoevento);
        }

        public string Eliminar_CodigoEvento(Int32 idcodigoevento)
        { return PR_aCodigoEvento_CD._Instancia.Eliminar_CodigoEvento(idcodigoevento); }
    }
}
