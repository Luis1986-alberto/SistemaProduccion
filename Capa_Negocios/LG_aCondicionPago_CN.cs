using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aCondicionPago_CN
    {
        public static readonly LG_aCondicionPago_CN Instancia = new LG_aCondicionPago_CN();

        public static LG_aCondicionPago_CN _Instancia
        { get { return LG_aCondicionPago_CN.Instancia; } }

        public List<LG_aCondicionPago> Lista_CondicionPago()
        { return LG_aCondicionPago_CD._Instancia.Lista_CondicionPago().ToList(); }

        public LG_aCondicionPago TraerPorID(int idcondicionpago)
        { return LG_aCondicionPago_CD._Instancia.Traer_CondicionPagoPorId(idcondicionpago); }

        public IEnumerable<LG_aCondicionPago> Buscar_CondicionPago(string condicionpago)
        {
            var lst = LG_aCondicionPago_CD._Instancia.Lista_CondicionPago();
            return from CON in lst where CON.Nombre_Condicion_Pago == condicionpago select CON;
        }

        public string Agregar(LG_aCondicionPago condicionpago)
        {
            if (Buscar_CondicionPago(condicionpago.Nombre_Condicion_Pago).ToList().Count > 0) return "YA EXISTE LA CONDICION PAGO";
            return LG_aCondicionPago_CD._Instancia.Agregar_CondicionPago(condicionpago);
        }

        public String Actualizar(LG_aCondicionPago condicionpago)
        {
            if (Buscar_CondicionPago(condicionpago.Nombre_Condicion_Pago).ToList().Count > 0) return "YA EXISTE EL CONDICION PAGO";
            return LG_aCondicionPago_CD._Instancia.Actualizar_CondicionPago(condicionpago);
        }

        public string Eliminar(Int32 idcondicionpago)
        {
            return LG_aCondicionPago_CD._Instancia.Eliminar_CondicionPago(idcondicionpago);
        }


    }
}
