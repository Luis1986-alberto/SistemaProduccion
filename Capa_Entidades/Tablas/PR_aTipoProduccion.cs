namespace Capa_Entidades.Tablas
{
    public class PR_aTipoProduccion
    {
        private byte _IdTipoProduccion;
        private string _Detalle_TipoProduccion;
        private string _Siglas_TipoProduccion;

        public byte IdTipoProduccion { get => _IdTipoProduccion; set => _IdTipoProduccion = value; }
        public string Detalle_TipoProduccion { get => _Detalle_TipoProduccion; set => _Detalle_TipoProduccion = value; }
        public string Siglas_TipoProduccion { get => _Siglas_TipoProduccion; set => _Siglas_TipoProduccion = value; }

        public PR_aTipoProduccion()
        { }

        public PR_aTipoProduccion(byte idTipoProduccion, string detalle_TipoProduccion, string siglas_TipoProduccion)
        {
            _IdTipoProduccion = idTipoProduccion;
            _Detalle_TipoProduccion = detalle_TipoProduccion;
            _Siglas_TipoProduccion = siglas_TipoProduccion;
        }

    }
}
