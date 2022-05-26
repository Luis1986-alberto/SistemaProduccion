namespace Capa_Entidades.Tablas
{
    public class MP_aTipoCompraMaterial
    {
        public byte IdTipoCompraMaterial { get; set; }
        public string Descripcion_TipoCompra { get; set; }

        public MP_aTipoCompraMaterial()
        { }

        public MP_aTipoCompraMaterial(byte idtipocompramaterial, string descripcion_tipocompra)
        {
            IdTipoCompraMaterial = idtipocompramaterial;
            Descripcion_TipoCompra = descripcion_tipocompra;
        }

    }
}
