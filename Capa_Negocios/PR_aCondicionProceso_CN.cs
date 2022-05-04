using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aCondicionProceso_CN
    {
        public static readonly PR_aCondicionProceso_CN _Instancia = new PR_aCondicionProceso_CN();

        public static PR_aCondicionProceso_CN Instancia
        { get { return PR_aCondicionProceso_CN._Instancia; } }

        public List<PR_aCondicionProceso> Lista_CondicionProceso()
        { return PR_aCondicionProceso_CD._Instancia.Lista_CondicionProceso().ToList(); }

        public IEnumerable<PR_aCondicionProceso> TraerID(Int32 idcondicionpago)
        { return PR_aCondicionProceso_CD._Instancia.Traer_CondicionProcesoPorId(idcondicionpago); }

        public IEnumerable<PR_aCondicionProceso> Buscar_Nombre(string nombrecondicion)
        {
            var lst = PR_aCondicionProceso_CD._Instancia.Lista_CondicionProceso().ToList();
            return from AD in lst where AD.Nombre_CondicionProceso == nombrecondicion select AD;
        }

        public string Agregar_CondicionProceso(PR_aCondicionProceso condicionproceso)
        {
            if (Buscar_Nombre(condicionproceso.Nombre_CondicionProceso).Count() > 0) return "Existe la Condicion Registrado";
            return PR_aCondicionProceso_CD._Instancia.Agregar_CondicionProceso(condicionproceso);
        }

        public string Actualizar_CondicionProceso(PR_aCondicionProceso condicionproceso)
        {
            if (Buscar_Nombre(condicionproceso.Nombre_CondicionProceso).Count() > 0) return "Existe Adhesivo Registrado";
            return PR_aCondicionProceso_CD._Instancia.Actualizar_CondicionProceso(condicionproceso);
        }

        public string Eliminar_CondicionProceso(Int32 idcondicionproceso)
        { return PR_aCondicionProceso_CD._Instancia.Eliminar_CondicionProceso(idcondicionproceso); }
    }
}
