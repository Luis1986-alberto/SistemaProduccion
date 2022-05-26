using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aTipoRubro_CN
    {
        public static readonly PR_aTipoRubro_CN _instancia = new PR_aTipoRubro_CN();

        public static PR_aTipoRubro_CN Instancia
        { get { return PR_aTipoRubro_CN._instancia; } }

        public List<PR_aTipoRubro> Lista_TipoRubro()
        { return PR_aTipoRubro_CD._Instancia.Lista_TipoRubros().ToList(); }

        public List<PR_aTipoRubro> TraerPorId(byte idtiporunro)
        { return PR_aTipoRubro_CD._Instancia.Traer_TipoRubrosPorId(idtiporunro).ToList(); }

        public IEnumerable<PR_aTipoRubro> Buscar_TipoRubro(string tiporubro)
        {
            var lista = PR_aTipoRubro_CD._Instancia.Lista_TipoRubros().ToList();
            return from buscar in lista where buscar.Nombre_TipoRubro == tiporubro select buscar;
        }

        public string Agregar(PR_aTipoRubro tiporubro)
        {
            if (Buscar_TipoRubro(tiporubro.Nombre_TipoRubro).Count() > 0) return "EXISTE ESTE RUBRO REGISTRADO";
            return PR_aTipoRubro_CD._Instancia.Agregar_TipoRubro(tiporubro);
        }

        public string Actualizar(PR_aTipoRubro tiporubro)
        {
            if (Buscar_TipoRubro(tiporubro.Nombre_TipoRubro).Count() > 0) return "EXISTE ESTE RUBRO REGISTRADO";
            return PR_aTipoRubro_CD._Instancia.Actualizar_TipoRubro(tiporubro);
        }

        public string Eliminar(byte idtiporubro)
        { return PR_aTipoRubro_CD._Instancia.Eliminar_TipoRubro(idtiporubro); }

    }
}
