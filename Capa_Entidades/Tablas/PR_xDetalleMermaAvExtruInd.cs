using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleMermaAvExtruInd
    {
        public byte IdDetalleMermaAvExtruInd { get; set; }
        public Nullable<System.DateTime> Fecha_Merma { get; set; }
        public Nullable<short> Flag_TurnoDia { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Peso_Scrap { get; set; }
        public Nullable<decimal> Peso_Chancaca { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public decimal Numero_Bobina { get; set; }
        public decimal IdOrdProd { get; set; }
        public Nullable<decimal> Total_Motivo_Scrap { get; set; }
        public Nullable<short> IdMotivoScrap { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mMotivoScrap PR_mMotivoScrap { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xDetalleAvanceExtruInd PR_xDetalleAvanceExtruInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
