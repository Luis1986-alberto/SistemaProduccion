using System;

namespace Capa_Entidades.Tablas
{
    public class PR_xMezcladoIndustrial
    {
        public Nullable<byte> IdPrecisionBalanza { get; set; }
        public Nullable<short> IdMaquina { get; set; }
        public Nullable<short> IdPosicionMaquina { get; set; }
        public string IdUsuario { get; set; }
        public string Observaciones { get; set; }
        public Nullable<decimal> Capacidad_Kg { get; set; }
        public string Flag_Biodegradable { get; set; }
        public Nullable<short> Numero_Llenadas_Tolva { get; set; }
        public Nullable<decimal> d2w_Kg_TolvaLlena { get; set; }
        public Nullable<decimal> d2w_Kg_Saldo { get; set; }
        public Nullable<decimal> d2w_Kg_Total { get; set; }
        public Nullable<decimal> Total_Kg_TolvaLlena { get; set; }
        public Nullable<decimal> Total_Kg_Saldo { get; set; }
        public Nullable<decimal> Total_Kg_Mezclar { get; set; }
        public Nullable<decimal> Kilos_Exceso_Defecto { get; set; }
        public Nullable<decimal> Porcentaje_Exceso_Defecto { get; set; }
        public Nullable<byte> IdMarcaMaterial_Biodegradab { get; set; }
        public Nullable<byte> IdMaterial_Biodegradable { get; set; }
        public Nullable<short> Flag_Procesado { get; set; }
        public string IdUsuario_Procesado { get; set; }
        public string IdUsuario_PC_Procesado { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Procesado { get; set; }
        public Nullable<System.DateTime> Fecha_Procesado { get; set; }
        public Nullable<short> Flag_Cierre_Programacion { get; set; }
        public string IdUsuario_Programacion { get; set; }
        public string IdUsuario_PC_Programacion { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_Programacion { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }
        public decimal IdOrdProd { get; set; }
        public string IdOrdenProduccionInd { get; set; }

        public virtual PR_aPrecisionBalanza PR_aPrecisionBalanza { get; set; }
        public virtual PR_mMaquina PR_mMaquina { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }
        public virtual PR_xOrdenProduccionInd PR_xOrdenProduccionInd { get; set; }
        public virtual PR_xPosicionMaquina PR_xPosicionMaquina { get; set; }
    }
}
