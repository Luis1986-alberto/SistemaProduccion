using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mAlmacenBobinasImpresas
    {
        public decimal IdAlmacenBobinasImpresas { get; set; }
        public string Flag_IngresoBobinaImp { get; set; }
        public string Flag_SalidaBobinaImp { get; set; }
        public string Flag_ReingresoBobinaImp { get; set; }
        public string Flag_ResalidaBobinaImp { get; set; }
        public string Flag_IndustrialComercial { get; set; }
        public string Flag_Extruida_Impresa { get; set; }
        public Nullable<decimal> Numero_Bobina { get; set; }
        public string Flag_Bobina_Observada { get; set; }
        public string Nota_Bobina_Observada { get; set; }
        public string Flag_Forro_Blanco { get; set; }
        public string Flag_Forro_Amarillo { get; set; }
        public string Flag_Forro_Verde { get; set; }
        public string Flag_Forro_Azul { get; set; }
        public string Flag_Forro_Naranja { get; set; }
        public string Flag_Forro_Rojo { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public Nullable<decimal> Peso_Bruto { get; set; }
        public Nullable<decimal> Peso_Neto { get; set; }
        public string Flag_Reproceso { get; set; }
        public string Nota_Reproceso { get; set; }
        public string Flag_Salida_BobObservada { get; set; }
        public string Nota_Salida { get; set; }
        public string Nota_Ingreso { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }

    }
}
