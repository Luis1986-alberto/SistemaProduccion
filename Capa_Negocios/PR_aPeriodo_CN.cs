using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aPeriodo_CN
    {
        public static readonly PR_aPeriodo_CN _Instancia = new PR_aPeriodo_CN();

        public static PR_aPeriodo_CN Instancia
        { get { return PR_aPeriodo_CN._Instancia; } }

        public List<PR_aPeriodo> Lista_Periodos()
        { return PR_aPeriodo_CD._Instancia.Lista_Periodos().ToList(); }

        public IEnumerable<PR_aPeriodo> TraerPorID(Int32 id)
        { return PR_aPeriodo_CD._Instancia.Traer_PeriodosPorId(id); }

        public IEnumerable<PR_aPeriodo> Buscar_NombrePeriodo(string nombreperiodo)
        {
            var lista = PR_aPeriodo_CD._Instancia.Lista_Periodos().ToList();
            return from buscar in lista where buscar.Nombre_Periodo == nombreperiodo select buscar;
        }

        public string Agregar_Periodo(PR_aPeriodo periodo)
        {
            if (Buscar_NombrePeriodo(periodo.Nombre_Periodo).Count() > 0) return "Existe un Periodo Registrado";
            return PR_aPeriodo_CD._Instancia.Agregar_Periodo(periodo);
        }

        public string Actualizar_Periodo(PR_aPeriodo periodo)
        {
            if (Buscar_NombrePeriodo(periodo.Nombre_Periodo).Count() > 0) return "Existe un Periodo Registrado";
            return PR_aPeriodo_CD._Instancia.Actualizar_Periodo(periodo);
        }

        public string Eliminar_Periodo(Int32 idperiodo)
        { return PR_aPeriodo_CD._Instancia.Eliminar_Periodo(idperiodo); }

    }
}
