namespace Capa_Entidades.Tablas
{
    public class PR_aPieImprenta
    {
        private byte _IdPieImprenta;
        private string _Descripcion;

        public byte IdPieImprenta { get => _IdPieImprenta; set => _IdPieImprenta = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        public PR_aPieImprenta()
        { }

        public PR_aPieImprenta(byte idPieImprenta, string descripcion)
        {
            _IdPieImprenta = idPieImprenta;
            _Descripcion = descripcion;
        }

    }
}
