namespace Capa_Entidades.Tablas
{
    public class LG_aTipoIngreso
    {
        private byte _IdTipoIngreso;
        private string _Nombre_TipoIngreso;

        public byte IdTipoIngreso { get => _IdTipoIngreso; set => _IdTipoIngreso = value; }
        public string Nombre_TipoIngreso { get => _Nombre_TipoIngreso; set => _Nombre_TipoIngreso = value; }

        public LG_aTipoIngreso()
        { }

        public LG_aTipoIngreso(byte idTipoIngreso, string nombre_TipoIngreso)
        {
            _IdTipoIngreso = idTipoIngreso;
            _Nombre_TipoIngreso = nombre_TipoIngreso;
        }

    }
}
