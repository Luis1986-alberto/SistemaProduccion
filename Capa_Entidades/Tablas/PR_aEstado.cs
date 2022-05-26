namespace Capa_Entidades.Tablas
{
    public class PR_aEstado
    {
        private byte _IdEstado;
        private string _Nombre_Estado;

        public byte IdEstado { get => _IdEstado; set => _IdEstado = value; }
        public string Nombre_Estado { get => _Nombre_Estado; set => _Nombre_Estado = value; }

        public PR_aEstado()
        { }

        public PR_aEstado(byte idEstado, string nombre_Estado)
        {
            _IdEstado = idEstado;
            _Nombre_Estado = nombre_Estado;
        }

    }
}
