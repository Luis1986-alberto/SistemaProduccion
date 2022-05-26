namespace Capa_Entidades.Tablas
{
    public class PR_aTipoFuelle
    {
        private byte _IdTipoFuelle;
        private string _Descripcion_TipoFuelle;

        public byte IdTipoFuelle { get => _IdTipoFuelle; set => _IdTipoFuelle = value; }
        public string Descripcion_TipoFuelle { get => _Descripcion_TipoFuelle; set => _Descripcion_TipoFuelle = value; }

        public PR_aTipoFuelle()
        { }

        public PR_aTipoFuelle(byte idTipoFuelle, string descripcion_TipoFuelle)
        {
            _IdTipoFuelle = idTipoFuelle;
            _Descripcion_TipoFuelle = descripcion_TipoFuelle;
        }

    }
}
