using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xKardexCom_PT
    {
        public decimal IdKardexCom { get; set; }
        public Nullable<decimal> Saldo_Inicial_Cant_PFCR { get; set; }
        public Nullable<decimal> Ingresos_Cant_PFCR { get; set; }
        public Nullable<decimal> Salida_Cant_PFCR { get; set; }
        public Nullable<decimal> Saldo_Cant_PFCR { get; set; }
        public Nullable<decimal> Saldo_Inicial_Millares { get; set; }
        public Nullable<decimal> Ingresos_Millares { get; set; }
        public Nullable<decimal> Salida_Millares { get; set; }
        public Nullable<decimal> Saldo_Millares { get; set; }
        public Nullable<decimal> Saldo_Inicial_Kilos { get; set; }
        public Nullable<decimal> Ingresos_Kilos { get; set; }
        public Nullable<decimal> Salida_Kilos { get; set; }
        public Nullable<decimal> Saldo_Kilos { get; set; }
        public Nullable<System.DateTime> Fecha_Movimiento { get; set; }
        public string Tipo_Movimiento { get; set; }
        public Nullable<decimal> Nro_Registro { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> IdStockProdCom_PT { get; set; }
        public string IdUsuario { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xStockProdTerm_Comercial PR_xStockProdTerm_Comercial { get; set; }
    }
}
