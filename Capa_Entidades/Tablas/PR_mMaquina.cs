using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Tablas
{
    public class PR_mMaquina
    {
        public PR_mMaquina()
        {
            //this.PR_xMezcladoIndustrial = new HashSet<PR_xMezcladoIndustrial>();
            //this.PR_xImpresora = new HashSet<PR_mImpresora>();
            //this.PR_xDetalleMermaSellaInd = new HashSet<PR_xDetalleMermaSellaInd>();
            //this.PR_xPosicionMaquina = new HashSet<PR_xPosicionMaquina>();
            //this.PR_xProgramaCorteInd = new HashSet<PR_xProgramaCorteInd>();
            //this.PR_xProgramaExtrusionInd = new HashSet<PR_xProgramaExtrusionInd>();
            //this.PR_xProgramaImpresionInd = new HashSet<PR_xProgramaImpresionInd>();
            //this.PR_xProgramaLaminadoInd = new HashSet<PR_xProgramaLaminadoInd>();
            //this.PR_xProgramaSelladoInd = new HashSet<PR_xProgramaSelladoInd>();
        }

        public short IdMaquina { get; set; }
        public Nullable<byte> IdTipoMaquina { get; set; }
        public Nullable<byte> IdMarcaMaquina { get; set; }
        public string Modelo_Maquina { get; set; }
        public string Serie_Maquina { get; set; }
        public string Alias_Maquina { get; set; }
        public Int32 Numero_Maximo_OP { get; set; }
        public byte IdEmpresa { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public string Ruta_Imagen { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public byte IdAño_Fabricacion { get; set; }
        public string Procedencia { get; set; }
        public decimal Produccion_Kg { get; set; }
        public decimal Produccion_Metros { get; set; }
        public decimal Tiempo_Horas { get; set; }
        public byte Flag_Operativo { get; set; }
        public byte Flag_Baja { get; set; }
        public string Codigo_Maquina { get; set; }
        public byte IdEstadoMaquina { get; set; }
        public Int32 IdProveedor { get; set; }
        public byte[] Foto_Maquina { get; set; }

        //public virtual PR_aEmpresa PR_aEmpresa { get; set; }
        //public virtual PR_aEstadoMaquina PR_aEstadoMaquina { get; set; }
        public virtual string Descripcion_MarcaMaquina { get; set; }
        public virtual string Nombre_TipoMaquina { get; set; }
        //public virtual PR_mCapacidadExtrusion PR_mCapacidad_Extrusion { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xMezcladoIndustrial> PR_xMezcladoIndustrial { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_mImpresora> PR_xImpresora { get; set; }
        //public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xDetalleMermaSellaInd> PR_xDetalleMermaSellaInd { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xPosicionMaquina> PR_xPosicionMaquina { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xProgramaCorteInd> PR_xProgramaCorteInd { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xProgramaExtrusionInd> PR_xProgramaExtrusionInd { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xProgramaImpresionInd> PR_xProgramaImpresionInd { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xProgramaLaminadoInd> PR_xProgramaLaminadoInd { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PR_xProgramaSelladoInd> PR_xProgramaSelladoInd { get; set; }
    }
}
