using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xProgramaMezclado
    {
        public decimal IdProgMezclado { get; set; }
        public Nullable<byte> Prioridad { get; set; }
        public Nullable<System.DateTime> Fecha_Programada { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Dias_Procesados { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<byte> IdEstadoOrdenProduccion_Programa { get; set; }

        public virtual PR_aEstadoOrdenProduccion_Programa PR_aEstadoOrdenProduccion_Programa { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
