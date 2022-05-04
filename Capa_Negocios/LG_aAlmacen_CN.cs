using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aAlmacen_CN
    {
        public static readonly LG_aAlmacen_CN Instancia = new LG_aAlmacen_CN();

        public static LG_aAlmacen_CN _Instancia
        { get { return LG_aAlmacen_CN.Instancia; } }

        public List<LG_aAlmacen>Lista_Almacen()
        { return LG_aAlmacen_CD._Instancia.Lista_Almacenes().ToList();}

        public IEnumerable<LG_aAlmacen>traerPorID(int idalmacen)
        { return LG_aAlmacen_CD._Instancia.Traer_AlamcenPorId(idalmacen); }

        public IEnumerable<LG_aAlmacen> Buscar_NombreAlmacen(string nombrealmacen)
        {
            var lst = LG_aAlmacen_CD._Instancia.Lista_Almacenes().ToList();
            return from ALM in lst where ALM.Nombre_Almacen == nombrealmacen select ALM;
        }

        public IEnumerable<LG_aAlmacen> Buscar_AlmacenPorEmpresa(Int32 idempresa)
        {
            var lst = LG_aAlmacen_CD._Instancia.Lista_Almacenes().ToList();
           return from ALM in lst where ALM.IdEmpresa == idempresa select ALM;
        }

        public string Agregar(LG_aAlmacen almacen)
        {
            if( Buscar_NombreAlmacen(almacen.Nombre_Almacen).ToList().Count > 0)return "YA EXISTE EL ALMACEN";
            return LG_aAlmacen_CD._Instancia.Agregar_Almacen(almacen);
        }

        public String Actualizar(LG_aAlmacen almacen)
        {
            if (Buscar_NombreAlmacen(almacen.Nombre_Almacen).ToList().Count > 0) return "YA EXISTE EL ALMACEN";
            return LG_aAlmacen_CD._Instancia.Actualizar_Almacen(almacen);
        }

        public string Eliminar(Int32 idalmacen)
        {
            return LG_aAlmacen_CD._Instancia.Eliminar_Almacen(idalmacen);
        }

    }
}
