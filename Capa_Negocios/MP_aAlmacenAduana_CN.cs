using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class MP_aAlmacenAduana_CN
    {
        public static readonly MP_aAlmacenAduana_CN _Instancia = new MP_aAlmacenAduana_CN();

        public static MP_aAlmacenAduana_CN Instancia
        { get { return MP_aAlmacenAduana_CN._Instancia; } }


        public List<MP_aAlmacenAduana>Lista_AlmacenesAduana()
        { return MP_aAlmacenAduana_CD._Instancia.Lista_AlmacenAduanero().ToList(); }

        public IEnumerable<MP_aAlmacenAduana>TraerPorId(Int32 idalmacenaduana)
        { return MP_aAlmacenAduana_CD._Instancia.Traer_AgenteAduaneroPorId(idalmacenaduana); }

        public IEnumerable<MP_aAlmacenAduana>Buscar_Nombre(string nombrealmacen)
        {
            var lista = MP_aAlmacenAduana_CD._Instancia.Lista_AlmacenAduanero();
            return from ALM in lista where ALM.Nombre_AlmacenAduana == nombrealmacen select ALM; 
        }

        public string Agregar(MP_aAlmacenAduana almacenaduana)
        {
            if (Buscar_Nombre(almacenaduana.Nombre_AlmacenAduana).Count() > 0) return "EXISTE ESTE ALMACEN REGISTRADO";
            return MP_aAlmacenAduana_CD.Instancia.Agregar_AlmacenAduana(almacenaduana);
        }

        public string Actualizar(MP_aAlmacenAduana almacenaduana)
        {
            if (Buscar_Nombre(almacenaduana.Nombre_AlmacenAduana).Count() > 0) return "EXISTE ESTE ALMACEN REGISTRADO";
            return MP_aAlmacenAduana_CD.Instancia.Actualizar_AgenteAduanero(almacenaduana);
        }

        public string Eliminar(Int32 idalmacenaduana)
        {
            return MP_aAlmacenAduana_CD.Instancia.Eliminar_AgenteAduanero(idalmacenaduana);
        }


    }
}
