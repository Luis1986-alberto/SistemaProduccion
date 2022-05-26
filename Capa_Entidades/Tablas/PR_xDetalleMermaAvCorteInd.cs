using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleMermaAvCorteInd
    {
        public byte IdTipoProcesoCorte { get; set; }
        public decimal Numero_Bobina_Corte { get; set; }
        public decimal IdOrdProd { get; set; }
        public byte IdDetalleMermaAvCorteInd { get; set; }
        public Nullable<short> IdMotivoScrap { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Merma { get; set; }
        public Nullable<short> Flag_TurnoDia { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Total_Motivo_Scrap { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mMotivoScrap PR_mMotivoScrap { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xDetalleAvanceCorte PR_xDetalleAvanceCorte { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
