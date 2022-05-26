using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetIngProdCom_PT
    {
        public decimal IdIngProdComercial { get; set; }
        public decimal Item { get; set; }
        public Nullable<decimal> IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<decimal> Numero_Fardo_Caja_Paquete { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Total_Cantidad_PFCR_Det { get; set; }
        public Nullable<decimal> Total_Millares_Det { get; set; }
        public Nullable<decimal> Total_Kilos_Det { get; set; }

        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xIngProdCom_PT PR_xIngProdCom_PT { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }

    }
}
