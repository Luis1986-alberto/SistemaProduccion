using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aEspesorTuco_CN
    {
        public static readonly PR_aEspesorTuco_CN _Instancia = new PR_aEspesorTuco_CN();

        public static PR_aEspesorTuco_CN Instancia
        { get { return PR_aEspesorTuco_CN._Instancia; } }

        public List<PR_aEspesorTuco> Lista_EspesorTuco()
        { return PR_aEspesorTuco_CD._Instancia.Lista_EspesorTuco().ToList(); }

        public IEnumerable<PR_aEspesorTuco> TraerPorID(byte id)
        { return PR_aEspesorTuco_CD._Instancia.Traer_EspesortucoPorId(id); }

        public IEnumerable<PR_aEspesorTuco> Buscar_espesortuco(decimal espesortuco)
        {
            var lst = PR_aEspesorTuco_CD._Instancia.Lista_EspesorTuco().ToList();
            return from AD in lst where AD.Medida_EspesorTuco == espesortuco select AD;
        }

        public string Agregar_EspesorTuco(PR_aEspesorTuco espesortuco)
        {
            if (Buscar_espesortuco(espesortuco.Medida_EspesorTuco).Count() > 0) return "Existe medida espesor Registrado";
            return PR_aEspesorTuco_CD._Instancia.Agregar_EspesorTuco(espesortuco);
        }

        public string Actualizar_EspesorTuco(PR_aEspesorTuco espesortuco)
        {
            if (Buscar_espesortuco(espesortuco.Medida_EspesorTuco).Count() > 0) return "Existe medida espesor Registrado";
            return PR_aEspesorTuco_CD._Instancia.Actualizar_EspesorTuco(espesortuco);
        }

        public string Eliminar_EspesorTuco(byte idespesortuco)
        { return PR_aEspesorTuco_CD._Instancia.Eliminar_EspesorTuco(idespesortuco); }

    }
}
