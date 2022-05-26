namespace Capa_Entidades.Tablas
{
    public class PR_aTipoEstadoDespacho
    {
        private byte _IdTipoEstadoDespacho;
        private string _TipoEstadoDespacho;

        public byte IdTipoEstadoDespacho { get => _IdTipoEstadoDespacho; set => _IdTipoEstadoDespacho = value; }
        public string TipoEstadoDespacho { get => _TipoEstadoDespacho; set => _TipoEstadoDespacho = value; }

        public PR_aTipoEstadoDespacho()
        { }

        public PR_aTipoEstadoDespacho(byte idTipoEstadoDespacho, string tipoEstadoDespacho)
        {
            _IdTipoEstadoDespacho = idTipoEstadoDespacho;
            _TipoEstadoDespacho = tipoEstadoDespacho;
        }

    }
}
