namespace Capa_Entidades.Tablas
{
    public class PR_aCarreta
    {
        private byte _IdCarreta;
        private decimal _Pesos_Kilos;

        public byte IdCarreta { get => _IdCarreta; set => _IdCarreta = value; }
        public decimal Pesos_Kilos { get => _Pesos_Kilos; set => _Pesos_Kilos = value; }

        public PR_aCarreta()
        { }

        public PR_aCarreta(byte idCarreta, decimal pesos_Kilos)
        {
            IdCarreta = idCarreta;
            Pesos_Kilos = pesos_Kilos;
        }
    }
}
