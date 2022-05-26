namespace Capa_Entidades.Tablas
{
    public class LG_aConcepto
    {
        public byte IdConcepto { get; set; }
        public string Tipo_Concepto { get; set; }

        public LG_aConcepto()
        { }

        public LG_aConcepto(byte idconcepto)
        {
            this.IdConcepto = idconcepto;
        }

    }
}
