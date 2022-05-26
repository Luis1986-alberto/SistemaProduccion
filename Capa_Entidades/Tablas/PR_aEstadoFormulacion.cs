namespace Capa_Entidades.Tablas
{
    public class PR_aEstadoFormulacion
    {
        private byte _IdEstadoFormulacion;
        private string _Nombre_EstadoFormulacion;

        public byte IdEstadoFormulacion { get => _IdEstadoFormulacion; set => _IdEstadoFormulacion = value; }
        public string Nombre_EstadoFormulacion { get => _Nombre_EstadoFormulacion; set => _Nombre_EstadoFormulacion = value; }

        public PR_aEstadoFormulacion()
        { }

        public PR_aEstadoFormulacion(byte idEstadoFormulacion, string nombre_EstadoFormulacion)
        {
            _IdEstadoFormulacion = idEstadoFormulacion;
            _Nombre_EstadoFormulacion = nombre_EstadoFormulacion;
        }

    }
}
