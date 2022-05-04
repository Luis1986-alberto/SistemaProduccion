using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleInsumo
    {
        public byte IdDetalleInsumo { get; set; }
        public Nullable<short> IdMaterial { get; set; }
        public Nullable<decimal> Formula { get; set; }
        public Nullable<decimal> Sacos_TolvaLlena { get; set; }
        public Nullable<byte> Baldes_TolvaLlena { get; set; }
        public Nullable<decimal> Balanza_TolvaLlena { get; set; }
        public Nullable<decimal> Kilos_TolvaLlena { get; set; }
        public Nullable<decimal> Porcentaje_TolvaLlena { get; set; }
        public Nullable<decimal> Sacos_Saldo { get; set; }
        public Nullable<byte> Baldes_Saldo { get; set; }
        public Nullable<decimal> Balanza_Saldo { get; set; }
        public Nullable<decimal> Kilos_Saldo { get; set; }
        public Nullable<decimal> Porcentaje_Saldo { get; set; }
        public Nullable<decimal> Total_Kg { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Lote_Material { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> IdColor { get; set; }

        public virtual PR_aColor PR_aColor { get; set; }
        public virtual PR_mMateriales PR_mMateriales { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        
    }
}