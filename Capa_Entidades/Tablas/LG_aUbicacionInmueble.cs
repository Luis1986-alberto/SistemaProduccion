namespace Capa_Entidades.Tablas
{
    public class LG_aUbicacionInmueble
    {
        public byte IdUbicacionInmueble { get; set; }
        public string Nombre_Distrito { get; set; }

        public LG_aUbicacionInmueble()
        { }

        public LG_aUbicacionInmueble(byte idubicacioninmueble, string nombre_distrito)
        {
            this.IdUbicacionInmueble = idubicacioninmueble;
            this.Nombre_Distrito = nombre_distrito;
        }


    }
}
