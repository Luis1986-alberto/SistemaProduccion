using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_xLocalArea_CN
    {
        public static readonly PR_xLocalArea_CN _Instancia = new PR_xLocalArea_CN();

        public static PR_xLocalArea_CN Instancia
        { get { return PR_xLocalArea_CN._Instancia; } }

        public List<PR_xLocalArea> Lista_Localarea()
        { return PR_xLocalArea_CD._Instancia.Lista_LocalArea().ToList(); }

        public IEnumerable<PR_xLocalArea> TraerIdLocalArea(int idlocalarea)
        {
            return (from buscar in PR_xLocalArea_CD._Instancia.Lista_LocalArea().ToList()
                    where buscar.IdLocalArea == idlocalarea
                    select buscar).ToList();
        }

        public IEnumerable<PR_xLocalArea> TraerIdLocal(int idlocal)
        {
            return (from buscar in PR_xLocalArea_CD._Instancia.Lista_LocalArea().ToList()
                    where buscar.IdLocal == idlocal
                    select buscar).ToList();
        }

        public string Agregar_LocalArea(PR_xLocalArea olocalarea)
        {
            return PR_xLocalArea_CD._Instancia.Agregar_LocalArea(olocalarea);
        }

        public string Actualizar_LocalArea(PR_xLocalArea olocalarea)
        {
            return PR_xLocalArea_CD._Instancia.Actualizar_LocalArea(olocalarea);
        }

        public string Eliminar_LocalArea(byte idlocalarea)
        {
            return PR_xLocalArea_CD._Instancia.Eliminar_LocalArea(idlocalarea);
        }

    }
}
