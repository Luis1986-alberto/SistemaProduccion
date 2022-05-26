namespace Capa_Entidades.Tablas
{
    public class LG_aAño
    {
        private byte _IdAño;
        private int _Año;


        public byte IdAño { get => _IdAño; set => _IdAño = value; }
        public int Año { get => _Año; set => _Año = value; }

        public LG_aAño()
        { }

        public LG_aAño(byte idAño, int año)
        {
            _IdAño = idAño;
            _Año = año;
        }
    }
}
