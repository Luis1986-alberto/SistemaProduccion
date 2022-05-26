namespace Capa_Entidades.Tablas
{
    public class PR_aFormaSustrato
    {
        public byte IdFormaSustrato { get; set; }
        public string Descripcion_Forma { get; set; }



        public PR_aFormaSustrato()
        { }

        public PR_aFormaSustrato(byte idFormaSustrato, string descripcion_Forma)
        {
            IdFormaSustrato = idFormaSustrato;
            Descripcion_Forma = descripcion_Forma;
        }

    }
}
