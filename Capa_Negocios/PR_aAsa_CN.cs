using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aAsa_CN
    {
        public static readonly PR_aAsa_CN _Instancia = new PR_aAsa_CN();

        public static PR_aAsa_CN Instancia
        { get { return PR_aAsa_CN._Instancia; } }

        public List<PR_aAsa> Lista_Asas()
        { return PR_aAsa_CD._Intancia.Lista_Asas().ToList(); }

        public IEnumerable<PR_aAsa> TraerID(byte idasa)
        { return PR_aAsa_CD._Intancia.Traer_AsaPorId(idasa); }

        public IEnumerable<PR_aAsa> Buscar_Nombre(string descripcion)
        {
            var lst = PR_aAsa_CD._Intancia.Lista_Asas().ToList();
            return from AD in lst where AD.Descripcion_Asa == descripcion select AD;
        }

        public string Agregar_Asa(PR_aAsa asa)
        {
            if (Buscar_Nombre(asa.Descripcion_Asa).Count() > 0) return "Existe Tipo asa Registrado";
            return PR_aAsa_CD._Intancia.Agregar_Asa(asa);
        }

        public string Actualizar_Asa(PR_aAsa asa)
        {
            if (Buscar_Nombre(asa.Descripcion_Asa).Count() > 0) return "Existe Tipo asa Registrado";
            return PR_aAsa_CD._Intancia.Actualizar_Asa(asa);
        }

        public string Eliminar_Asa(Int32 idasa)
        { return PR_aAsa_CD._Intancia.Eliminar_Asa(idasa); }
    }
}
