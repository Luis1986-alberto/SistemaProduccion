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
    public class LG_aTipoCompra_CN
    {
        public static readonly LG_aTipoCompra_CN _Instancia = new LG_aTipoCompra_CN();

        public static LG_aTipoCompra_CN Instancia
        { get { return LG_aTipoCompra_CN._Instancia; } }

        public IEnumerable<LG_aTipoCompra> Lista_TipoCompra()
        { return LG_aTipoCompra_CD._Instancia.Lista_TipoCompra(); }

        public LG_aTipoCompra traerPorID(int idtipocompra)
        { return LG_aTipoCompra_CD._Instancia.TraerPorIdTipoCompra(idtipocompra); }

        public IEnumerable<LG_aTipoCompra> Buscar_TipoCompra(string tipocompra)
        {
            var predicado = Predicates.Field<LG_aTipoCompra>(x => x.Descripcion_TipoCompra, Operator.Eq, tipocompra);
            return LG_aTipoCompra_CD._Instancia.FiltroPorunCampo(predicado);
        }

        public string Agregar(LG_aTipoCompra tipocompra)
        {
            if (Buscar_TipoCompra(tipocompra.Descripcion_TipoCompra).ToList().Count > 0) return "YA EXISTE TIPO COMPRA ";
            return LG_aTipoCompra_CD._Instancia.Agregar_TipoCompra(tipocompra);
        }

        public String Actualizar(LG_aTipoCompra tipocompra)
        {
            if (Buscar_TipoCompra(tipocompra.Descripcion_TipoCompra).ToList().Count > 0) return "YA EXISTE TIPO COMPRA ";
            return LG_aTipoCompra_CD._Instancia.Actualizar_TipoCompra(tipocompra);
        }

        public string Eliminar(Int32 idtipocompra)
        {
            return LG_aTipoCompra_CD._Instancia.Eliminar_TipoCompra(idtipocompra);
        }
    }
}
