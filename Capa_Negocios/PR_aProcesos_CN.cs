using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aProcesos_CN
    {
        public static readonly PR_aProcesos_CN _Instancia = new PR_aProcesos_CN();

        public static PR_aProcesos_CN Instancia
        { get { return PR_aProcesos_CN._Instancia; } }

        public List<PR_aProcesos> Lista_Procesos()
        { return PR_aProcesos_CD._Instancia.Lista_Procesos().ToList(); }

        public IEnumerable<PR_aProcesos> TraerPorID(Int32 id)
        { return PR_aProcesos_CD._Instancia.Traer_ProcesosPorId(id); }

        public IEnumerable<PR_aProcesos> Buscar_SecuenciaProcesos(string secuenciaproc)
        {
            var lista = PR_aProcesos_CD._Instancia.Lista_Procesos().ToList();
            return from buscar in lista where buscar.Secuencia_Procesos == secuenciaproc select buscar;
        }

        public string Agregar(PR_aProcesos procesos)
        {
            if (Buscar_SecuenciaProcesos(procesos.Secuencia_Procesos).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aProcesos_CD._Instancia.Agregar_Procesos(procesos);
        }

        public string Actualizar(PR_aProcesos procesos)
        {
            if (Buscar_SecuenciaProcesos(procesos.Secuencia_Procesos).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aProcesos_CD._Instancia.Actualizar_Procesos(procesos);
        }

        public string Eliminar(Int32 idproceso)
        { return PR_aProcesos_CD._Instancia.Eliminar_Procesos(idproceso); }

    }
}
