namespace Capa_Entidades.Tablas
{
    public class MP_aTipoMaterial
    {
        public byte IdTipoMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public byte Orden_Gerencia { get; set; }
        public string Codigo_Sustrato { get; set; }

        public MP_aTipoMaterial()
        { }

        public MP_aTipoMaterial(byte idtipomaterial, string descripcion, string abreviatura, byte orden_gerencia, string codigo_sustrato)
        {
            IdTipoMaterial = idtipomaterial;
            Descripcion = descripcion;
            Abreviatura = abreviatura;
            Orden_Gerencia = orden_gerencia;
            Codigo_Sustrato = codigo_sustrato;
        }

    }
}
