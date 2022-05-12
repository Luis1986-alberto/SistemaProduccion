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
        public byte IdEtiqueta { get; set; }
        public byte IdEmpaquetado { get; set; }
        public byte IdAsa { get; set; }
        public byte IdTroquel { get; set; }
        public byte IdTipoSello { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public string Flag_Posicion_Sello { get; set; }        
        public short UnidadxPaquete { get; set; }
        public byte PaquetexCaja { get; set; }
        public byte IdUnidadLargo { get; set; }
        public decimal MillarxCaja { get; set; }
        public string Flag_Etiqueta { get; set; }
        public string Flag_Solapa { get; set; }
        public string Flag_Etiqueta_Paquete { get; set; }
        public string Flag_Etiqueta_Caja { get; set; }
        public decimal Peso_Promedio_Fardo { get; set; }
        public decimal Medida_Solapa { get; set; }
        public byte IdUnidadSolapa { get; set; }  
        public string Flag_Refile { get; set; }
        public decimal Medida_Refile { get; set; }
        public byte IdUnidadRefile { get; set; }
        public string Flag_DetalleEtiqueta { get; set; }
        public string Flag_Pestaña { get; set; }
        public decimal Medida_Pestaña { get; set; }
        public byte IdUnidadPestaña { get; set; }
        public byte IdTipoFuelle { get; set; }
        public decimal Medida_Fuelle { get; set; }
        public byte IdUnidadFuelle { get; set; }        
        public string Flag_Perforaciones { get; set; }             
        public byte Numero_Pistas { get; set; }
        public byte Numero_Perforaciones { get; set; }
        public decimal Medida_Perforaciones { get; set; }
        public byte IdUnidadPerforaciones { get; set; }
        public string Flag_Etiqueta_Fardo { get; set; }
        public string Nota_Sellado { get; set; }            
        public decimal Peso_Promedio_Millar { get; set; }
        public decimal Peso_Promedio_Paquete { get; set; }
        public decimal Peso_Tuco { get; set; }
        public decimal Peso_Envase { get; set; }
        public string Ruta_FotoPlanoMecanicoSell { get; set; }
        public byte[] Foto_PlanoMecanicoSell { get; set; }


        public PR_mEstandarSellado()
        { }

        public PR_mEstandarSellado(Int32 _idestandar)
        {this.IdEstandar = _idestandar;}



        public virtual PR_aAsa oPR_aAsa { get; set; }
        public virtual PR_aEmpaquetado oPR_aEmpaquetado { get; set; }
        public virtual PR_aEtiqueta oPR_aEtiqueta { get; set; }
        public virtual PR_aTipoSello oPR_aTipoSello { get; set; }
        public virtual PR_aTipoTroquel oPR_aTipoTroquel { get; set; }
        public virtual ICollection<PR_mEstandar> oPR_mEstandar { get; set; }


    }
}
