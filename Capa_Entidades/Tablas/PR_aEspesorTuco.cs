namespace Capa_Entidades.Tablas
{
    public class PR_aEspesorTuco
    {
        private byte _IdEspesorTuco;
        private decimal _Medida_EspesorTuco;
        private byte _IdUnidadEspesorTuco;


        public byte IdEspesorTuco { get => _IdEspesorTuco; set => _IdEspesorTuco = value; }
        public decimal Medida_EspesorTuco { get => _Medida_EspesorTuco; set => _Medida_EspesorTuco = value; }
        public byte IdUnidadEspesorTuco { get => _IdUnidadEspesorTuco; set => _IdUnidadEspesorTuco = value; }


        public virtual string Sigla_Unidad { get; set; }

        public PR_aEspesorTuco()
        { }

        public PR_aEspesorTuco(byte idEspesorTuco, decimal medida_EspesorTuco, byte idUnidadEspesorTuco)
        {
            _IdEspesorTuco = idEspesorTuco;
            _Medida_EspesorTuco = medida_EspesorTuco;
            _IdUnidadEspesorTuco = idUnidadEspesorTuco;
        }

    }
}
