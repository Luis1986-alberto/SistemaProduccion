namespace Capa_Entidades.Tablas
{
    public class LG_aUnidad
    {
        public byte IdUnidad { get; set; }
        public string Nombre_Unidad { get; set; }
        public string Sigla_Unidad { get; set; }

        public LG_aUnidad()
        { }

        public LG_aUnidad(byte idunidadmedida, string nombre_unidad, string sigla_unidad)
        {
            this.IdUnidad = idunidadmedida;
            this.Nombre_Unidad = nombre_unidad;
            this.Sigla_Unidad = sigla_unidad;
        }


    }
}
