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
    public class LG_aTipoProveedor_CN
    {
        public static readonly LG_aTipoProveedor_CN _Instancia = new LG_aTipoProveedor_CN();

        public static LG_aTipoProveedor_CN Instancia
        { get { return LG_aTipoProveedor_CN._Instancia; } }

        public IEnumerable<LG_aTipoProveedor> Lista_TipoProveedor()
        { return LG_aTipoProveedor_CD._Instancia.Lista_TipoProveedor(); }

        public LG_aTipoProveedor TraerPorID(int idtipoproveedor)
        { return LG_aTipoProveedor_CD._Instancia.TraerPorIdTipoProveedor(idtipoproveedor); }

        public IEnumerable<LG_aTipoProveedor> Buscar_TipoProveedor(string tipoproveedor)
        {
            var LISTA = LG_aTipoProveedor_CD._Instancia.Lista_TipoProveedor();
            return from buscar in LISTA where buscar.Tipo_Proveedor == tipoproveedor select buscar;
        }

        public string Agregar(LG_aTipoProveedor tipoproveedor)
        {
            if (Buscar_TipoProveedor(tipoproveedor.Tipo_Proveedor).ToList().Count > 0) return "YA EXISTE TIPO PROVEEDOR ";
            return LG_aTipoProveedor_CD._Instancia.Agregar_TipoProveedor(tipoproveedor);
        }

        public String Actualizar(LG_aTipoProveedor tipoproveedor)
        {
            if (Buscar_TipoProveedor(tipoproveedor.Tipo_Proveedor).ToList().Count > 0) return "YA EXISTE TIPO PROVEEDOR ";
            return LG_aTipoProveedor_CD._Instancia.Actualizar_TipoProveedor(tipoproveedor);
        }

        public string Eliminar(Int32 idtipoproveedor)
        {
            return LG_aTipoProveedor_CD._Instancia.Eliminar_TipoProveedor(idtipoproveedor);
        }


    }
}
