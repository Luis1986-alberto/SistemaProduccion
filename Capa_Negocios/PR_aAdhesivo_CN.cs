using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aAdhesivo_CN
    {
        public static readonly PR_aAdhesivo_CN _Instancia = new PR_aAdhesivo_CN();

        public static PR_aAdhesivo_CN Instancia
        { get { return PR_aAdhesivo_CN._Instancia; } }

        public List<PR_aAdhesivo>Lista_Adhesivos()
        { return PR_aAdhesivo_CD._Instancia.Lista_adhesivos().ToList(); }

        public IEnumerable<PR_aAdhesivo> TraerID(byte idadesivo)
        { return PR_aAdhesivo_CD._Instancia.Traer_AdhesivoPorId(idadesivo); }

        public IEnumerable<PR_aAdhesivo> Buscar_Nombre(string descripcion)
        {
            var lst = PR_aAdhesivo_CD._Instancia.Lista_adhesivos().ToList();
            return from AD in lst where AD.Descripcion_Adhesivo == descripcion select AD;
        }

        public string Agregar_Adhesivos(PR_aAdhesivo adhesivo)
        {
           if( Buscar_Nombre(adhesivo.Descripcion_Adhesivo).Count() > 0) return "Existe Adhesivo Registrado";
           return PR_aAdhesivo_CD._Instancia.Agregar_Adhesivo(adhesivo);
        }

        public string Actualizar_Adhesivo(PR_aAdhesivo adhesivo)
        {
            if (Buscar_Nombre(adhesivo.Descripcion_Adhesivo).Count() > 0) return "Existe Adhesivo Registrado";
            return PR_aAdhesivo_CD._Instancia.Actualizar_Adhesivo(adhesivo);
        }

        public string Eliminar_Adhesivo(Int32 idadesivo)
        { return PR_aAdhesivo_CD._Instancia.Eliminar_Adhesivo(idadesivo); }


    }
}
