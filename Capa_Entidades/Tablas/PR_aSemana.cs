namespace Capa_Entidades.Tablas
{
    public class PR_aSemana
    {
        private byte _IdSemana;
        private string _Nombre_Semana;

        public byte IdSemana { get => _IdSemana; set => _IdSemana = value; }
        public string Nombre_Semana { get => _Nombre_Semana; set => _Nombre_Semana = value; }

        public PR_aSemana()
        { }

        public PR_aSemana(byte idSemana, string nombre_Semana)
        {
            _IdSemana = idSemana;
            _Nombre_Semana = nombre_Semana;
        }
    }
}
