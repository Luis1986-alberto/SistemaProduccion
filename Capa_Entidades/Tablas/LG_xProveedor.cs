using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class LG_xProveedor
    {
        public Int32 IdProveedor { get; set; }
        public string Razon_Social_Proveedor { get; set; }
        public string RUC_Proveedor { get; set; }
        public string Telefono2_Proveedor { get; set; }
        public string Telefono1_Proveedor { get; set; }
        public string Pagina_Web_Proveedor { get; set; }
        public string Direccion_Proveedor { get; set; }
        public string Correo_Proveedor { get; set; }
        public string Contacto_Proveedor { get; set; }
        public string Telefono_Contacto { get; set; }
        public string Correo_Contacto { get; set; }
        public string Nota { get; set; }
        public string Celular1_Proveedor { get; set; }
        public byte IdTipoProveedor { get; set; }

        public virtual LG_aTipoProveedor tipoproveedor { get; set; }
        public virtual string Tipo_Proveedor {get;set;}
       

        public LG_xProveedor()
        {
            List<LG_aTipoProveedor> tipoProveedors = new List<LG_aTipoProveedor>();
        }




    }
}
