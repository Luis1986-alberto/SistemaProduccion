namespace Capa_Entidades.Tablas
{
    public class LG_aEstadoInmueble
    {
        public byte IdEstadoInmueble { get; set; }
        public string Estado_Inmueble { get; set; }

        public LG_aEstadoInmueble()
        { }

        public LG_aEstadoInmueble(byte idestadoinmueble, string estado_inmueble)
        {
            this.IdEstadoInmueble = idestadoinmueble;
            this.Estado_Inmueble = estado_inmueble;
        }
    }
}
