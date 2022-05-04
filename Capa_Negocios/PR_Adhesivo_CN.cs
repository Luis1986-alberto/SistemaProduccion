using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_Adhesivo_CN
    {
        public static readonly PR_aAdhesivo_CN Instancia = new PR_aAdhesivo_CN();

        public static PR_aAdhesivo_CN _Instancia
        { get { return PR_aAdhesivo_CN.Instancia; } }

        public List<PR_aAdhesivo> Lista_adhesivos()
        { return PR_aAdhesivo_CD.Instancia.Lista_adhesivos().ToList(); }

        public IEnumerable<PR_aAdhesivo> TraerPorId(byte idadhesivo)
        { return PR_aAdhesivo_CD.Instancia.Traer_AdhesivoPorId(idadhesivo); }

        public IEnumerable<PR_aAdhesivo>Buscar_descripcion(string descripcion)
        {
            var lista = PR_aAdhesivo_CD.Instancia.Lista_adhesivos();
            return from buscar in lista where buscar.Descripcion_Adhesivo == descripcion select buscar;
        }

        public string Agregar_Adhesivo(PR_aAdhesivo adhesivo)
        {
            if (Buscar_descripcion(adhesivo.Descripcion_Adhesivo).Count() > 0) return "EXISTE ADHESIVO REGISTRADO";
            return PR_aAdhesivo_CD.Instancia.Agregar_Adhesivo(adhesivo);
        }

        public string Actualizar_Adhesivo(PR_aAdhesivo adhesivo)
        {
            if (Buscar_descripcion(adhesivo.Descripcion_Adhesivo).Count() > 0) return "EXISTE ADHESIVO REGISTRADO";
            return PR_aAdhesivo_CD.Instancia.Actualizar_Adhesivo(adhesivo);
        }

        public string Eliminar_adhesivo(int idadhesivo)
        {
            return PR_aAdhesivo_CD.Instancia.Eliminar_Adhesivo(idadhesivo);
        }


    }
}
