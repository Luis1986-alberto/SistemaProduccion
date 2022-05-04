using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mEstandar
    {       
        public Int32 IdEstandar { get; set; }               
        public Int32 IdCliente { get; set; }
        public byte IdProcesos { get; set; }
        public string Descripcion { get; set; }
        public string Flag_NuevoRepetido { get; set; }
        public string Diseño { get; set; }
        public string IdUsuario { get; set; }
        public DateTime Fecha_Creado { get; set; }
        public string Usuario_Creador { get; set; }
        public DateTime Fecha_Modificado { get; set; }
        public string Flag_GeneradoOP { get; set; }
        public string Codigo_Estandar { get; set; }
        public string Estructura_CodBar { get; set; }
        public int Flag_EspecificacionesCC { get; set; }
        public string OrdenTrabajo_Clisses { get; set; }
        public byte[] Foto_Producto { get; set; }
        public string Ruta_Producto { get; set; }
        public Nullable<short> IdEstandarExtrusion_CC { get; set; }
        public Nullable<short> IdEstandarImpresion_CC { get; set; }
        public Nullable<byte> Flag_Embobinado1 { get; set; }
        public Nullable<byte> Flag_Embobinado2 { get; set; }
        public Nullable<byte> Flag_Embobinado3 { get; set; }
        public Nullable<byte> Flag_Embobinado4 { get; set; }
        public Nullable<byte> Flag_Embobinado5 { get; set; }
        public Nullable<byte> Flag_Embobinado6 { get; set; }
        public Nullable<byte> Flag_Embobinado7 { get; set; }
        public Nullable<byte> Flag_Embobinado8 { get; set; }
        public Nullable<byte> IdTipoProduccion { get; set; }
        public Nullable<decimal> Diametro_Solicitado { get; set; }
        public Nullable<byte> IdUnidadDiametroSolicitado { get; set; }
        public Nullable<byte> IdTipoProducto { get; set; }
        public Nullable<byte> IdCondicionProceso { get; set; }


        public virtual Int32 IdEstandarExtrusion { get; set; }
        public virtual Int32 IdEstandarSellado { get; set; }
        public virtual Int32 IdEstandarImpresion { get; set; }
        public virtual Int32 IdEstandarLaminado { get; set; }
        public virtual Int32 IdEstandarCorte { get; set; }
        public virtual string Razon_Social { get; set; }


        public PR_mEstandar()
        { }

    }
}
