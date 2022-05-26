namespace Capa_Entidades.Tablas
{
    public class LG_aAlmacen
    {
        public byte IdAlmacen { get; set; }
        public string Nombre_Almacen { get; set; }
        public string Sigla_Almacen { get; set; }
        public byte IdEmpresa { get; set; }
        public virtual string Nombre_Empresa { get; set; }

        public LG_aAlmacen()
        { }

        public LG_aAlmacen(byte idalmacen, string nombre_almacen, string sigls_almacen, byte idempresa)
        {
            IdAlmacen = idalmacen;
            Nombre_Almacen = nombre_almacen;
            Sigla_Almacen = sigls_almacen;
            IdEmpresa = idempresa;
        }

    }
}
