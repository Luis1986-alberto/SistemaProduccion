namespace Capa_Entidades.Tablas
{
    public class LG_aCondicionCobranza
    {
        public byte IdCondicionCobranza { get; set; }
        public string Condicion_Cobranza { get; set; }

        public LG_aCondicionCobranza()
        { }

        public LG_aCondicionCobranza(byte idcondicioncobranza)
        {
            this.IdCondicionCobranza = idcondicioncobranza;
        }


    }
}
