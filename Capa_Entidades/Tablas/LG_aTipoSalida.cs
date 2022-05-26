namespace Capa_Entidades.Tablas
{
    public class LG_aTipoSalida
    {
        private byte _IdTipoSalida;
        private string _Nombre_TipoSalida;

        public byte IdTipoSalida { get => _IdTipoSalida; set => _IdTipoSalida = value; }
        public string Nombre_TipoSalida { get => _Nombre_TipoSalida; set => _Nombre_TipoSalida = value; }

        public LG_aTipoSalida()
        { }

        public LG_aTipoSalida(byte idTipoSalida, string nombre_TipoSalida)
        {
            _IdTipoSalida = idTipoSalida;
            _Nombre_TipoSalida = nombre_TipoSalida;
        }

    }
}
