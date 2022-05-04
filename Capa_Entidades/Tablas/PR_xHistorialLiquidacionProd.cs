using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xHistorialLiquidacionProd
    {
        public Nullable<short> Flag_Mezclado { get; set; }
        public Nullable<System.DateTime> Fecha_Mezclado { get; set; }
        public string Nota_Mezclado { get; set; }
        public Nullable<short> Flag_Extrusion { get; set; }
        public Nullable<System.DateTime> Fecha_Extrusion { get; set; }
        public string Nota_Extrusion { get; set; }
        public Nullable<short> Flag_Impresion { get; set; }
        public Nullable<System.DateTime> Fecha_Impresion { get; set; }
        public string Nota_Impresion { get; set; }
        public Nullable<short> Flag_Sellado { get; set; }
        public Nullable<System.DateTime> Fecha_Sellado { get; set; }
        public string Nota_Sellado { get; set; }
        public Nullable<short> Flag_Corte { get; set; }
        public Nullable<System.DateTime> Fecha_Corte { get; set; }
        public string Nota_Corte { get; set; }
        public Nullable<short> Flag_Laminado { get; set; }
        public Nullable<System.DateTime> Fecha_Laminado { get; set; }
        public string Nota_Laminado { get; set; }
        public Nullable<short> Flag_Fuellado { get; set; }
        public Nullable<System.DateTime> Fecha_Fuellado { get; set; }
        public string Nota_Fuellado { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public decimal IdOrdProd { get; set; }
        public decimal IdHistorialLiquidacionProd { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
    }
}
