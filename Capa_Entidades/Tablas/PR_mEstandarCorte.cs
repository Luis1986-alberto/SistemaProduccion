using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandarCorte
    {
        public short IdEstandarCorte { get; set; }
        public Int32 IdEstandar { get; set; }
        public Nullable<decimal> Ancho_Corte { get; set; }
        public Nullable<byte> IdUnidadAncho_Corte { get; set; }
        public Nullable<decimal> Frecuencia { get; set; }
        public Nullable<byte> IdUnidadFrecuencia { get; set; }
        public string FotoCelula_Izq { get; set; }
        public string FotoCelula_Der { get; set; }
        public string FotoCelula_Cen { get; set; }
        public Nullable<decimal> Dist_FotoCorte { get; set; }
        public Nullable<byte> IdUnidad_FotoCorte { get; set; }
        public Nullable<decimal> Diametro_BobLamina { get; set; }
        public Nullable<byte> IdUnidad_BobLamina { get; set; }
        public Nullable<decimal> Peso_Bobina { get; set; }
        public Nullable<decimal> Diametro_Tuco { get; set; }
        public Nullable<byte> IdUnidad_Tuco { get; set; }
        public Nullable<decimal> Peso_Tuco { get; set; }
        public string Tipo_Empalme { get; set; }
        public Nullable<decimal> Numero_Empalmes { get; set; }
        public string Flag_Embobinado1 { get; set; }
        public string Flag_Embobinado2 { get; set; }
        public string Flag_Embobinado3 { get; set; }
        public string Flag_Embobinado4 { get; set; }
        public string Flag_Embobinado5 { get; set; }
        public string Flag_Embobinado6 { get; set; }
        public string Flag_Embobinado7 { get; set; }
        public string Flag_Embobinado8 { get; set; }
        public string Nota_Corte { get; set; }
        public Nullable<System.DateTime> Fecha_servidor { get; set; }
        public string Ruta_Foto { get; set; }
        public byte[] Foto_Bolsa { get; set; }
        public Nullable<decimal> NumeroPistasBandas { get; set; }


        public PR_mEstandarCorte()
        { }


    }
}
