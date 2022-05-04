using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandarImpresion
    {
        public Int32 IdEstandarImpresion { get; set; }
        public Int32 IdEstandar { get; set; }
        public string Flag_PieImprenta { get; set; }
        public byte IdPieImprenta { get; set; }
        public byte IdTipoTinta { get; set; }
        public byte Numero_Repeticiones { get; set; }
        public decimal Medida_Repeticiones { get; set; }
        public byte IdUnidadRepeticiones { get; set; }
        public byte Numero_Bandas { get; set; }
        public decimal Medida_Bandas { get; set; }
        public byte IdUnidadBandas { get; set; }
        public byte Numero_Pistas { get; set; }
        public string Flag_CodigoBarra { get; set; }
        public string Flag_Agua { get; set; }       
        public string Flag_Calor { get; set; }
        public decimal Calor_C { get; set; }
        public string Flag_Congelamiento { get; set; }       
        public decimal Congelamiento_C { get; set; }
        public string Flag_Detergente { get; set; }        
        public string Flag_Frote { get; set; }        
        public string Flag_Grasa { get; set; }
        public string Flag_UV { get; set; }
        public string Flag_Otros { get; set; }
        public string Nota_Otros { get; set; }
        public string Flag_DueñoClisseEmpresaCliente { get; set; }        
        public int Numero_Clisse { get; set; }
        public string Flag_ColorMuestraPantone { get; set; }
        public byte Numero_Colores { get; set; }
        public string Nota_NombreColores { get; set; }
        public byte Numero_Colores2 { get; set; }
        public string Nota_NombreColores2 { get; set; }
        public string Flag_DevolucionClisse { get; set; }
        public string Nota_DevolucionClisse { get; set; }
        public string Flag_ImpresionInternaExterna { get; set; }        
        public byte Numero_Negativos { get; set; }
        public string Nota_Negativos { get; set; }
        public string Flag_TiraRetira { get; set; }
        public string Flag_Embobinado1 { get; set; }              
        public string Flag_Embobinado2 { get; set; }
        public string Flag_Embobinado3 { get; set; }
        public string Flag_Embobinado4 { get; set; }
        public string Flag_Embobinado5 { get; set; }
        public string Flag_Embobinado6 { get; set; }
        public string Flag_Embobinado7 { get; set; }
        public string Flag_Embobinado8 { get; set; }
        public string Flag_Taca { get; set; }
        public byte IdPosicionTaca { get; set; }
        public decimal Medida_AnchoTaca { get; set; }
        public decimal Medida_LargoTaca { get; set; }
        public byte IdUnidadTaca { get; set; }        
        public decimal Medida_EspesorClisse { get; set; }
        public byte IdUnidadEspesorClisse { get; set; }       
        public decimal Gramaje_Tinta { get; set; }
        public string Ruta_FotoPlanoMecanicoIMP { get; set; }
        public byte[] Foto_PlanoMecanicoIMP { get; set; }
        public string Respecto_A { get; set; }
        public decimal Gramaje_Impresion { get; set; }
        public string Problemas_Impresion { get; set; }
        public string Nota_AniloxColores { get; set; }
        public decimal Tiempo_Preparacion_Maquina { get; set; }
        public decimal Tiempo_Estimado_Produccion { get; set; }
        public decimal Velocidad_Maquina { get; set; }
        public byte IdImpresora { get; set; }
        public string Nota_Impresion { get; set; }

        public PR_mEstandarImpresion()
        { }

        public PR_mEstandarImpresion(Int32 _idEstandar)
        { this.IdEstandar = _idEstandar; }



    }
}
