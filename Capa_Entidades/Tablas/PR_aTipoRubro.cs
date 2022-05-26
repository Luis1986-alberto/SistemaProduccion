namespace Capa_Entidades.Tablas
{
    public class PR_aTipoRubro
    {
        public byte IdTipoRubro { get; set; }
        public string Nombre_TipoRubro { get; set; }

        public PR_aTipoRubro()
        { }

        public PR_aTipoRubro(byte idtiporubro, string nombre_tiporubro)
        {
            IdTipoRubro = idtiporubro;
            Nombre_TipoRubro = nombre_tiporubro;
        }

    }

}
