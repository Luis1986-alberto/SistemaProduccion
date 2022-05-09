using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandarSellado
    {
        public Int32 IdEstandarSellado { get; set; }
        public Int32 IdEstandar { get; set; }
        public Nullable<byte> IdEtiqueta { get; set; }
        public Nullable<byte> IdEmpaquetado { get; set; }
        public Nullable<byte> IdAsa { get; set; }
        public Nullable<byte> IdTroquel { get; set; }
        public Nullable<byte> IdTipoSello { get; set; }
        public Nullable<decimal> Ancho { get; set; }
        public Nullable<decimal> Largo { get; set; }
        public string Flag_Posicion_Sello { get; set; }        
        public Nullable<short> UnidadxPaquete { get; set; }
        public Nullable<decimal> PaquetexCaja { get; set; }
        public Nullable<byte> IdUnidadLargo { get; set; }
        public Nullable<decimal> MillarxCaja { get; set; }
        public string Flag_Etiqueta { get; set; }
        public string Flag_Solapa { get; set; }
        public string Flag_Etiqueta_Paquete { get; set; }
        public Nullable<decimal> Medida_Solapa { get; set; }
        public Nullable<byte> IdUnidadSolapa { get; set; }
        public string Flag_Etiqueta_Caja { get; set; }
        public string Flag_Refile { get; set; }
        public Nullable<decimal> Medida_Refile { get; set; }
        public Nullable<byte> IdUnidadRefile { get; set; }
        public string Flag_DetalleEtiqueta { get; set; }
        public string Flag_Pestaña { get; set; }
        public Nullable<decimal> Medida_Pestaña { get; set; }
        public Nullable<byte> IdUnidadPestaña { get; set; }
        public Int32 IdTipoFuelle { get; set; }
        public decimal Medida_Fuelle { get; set; }
        public byte IdUnidadFuelle { get; set; }        
        public string Flag_Perforaciones { get; set; }             
        public Nullable<byte> Numero_Pistas { get; set; }
        public Nullable<byte> Numero_Perforaciones { get; set; }
        public Nullable<decimal> Medida_Perforaciones { get; set; }
        public Nullable<byte> IdUnidadPerforaciones { get; set; }
        public string Flag_Etiqueta_Fardo { get; set; }
        public string Nota_Sellado { get; set; }    
        public Nullable<decimal> Peso_Promedio_Fardo { get; set; }
        public Nullable<decimal> Peso_Promedio_Millar { get; set; }
        public Nullable<decimal> Peso_Promedio_Paquete { get; set; }
        public Nullable<decimal> Peso_Tuco { get; set; }
        public Nullable<decimal> Peso_Envase { get; set; }
        public string Ruta_FotoPlanoMecanicoSell { get; set; }
        public byte[] Foto_PlanoMecanicoSell { get; set; }


        public PR_mEstandarSellado()
        { }

        public virtual PR_aAsa oPR_aAsa { get; set; }
        public virtual PR_aEmpaquetado oPR_aEmpaquetado { get; set; }
        public virtual PR_aEtiqueta oPR_aEtiqueta { get; set; }
        public virtual PR_aTipoSello oPR_aTipoSello { get; set; }
        public virtual PR_aTipoTroquel oPR_aTipoTroquel { get; set; }
        public virtual ICollection<PR_mEstandar> oPR_mEstandar { get; set; }


    }
}
