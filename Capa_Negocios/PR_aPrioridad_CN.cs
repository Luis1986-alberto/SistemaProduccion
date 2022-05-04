using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aPrioridad_CN
    {
        public static readonly PR_aPrioridad_CN _Instancia = new PR_aPrioridad_CN();

        public static PR_aPrioridad_CN Instancia
        { get { return PR_aPrioridad_CN._Instancia; } }

        public List<PR_aPrioridad> Lista_Prioridades()
        { return PR_aPrioridad_CD._Instancia.Lista_Priodidades().ToList(); }

        public IEnumerable<PR_aPrioridad> TraerPorID(Int32 id)
        { return PR_aPrioridad_CD._Instancia.Traer_PrioridadesPorId(id); }

        public IEnumerable<PR_aPrioridad> Buscar_Descripcion(string descripcion)
        {
            var lista = PR_aPrioridad_CD._Instancia.Lista_Priodidades().ToList();
            return from buscar in lista where buscar.Descripcion_Prioridad == descripcion select buscar;
        }

        public string Agregar_Prioridad(PR_aPrioridad prioridad)
        {
            if (Buscar_Descripcion(prioridad.Descripcion_Prioridad).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aPrioridad_CD._Instancia.Agregar_Prioriad(prioridad);
        }

        public string Actualizar_Prioridad(PR_aPrioridad prioridad)
        {
            if (Buscar_Descripcion(prioridad.Descripcion_Prioridad).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aPrioridad_CD._Instancia.Actualizar_Prioridad(prioridad);
        }

        public string Eliminar_Prioridad(Int32 idprioridad)
        { return PR_aPrioridad_CD._Instancia.Eliminar_Prioridad(idprioridad); }

    }
}
