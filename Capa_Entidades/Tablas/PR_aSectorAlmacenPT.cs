namespace Capa_Entidades.Tablas
{
    public class PR_aSectorAlmacenPT
    {
        private byte _IdSectorAlmacenPT;
        private string _Codigo_Sector;

        public byte IdSectorAlmacenPT { get => _IdSectorAlmacenPT; set => _IdSectorAlmacenPT = value; }
        public string Codigo_Sector { get => _Codigo_Sector; set => _Codigo_Sector = value; }

        public PR_aSectorAlmacenPT()
        { }

        public PR_aSectorAlmacenPT(byte idSectorAlmacenPT, string codigo_Sector)
        {
            _IdSectorAlmacenPT = idSectorAlmacenPT;
            _Codigo_Sector = codigo_Sector;
        }
    }
}
