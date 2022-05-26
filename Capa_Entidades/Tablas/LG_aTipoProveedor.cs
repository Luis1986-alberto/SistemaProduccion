using System;

namespace Capa_Entidades.Tablas
{
    public class LG_aTipoProveedor
    {
        public Byte IdTipoProveedor { get; set; }
        public string Tipo_Proveedor { get; set; }

        public LG_aTipoProveedor()
        { }

        public LG_aTipoProveedor(byte idtipoproveedor, string tipo_proveedor)
        {
            this.IdTipoProveedor = idtipoproveedor;
            this.Tipo_Proveedor = tipo_proveedor;
        }



    }
}
