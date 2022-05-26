namespace Capa_Entidades.Tablas
{
    public class PR_aLinea_Produccion
    {
        private byte _IdLineaProd;
        private string _Descripcion_Linea;

        public byte IdLineaProd { get => _IdLineaProd; set => _IdLineaProd = value; }
        public string Descripcion_Linea { get => _Descripcion_Linea; set => _Descripcion_Linea = value; }

        public PR_aLinea_Produccion()
        { }

        public PR_aLinea_Produccion(byte idLineaProd, string descripcion_Linea)
        {
            _IdLineaProd = idLineaProd;
            _Descripcion_Linea = descripcion_Linea;
        }

    }
}
