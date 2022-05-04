using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aTipoServicioMaquina_CN
    {
        public static readonly LG_aTipoServicioMaquina_CN _Instancia = new LG_aTipoServicioMaquina_CN();

        public static LG_aTipoServicioMaquina_CN Instancia
        { get { return LG_aTipoServicioMaquina_CN._Instancia; } }

        public List<LG_aTipoServicioMaquina> Lista_ServicioMaquina()
        { return LG_aTipoServicioMaquina_CD._Instancia.Lista_ServicioMaquina().ToList(); }

        public LG_aTipoServicioMaquina TraerPorID(Int32 idserviciomaq)
        { return LG_aTipoServicioMaquina_CD._Instancia.TraerPorIdServicioMaquina(idserviciomaq); }

        public IEnumerable<LG_aTipoServicioMaquina> Buscar_SerivioMaquina(string tiposerviciomaq)
        {
            var lista = LG_aTipoServicioMaquina_CD._Instancia.Lista_ServicioMaquina().ToList();
            return from buscar in lista where buscar.Descripcion_TipoServicio == tiposerviciomaq select buscar;
        }

        public string Agregar(LG_aTipoServicioMaquina tiposerviciomaq)
        {
            if (Buscar_SerivioMaquina(tiposerviciomaq.Descripcion_TipoServicio).Count() > 0) return "EXISTE TIPO SALIDA";
            return LG_aTipoServicioMaquina_CD._Instancia.Agregar_ServicioMaquina(tiposerviciomaq);
        }

        public string Actualizar(LG_aTipoServicioMaquina tiposerviciomaq)
        {
            if (Buscar_SerivioMaquina(tiposerviciomaq.Descripcion_TipoServicio).Count() > 0) return "EXISTE TIPO LAMINACION";
            return LG_aTipoServicioMaquina_CD._Instancia.Actualizar_ServicioMaquina(tiposerviciomaq);
        }

        public string Eliminar (Int32 idtiposerviciomaq)
        { return LG_aTipoServicioMaquina_CD._Instancia.Eliminar_ServicioMaquina(idtiposerviciomaq); }


    }
}
