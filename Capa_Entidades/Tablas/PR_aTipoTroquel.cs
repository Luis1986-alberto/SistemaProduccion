namespace Capa_Entidades.Tablas
{
    public class PR_aTipoTroquel
    {
        private byte _IdTipoTroquel;
        private string _Descripcion_TipoTroquel;

        public byte IdTipoTroquel { get => _IdTipoTroquel; set => _IdTipoTroquel = value; }
        public string Descripcion_TipoTroquel { get => _Descripcion_TipoTroquel; set => _Descripcion_TipoTroquel = value; }

        public PR_aTipoTroquel()
        { }

        public PR_aTipoTroquel(byte idTipoTroquel, string descripcion_TipoTroquel)
        {
            _IdTipoTroquel = idTipoTroquel;
            _Descripcion_TipoTroquel = descripcion_TipoTroquel;
        }
    }
}
