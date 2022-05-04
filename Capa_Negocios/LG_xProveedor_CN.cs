using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using DapperExtensions;
using DapperExtensions.Predicate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_xProveedor_CN
    {
        public static readonly LG_xProveedor_CN _Instancia = new LG_xProveedor_CN();

        public static LG_xProveedor_CN Instancia
        { get { return LG_xProveedor_CN._Instancia; } }


        public List<LG_xProveedor> Lista_Proveedores()
        {
            return LG_xProveedor_CD.Instancia.Lista_Proveedores();
        }

        public LG_xProveedor TraerPorId(Int32 idproveedor)
        {
            return LG_xProveedor_CD.Instancia.TraerPorIDProveedor(idproveedor);
        }

        public IEnumerable<LG_xProveedor> FiltrarPorRazonsocial(string razonsocial)
        {
            var lista = LG_xProveedor_CD.Instancia.Lista_Proveedores();
            return from Buscar in lista where Buscar.Razon_Social_Proveedor == razonsocial select Buscar;
        }

        public IEnumerable<LG_xProveedor> FiltrarPorRUC(string RUC)
        {
            var lista = LG_xProveedor_CD.Instancia.Lista_Proveedores();
            return from Buscar in lista where Buscar.RUC_Proveedor == RUC select Buscar;
        }

        public string Agregar_Proveedor(LG_xProveedor proveedor)
        {
            if (FiltrarPorRazonsocial(proveedor.Razon_Social_Proveedor).Count() > 0) return "YA EXISTE LA RAZON SOCIAL";
            if (FiltrarPorRUC(proveedor.RUC_Proveedor).Count() > 0) return "YA EXISTE EL RUC REGISTRADO";
            return LG_xProveedor_CD._Instancia.Agregar_Proveedor(proveedor);
        }

        public string Actualizar_Proveedor(LG_xProveedor proveedor)
        {
            if (FiltrarPorRazonsocial(proveedor.Razon_Social_Proveedor).Count() > 0) return "YA EXISTE LA RAZON SOCIAL";
            if (FiltrarPorRUC(proveedor.RUC_Proveedor).Count() > 0) return "YA EXISTE EL RUC REGISTRADO";
            return LG_xProveedor_CD._Instancia.Actualizar_Proveedor(proveedor);
        }

        public string Eliminar_Proveedor(Int32 idproveedor)
        {
            var lista = PR_mMaquina_CD.Instancia.Listar();
            if((from Buscar in lista where Buscar.IdProveedor == idproveedor select Buscar).Count() > 0 ) return "EXISTE MAQUINAS DE ESTE PROVEEDOR";
            return LG_xProveedor_CD._Instancia.Eliminar_Proveedor(idproveedor);
        }



    }
}
