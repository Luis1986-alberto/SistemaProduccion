namespace Capa_Entidades.Tablas
{
    public class PR_aTipoProcesoLaminado
    {
        private byte _IdTipoProcesoLaminado;
        private string _Nombre_TipoProcesoLaminado;

        public byte IdTipoProcesoLaminado { get => _IdTipoProcesoLaminado; set => _IdTipoProcesoLaminado = value; }
        public string Nombre_TipoProcesoLaminado { get => _Nombre_TipoProcesoLaminado; set => _Nombre_TipoProcesoLaminado = value; }

        public PR_aTipoProcesoLaminado()
        { }

        public PR_aTipoProcesoLaminado(byte idTipoProcesoLaminado, string nombre_TipoProcesoLaminado)
        {
            _IdTipoProcesoLaminado = idTipoProcesoLaminado;
            _Nombre_TipoProcesoLaminado = nombre_TipoProcesoLaminado;
        }

    }
}
