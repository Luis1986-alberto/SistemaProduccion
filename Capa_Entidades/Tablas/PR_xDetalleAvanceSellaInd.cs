using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xDetalleAvanceSellaInd
    {
        public PR_xDetalleAvanceSellaInd()
        {
            this.PR_xDetalleMermaSellaInd = new HashSet<PR_xDetalleMermaSellaInd>();
        }

        public decimal Numero_Fardo_Caja_Paquete { get; set; }
        public Nullable<System.DateTime> Fecha_Fardo_Caja_Paquete { get; set; }
        public Nullable<System.DateTime> Hora_Inicio { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Numero_Bobina1_Extru_Impre { get; set; }
        public Nullable<decimal> Numero_Bobina2_Extru_Impre { get; set; }
        public Nullable<short> Flag_Saldo { get; set; }
        public Nullable<short> Paquetes { get; set; }
        public Nullable<decimal> Millares { get; set; }
        public Nullable<decimal> Peso_Bruto_Fardo_Caja_Pqte { get; set; }
        public Nullable<decimal> Peso_Neto_Fardo_Caja_Pqte { get; set; }
        public Nullable<decimal> Peso_Tinta { get; set; }
        public Nullable<decimal> Peso_Material { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public Nullable<decimal> Numero_Bobina3_Extru_Impre { get; set; }
        public Nullable<decimal> Numero_Bobina4_Extru_Impre { get; set; }
        public Nullable<decimal> Numero_Bobina5_Extru_Impre { get; set; }
        public Nullable<decimal> Peso_Scrap { get; set; }
        public Nullable<decimal> Peso_Troquel { get; set; }
        public Nullable<decimal> Peso_Refile { get; set; }
        public Nullable<decimal> Peso_Perforaciones { get; set; }
        public Nullable<decimal> Peso_Fuellado { get; set; }
        public Nullable<short> Flag_PesarxPaquete { get; set; }
        public Nullable<short> Flag_PesarxFardo { get; set; }
        public Nullable<short> Flag_PesarxCaja { get; set; }
        public Nullable<System.DateTime> Hora_Termino { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<decimal> Peso_Carreta { get; set; }
        public Nullable<short> Flag_Turno { get; set; }
        public string Codigo_Barra { get; set; }
        public Nullable<short> Flag_PesarxRollo { get; set; }
        public string Observacion { get; set; }
        public Nullable<short> Flag_LiquidacionScrap { get; set; }
        public Nullable<short> Flag_LiquidacionProduccion { get; set; }
        public Nullable<System.DateTime> Fecha_Fardo_Caja_Paquete_L { get; set; }
        public Nullable<decimal> Peso_Neto_Fardo_Caja_Pqte_L { get; set; }
        public Nullable<decimal> Millares_L { get; set; }
        public Nullable<decimal> Cantidad_L { get; set; }
        public decimal IdOrdProd { get; set; }
        public Nullable<decimal> Numero_Bobina6_Extru_Impre { get; set; }
        public Nullable<decimal> Numero_Bobina7_Extru_Impre { get; set; }
        public Nullable<decimal> Numero_Bobina8_Extru_Impre { get; set; }
        public string IdOrdenProduccionInd { get; set; }
        public Nullable<short> Flag_Envio { get; set; }
        public Nullable<byte> Numero_Envio { get; set; }
        public Nullable<short> IdTrabajador { get; set; }

        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xAvanceSelladoInd PR_xAvanceSelladoInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_xDetalleMermaSellaInd> PR_xDetalleMermaSellaInd { get; set; }
    }
}
