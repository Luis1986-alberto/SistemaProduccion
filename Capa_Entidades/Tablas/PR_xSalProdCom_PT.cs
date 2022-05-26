using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xSalProdCom_PT
    {
        public decimal IdSalProdComercial { get; set; }
        public Nullable<byte> IdTipoSalida_PT { get; set; }
        public Nullable<decimal> IdCatalogo_Produccion { get; set; }
        public Nullable<decimal> Total_Cantidad_PFCR_Sal { get; set; }
        public Nullable<decimal> Total_Millares_Sal { get; set; }
        public Nullable<decimal> Total_Kilos_Sal { get; set; }
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
        public string IdUsuario_PC { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Nota_Salida_PT { get; set; }
        public string IdUsuario { get; set; }

        public virtual LG_aTipoSalida PR_aTipoSalida_PT { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }

    }
}
