namespace Capa_Entidades.Tablas
{
    public class PR_aColor
    {
        public byte IdColor { get; set; }
        public string Nombre_Color { get; set; }
        public string Codigo_Color { get; set; }



        public PR_aColor()
        { }

        public PR_aColor(byte idColor, string nombre_Color, string codigo_Color)
        {
            IdColor = idColor;
            Nombre_Color = nombre_Color;
            Codigo_Color = codigo_Color;
        }

    }
}
