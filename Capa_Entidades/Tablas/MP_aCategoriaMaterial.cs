namespace Capa_Entidades.Tablas
{
    public class MP_aCategoriaMaterial
    {
        public byte IdCategoriaMaterial { get; set; }
        public string Nombre_Categoria_Material { get; set; }

        public MP_aCategoriaMaterial()
        { }

        public MP_aCategoriaMaterial(byte idcategoriamaterial, string nombre_categoria_material)
        {
            IdCategoriaMaterial = idcategoriamaterial;
            Nombre_Categoria_Material = nombre_categoria_material;
        }

    }
}
