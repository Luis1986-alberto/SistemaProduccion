namespace Capa_Entidades.Tablas
{
    public class PR_aTipoMaquina
    {
        private byte _IdTipoMaquina;
        private string _Nombre_TipoMaquina;
        private string _Abreviatura_TipoMaquina;

        public byte IdTipoMaquina { get => _IdTipoMaquina; set => _IdTipoMaquina = value; }
        public string Nombre_TipoMaquina { get => _Nombre_TipoMaquina; set => _Nombre_TipoMaquina = value; }
        public string Abreviatura_TipoMaquina { get => _Abreviatura_TipoMaquina; set => _Abreviatura_TipoMaquina = value; }

        public PR_aTipoMaquina()
        { }

        public PR_aTipoMaquina(byte idTipoMaquina, string nombre_TipoMaquina, string abreviatura_TipoMaquina)
        {
            _IdTipoMaquina = idTipoMaquina;
            _Nombre_TipoMaquina = nombre_TipoMaquina;
            _Abreviatura_TipoMaquina = abreviatura_TipoMaquina;
        }

    }
}
