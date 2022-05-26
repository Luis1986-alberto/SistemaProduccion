namespace Capa_Entidades.Tablas
{
    public class PR_aEmpaquetado
    {
        public byte IdEmpaquetado { get; set; }
        public string Descripcion { get; set; }

        public PR_aEmpaquetado()
        { }

        public PR_aEmpaquetado(byte idEmpaquetado, string descripcion)
        {
            IdEmpaquetado = idEmpaquetado;
            Descripcion = descripcion;
        }

    }
}
