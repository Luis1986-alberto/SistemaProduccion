using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aAño_CN
    {
        public static readonly PR_aAño_CN _Instancia = new PR_aAño_CN();

        public static PR_aAño_CN Instancia
        { get { return PR_aAño_CN._Instancia; } }

        public List<PR_aAño> Lista_Años()
        { return PR_aAño_CD._Instancia.Lista_aAños().ToList(); }

        public IEnumerable<PR_aAño> TraerID(byte idaño)
        { return PR_aAño_CD._Instancia.Traer_AñoPorId(idaño); }

        public IEnumerable<PR_aAño> Buscar_Año(Int32 año)
        {
            var lst = PR_aAño_CD._Instancia.Lista_aAños().ToList();
            return from A in lst where A.Año == año select A;
        }

        public string Agregar_Año(PR_aAño año)
        {
            if (Buscar_Año(año.Año).Count() > 0) return "Existe Año Registrado";
            return PR_aAño_CD._Instancia.Agregar_Año(año);
        }

        public string Actualizar_Año(PR_aAño año)
        {
            if (Buscar_Año(año.Año).Count() > 0) return "Existe Año Registrado";
            return PR_aAño_CD._Instancia.Actualizar_Año(año);
        }

        public string Eliminar_Año(Int32 idaño)
        { return PR_aAño_CD._Instancia.Eliminar_Año(idaño); }



    }
}
