namespace Capa_Entidades.Tablas
{
    public class PR_aTipoMoneda
    {
        private byte _IdTipoMoneda;
        private string _Tipo_Moneda;
        private string _Sigla;

        public byte IdTipoMoneda { get => _IdTipoMoneda; set => _IdTipoMoneda = value; }
        public string Tipo_Moneda { get => _Tipo_Moneda; set => _Tipo_Moneda = value; }
        public string Sigla { get => _Sigla; set => _Sigla = value; }

        public PR_aTipoMoneda()
        { }

        public PR_aTipoMoneda(byte idTipoMoneda, string tipo_Moneda, string sigla)
        {
            _IdTipoMoneda = idTipoMoneda;
            _Tipo_Moneda = tipo_Moneda;
            _Sigla = sigla;
        }
    }
}
