using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aClaseServicioMaquina_CN
    {
        public static readonly LG_aClaseServicioMaquina_CN Instancia = new LG_aClaseServicioMaquina_CN();

        public static LG_aClaseServicioMaquina_CN _Instancia
        { get { return LG_aClaseServicioMaquina_CN.Instancia; } }

        public List<LG_aClaseServicioMaquina> Lista_ClaseServicioMaquina()
        { return LG_aClaseServicioMaquina_CN._Instancia.Lista_ClaseServicioMaquina().ToList(); }

        public LG_aClaseServicioMaquina traerPorID(int idclaseserviciomaquina)
        { return LG_aClaseServicioMaquina_CD._Instancia.TraerPorIdClaseServicioMaquina(idclaseserviciomaquina); }

        public IEnumerable<LG_aClaseServicioMaquina> Buscar_Descripcion(string descripcion)
        {
            var lst = LG_aClaseServicioMaquina_CD._Instancia.Lista_ClaseServicioMaquina();
            return from CSM in lst where CSM.Descripcion_ClaseServicio == descripcion select CSM;
        }

        public string Agregar(LG_aClaseServicioMaquina claseserviciomaquina)
        {
            if (Buscar_Descripcion(claseserviciomaquina.Descripcion_ClaseServicio).ToList().Count > 0) return "YA EXISTE LA CLASE";
            return LG_aClaseServicioMaquina_CD._Instancia.Agregar_ClaseServicioMaquina(claseserviciomaquina);
        }

        public String Actualizar(LG_aClaseServicioMaquina claseserviciomaquina)
        {
            if (Buscar_Descripcion(claseserviciomaquina.Descripcion_ClaseServicio).ToList().Count > 0) return "YA EXISTE EL CLASE";
            return LG_aClaseServicioMaquina_CD._Instancia.Actualizar_ClaseServicioMaquina(claseserviciomaquina);
        }

        public string Eliminar(Int32 idclseserviciomaquina)
        {
            return LG_aClaseServicioMaquina_CD._Instancia.Eliminar_ClaseServicioMaquina(idclseserviciomaquina);
        }

    }
}
