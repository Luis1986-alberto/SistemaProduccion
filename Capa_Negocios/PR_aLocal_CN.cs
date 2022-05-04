using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aLocal_CN
    {
        public static readonly PR_aLocal_CN _Instancia = new PR_aLocal_CN();

        public static PR_aLocal_CN Instancia
        { get { return PR_aLocal_CN._Instancia; } }

        public List<PR_aLocal> Lista_Locales()
        { return PR_aLocal_CD._Instancia.Lista_Locales().ToList(); }

        public IEnumerable<PR_aLocal> TraerPorID(Int32 id)
        { return PR_aLocal_CD._Instancia.Traer_LocalPorId(id); }

        public IEnumerable<PR_aLocal> Buscar_Nombrelocal(string nombrelocal)
        {
            var lista = PR_aLocal_CD._Instancia.Lista_Locales().ToList();
            return from buscar in lista where buscar.Nombre_Local == nombrelocal select buscar;
        }

        public string Agregar(PR_aLocal local)
        {
            if (Buscar_Nombrelocal(local.Nombre_Local).Count() > 0) return "Existe una local Registrado";
            return PR_aLocal_CD._Instancia.Agregar_Local(local);
        }

        public string Actualizar(PR_aLocal local)
        {
            if (Buscar_Nombrelocal(local.Nombre_Local).Count() > 0) return "Existe una local Registrado";
            return PR_aLocal_CD._Instancia.Actualizar_Local(local);
        }

        public string Eliminar(Int32 idlocal)
        { return PR_aLocal_CD._Instancia.Eliminar_Local(idlocal); }

    }
}
