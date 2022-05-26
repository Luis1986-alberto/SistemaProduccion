namespace Capa_Entidades.Tablas
{
    public class PR_aLocal
    {
        private byte _IdLocal;
        private string _Nombre_Local;
        private string _Abreviatura_Local;
        private string _Nave;

        public byte IdLocal { get => _IdLocal; set => _IdLocal = value; }
        public string Nombre_Local { get => _Nombre_Local; set => _Nombre_Local = value; }
        public string Abreviatura_Local { get => _Abreviatura_Local; set => _Abreviatura_Local = value; }
        public string Nave { get => _Nave; set => _Nave = value; }

        public PR_aLocal()
        { }

        public PR_aLocal(byte idLocal, string nombre_Local, string abreviatura_Local, string nave)
        {
            _IdLocal = idLocal;
            _Nombre_Local = nombre_Local;
            _Abreviatura_Local = abreviatura_Local;
            _Nave = nave;
        }
    }
}
