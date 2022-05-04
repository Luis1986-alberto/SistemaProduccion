using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aSemana_CN
    {
        public static readonly PR_aSemana_CN _Instancia = new PR_aSemana_CN();

        public static PR_aSemana_CN Instancia
        { get { return PR_aSemana_CN._Instancia; } }

        public List<PR_aSemana> Lista_Semana()
        { return PR_aSemana_CD._Instancia.Lista_Semanas().ToList(); }

        public IEnumerable<PR_aSemana> TraerPorID(Int32 id)
        { return PR_aSemana_CD._Instancia.Traer_SemanaPorId(id); }

        public IEnumerable<PR_aSemana> Buscar_NombreSemana(string nombresemana)
        {
            var lista = PR_aSemana_CD._Instancia.Lista_Semanas().ToList();
            return from buscar in lista where buscar.Nombre_Semana == nombresemana select buscar;
        }

        public string Agregar_Semana(PR_aSemana semana)
        {
            if (Buscar_NombreSemana(semana.Nombre_Semana).Count() > 0) return "Existe una semana Registrado";
            return PR_aSemana_CD._Instancia.Agregar_Semana(semana);
        }

        public string Actualizar_Semana(PR_aSemana semana)
        {
            if (Buscar_NombreSemana(semana.Nombre_Semana).Count() > 0) return "Existe una  Semana Registrado";
            return PR_aSemana_CD._Instancia.Actualizar_Semana(semana);
        }

        public string Eliminar_Semana(Int32 idsemana)
        { return PR_aSemana_CD._Instancia.Eliminar_Semana(idsemana); }

    }
}
