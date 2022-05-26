using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xAvanceDespacho
    {
        public Nullable<System.DateTime> FechaDespacho_Entrega1 { get; set; }
        public Nullable<decimal> TotalKilos_Entrega1 { get; set; }
        public Nullable<decimal> TotalMillares_Entrega1 { get; set; }
        public Nullable<System.DateTime> FechaDespacho_Entrega2 { get; set; }
        public Nullable<decimal> TotalKilos_Entrega2 { get; set; }
        public Nullable<decimal> TotalMillares_Entrega2 { get; set; }
        public Nullable<System.DateTime> FechaDespacho_Entrega3 { get; set; }
        public Nullable<decimal> TotalKilos_Entrega3 { get; set; }
        public Nullable<decimal> TotalMillares_Entrega3 { get; set; }
        public Nullable<System.DateTime> FechaDespacho_Entrega4 { get; set; }
        public Nullable<decimal> TotalKilos_Entrega4 { get; set; }
        public Nullable<decimal> TotalMillares_Entrega4 { get; set; }
        public string IdUsuario_Entrega { get; set; }
        public string IdUsuario_Entrega_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Entrega { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
    }
}
