using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aTipoVenta_CN
    {
        public static readonly PR_aTipoVenta_CN _Instancia = new PR_aTipoVenta_CN();

        public static PR_aTipoVenta_CN Instancia
        { get { return PR_aTipoVenta_CN._Instancia; } }

        public List<PR_aTipoVenta> Lista_TipoVenta()
        { return PR_aTipoVenta_CD.Instancia.Lista_TipoVenta().ToList(); }

        public PR_aTipoVenta TraerPorId(byte idtipoventa)
        {
            return PR_aTipoVenta_CD._Intancia.Traer_TipoVentaPorId(idtipoventa);
        }

        public string Agregar_TipoVenta(PR_aTipoVenta tipoventa)
        {
            var lsta = PR_aTipoVenta_CD.Instancia.Lista_TipoVenta().ToList();
           if( lsta.Count(x => x.TipoVenta == tipoventa.TipoVenta)> 0) return "EXISTE ESTE TIPO VENTA";
            else  return PR_aTipoVenta_CD._Intancia.Agregar_TipoVenta(tipoventa);
        }

        public string Actualizar_TipoVenta(PR_aTipoVenta tipoventa)
        {
            var lsta = PR_aTipoVenta_CD.Instancia.Lista_TipoVenta().ToList();
            if (lsta.Select(x => x.TipoVenta == tipoventa.TipoVenta).Count() > 0) return "EXISTE ESTE TIPO VENTA";
            else return PR_aTipoVenta_CD._Intancia.Actualizar_TipoVenta(tipoventa);
        }

        public string Eliminar_TipoVenta(byte idtipoventa)
        {
            return PR_aTipoVenta_CD._Intancia.Eliminar_TipoVenta(idtipoventa);
        }



    }
}
