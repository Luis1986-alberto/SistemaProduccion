using System;

namespace Capa_Entidades.Tablas
{
    public class PR_mClientes
    {
        public Int32 IdCliente { get; set; }
        public string Razon_Social { get; set; }
        public string RUC_Empresa { get; set; }
        public string Direccion { get; set; }
        public string Direccion_Fiscal { get; set; }
        public byte Flag_Natural { get; set; }
        public string Pagina_Web { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Referencias { get; set; }
        public string Observacion { get; set; }
        public string Numero_Telefono1 { get; set; }
        public string Numero_Telefono2 { get; set; }
        public string Numero_Celular1 { get; set; }
        public string Numero_Celular2 { get; set; }
        public byte IdTipoRubro { get; set; }
        public virtual string Nombre_TipoRubro { get; set; }

        public PR_mClientes()
        { }
    }
}
