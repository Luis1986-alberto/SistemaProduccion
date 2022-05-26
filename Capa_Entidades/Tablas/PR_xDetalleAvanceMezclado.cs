using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceMezclado
    {
        public decimal Item { get; set; }
        public Nullable<System.DateTime> Fecha_Mezcla { get; set; }
        public Nullable<System.DateTime> Hora_Mezcla { get; set; }
        public Nullable<byte> IdPosicion_MQ_MEZ { get; set; }
        public Nullable<byte> IdPosicion_MQ_EXT { get; set; }
        public Nullable<decimal> Numero_Cubo { get; set; }
        public Nullable<decimal> Kilos_AproxCubo { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public string IdUsuario { get; set; }
        public decimal IdOrdProd { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceMezclado PR_xAvanceMezclado { get; set; }
    }
}
