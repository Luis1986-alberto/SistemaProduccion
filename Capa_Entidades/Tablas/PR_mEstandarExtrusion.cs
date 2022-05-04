using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandarExtrusion
    {
        public short IdEstandarExtrusion { get; set; }
        public Int32 IdEstandar { get; set; }
        public Nullable<byte> IdTipoMaterialMezclar { get; set; }
        public Nullable<byte> IdUsoProducto { get; set; }
        public string Flag_Lamina { get; set; }
        public string Flag_MangaCerrada { get; set; }
        public string Flag_MangaAbierta { get; set; }
        public string Color { get; set; }
        public string Flag_AditivoUV { get; set; }
        public string Flag_Apilar { get; set; }
        public string Flag_Biodegradable { get; set; }
        public string Flag_Congelado { get; set; }
        public string Flag_Impresion { get; set; }
        public string Flag_Refile { get; set; }
        public string Flag_MasLineal { get; set; }
        public Nullable<decimal> Medida_Refile { get; set; }
        public string Flag_MediaDensidad { get; set; }
        public Nullable<byte> IdUnidadRefile { get; set; }
        public string Flag_Termocontraible { get; set; }
        public string Flag_Gofrado { get; set; }
        public string Flag_UsoPesado { get; set; }
        public string Flag_Otros { get; set; }
        public string Flag_Fuelle { get; set; }
        public Nullable<decimal> Medida_Fuelle { get; set; }
        public string Nota_Otros { get; set; }
        public Nullable<decimal> Medida_Manga { get; set; }
       
        public Nullable<byte> IdUnidadFuelle { get; set; }
        public string Nota_Tratado { get; set; }
        public Nullable<byte> IdUnidadManga { get; set; }
        public Nullable<decimal> Medida_Espesor { get; set; }
        public string Flag_FuelleIncluido { get; set; }
        public Nullable<byte> IdUnidadEspesor { get; set; }
        public string Nota_Extrusion { get; set; }
        public string Flag_TratadoFraccionado { get; set; }
        public Nullable<decimal> Gramaje_Total { get; set; }
        public Nullable<decimal> Gramaje_Lineal { get; set; }
        public Nullable<decimal> Relacion_Soplado { get; set; }
        public string Ruta_FotoPlanoMecanicoExtr { get; set; }
        public byte[] Foto_PlanoMecanicoExtr { get; set; }
        public string Flag_Embobinado1 { get; set; }
        public string Flag_Embobinado2 { get; set; }
        public string Flag_Embobinado3 { get; set; }
        public string Flag_Embobinado4 { get; set; }
        public string Flag_Embobinado5 { get; set; }
        public string Flag_Embobinado6 { get; set; }
        public string Flag_Embobinado7 { get; set; }
        public string Flag_Embobinado8 { get; set; }
        public string Problemas_Extrusion { get; set; }
        public Nullable<decimal> Tiempo_Estimado_Produccion { get; set; }
        public Nullable<decimal> Diametro_Cabezal { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public Nullable<decimal> Diametro_Tuco_Extrusion { get; set; }
        public byte IdUnidadMedidaDiametroTuco { get; set; }
        public Nullable<decimal> Medida_Tuco_Extrusion { get; set; }
        public byte IdUnidadMedidaTuco { get; set; }
        public Nullable<decimal> Peso_Tuco_Extrusion { get; set; }
        public Nullable<decimal> Gap_Extrusion { get; set; }
        public Nullable<decimal> Dynas_Extrusion { get; set; }

        public byte  IdUnidadMedidaPesoTuco {get;set;}
        public byte IdTipoTratado { get; set; }
        public byte IdTipoMaterialExtruir { get; set; }
        public byte IdFormaSustrato { get; set; }
        public byte IdTipoFuelle { get; set; }

    }
}
