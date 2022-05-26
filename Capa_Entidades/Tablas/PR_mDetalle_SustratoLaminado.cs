using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mDetalle_SustratoLaminado
    {
        public short IdEstandarLaminado { get; set; }
        public int Item { get; set; }
        public Nullable<decimal> IdSustrato { get; set; }
        public Nullable<decimal> Medida_Sustrato { get; set; }
        public Nullable<byte> IdUnidad_MedidaSustrato { get; set; }
        public Nullable<decimal> Espesor_Sustrato { get; set; }
        public Nullable<byte> IdUnidad_EspesorSustrato { get; set; }
        public Nullable<decimal> Gramaje { get; set; }

        public virtual PR_mEstandarLaminado PR_mEstandarLaminado { get; set; }

    }
}
