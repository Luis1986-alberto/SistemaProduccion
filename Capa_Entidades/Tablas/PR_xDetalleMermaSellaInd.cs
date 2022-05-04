using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleMermaSellaInd
    {
        public decimal Numero_Fardo_Caja_Paquete { get; set; }
        public decimal IdOrdProd { get; set; }
        public byte IdDetalleMermaAvSellaInd { get; set; }
        public Nullable<System.DateTime> Fecha_Merma { get; set; }
        public Nullable<short> Flag_TurnoDia { get; set; }
        public Nullable<short> IdMaquina { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<short> IdMotivoScrap { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Total_Motivo_Scrap { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mMaquina PR_mMaquina { get; set; }
        public virtual PR_mMotivoScrap PR_mMotivoScrap { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xDetalleAvanceSellaInd PR_xDetalleAvanceSellaInd { get; set; }

    }
}
