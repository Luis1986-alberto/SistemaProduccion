using System;
using System.Collections.Generic;

namespace Capa_Entidades.Tablas
{
    public class PR_xPedidos
    {
        public PR_xPedidos()
        {
            this.PR_xOrdenProduccionInd = new HashSet<PR_xOrdenProduccionInd>();
            this.PR_xPedidos_DetSustrato_LM = new HashSet<PR_xPedidos_DetSustrato_LM>();
        }

        public Int32 IdNumeroPedido { get; set; }
        public string Numero_Pedido { get; set; }
        public string Numero_Orden_Compra { get; set; }
        public Nullable<decimal> IdEstandar { get; set; }
        public Nullable<byte> IdEmpresa { get; set; }
        public Nullable<byte> IdCondicionCobranza { get; set; }
        public Nullable<System.DateTime> Fecha_Pedido { get; set; }
        public Nullable<System.DateTime> Fecha_Entrega { get; set; }
        public string Flag_CantidadKg { get; set; }
        public Nullable<decimal> Cantidad_Kilos { get; set; }
        public Nullable<decimal> Merma { get; set; }        
        public Nullable<decimal> Porcentaje_Merma { get; set; }
        public Nullable<decimal> Total_Kilos { get; set; }
        public byte IdSeVendePor { get; set; }
        public Nullable<decimal> Cantidad_Millares { get; set; }
        public Nullable<decimal> Precio_Kilo { get; set; }
        public Nullable<decimal> Precio_Millar { get; set; }
        public Nullable<decimal> Reajuste_Precio_Kilo { get; set; }
        public Nullable<decimal> Reajuste_Precio_Millar { get; set; }
        public string Flag_IGV { get; set; }
        public string Flag_Incluido_Gastos { get; set; }
        public string Flag_DestararBobinaExtruida { get; set; }
        public string Flag_DestararBobinaImpresa { get; set; }
        public string Flag_PesarxPaquete { get; set; }
        public string Flag_PesarxFardo { get; set; }
        public string Flag_PesarxCaja { get; set; }
        public string Flag_Comision { get; set; }
        public string Nota_Pedido { get; set; }
        public string Flag_NuevoRepetidoHistorico { get; set; }
        public string Flag_NoExisteEspecificacion { get; set; }
        public string IdUsuario { get; set; }
        public string Pedido_General { get; set; }
        public Nullable<byte> IdTipoVenta{ get; set; }
        public string Nota { get; set; }
        public string Flag_DestararBobinaLaminado { get; set; }
        public string Flag_DestararBobinaCorte { get; set; }
        public Nullable<decimal> Metros { get; set; }
        public Nullable<System.DateTime> Fecha_Orden_Compra { get; set; }
        public string Observacion_CD { get; set; }
        public string IdUsuario_CD { get; set; }
        public string IdUsuario_PC_CD { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor_CD { get; set; }        
        public Nullable<byte> IdCondicionProceso { get; set; }
        public Nullable<short> IdTrabajador { get; set; }
        public Nullable<System.DateTime> Fecha_Servidor { get; set; }

        public virtual LG_aCondicionPago PR_aCondicionPago { get; set; }
        public virtual PR_aCondicionProceso PR_aCondicionProceso { get; set; }
        public virtual PR_aEmpresa PR_aEmpresa { get; set; }
        public virtual PR_mEstandar PR_mEstandar { get; set; }
        public virtual PR_mTrabajador PR_mTrabajador { get; set; }
        public virtual PR_mUsuarios PR_mUsuarios { get; set; }


   
        public PR_xPedidos (Int32 idpedidos)
        {
            IdNumeroPedido = idpedidos;
        }

        public PR_xPedidos(int idNumeroPedido, string numero_Pedido, string numero_Orden_Compra, decimal? idEstandar, byte? idEmpresa, 
            byte? idCondicionCobranza, DateTime? fecha_Pedido, DateTime? fecha_Entrega, string flag_CantidadKg, decimal? cantidad_Kilos, 
            decimal? merma, DateTime? fecha_Servidor, decimal? porcentaje_Merma, decimal? total_Kilos, byte idSeVendePor, decimal? cantidad_Millares, 
            decimal? precio_Kilo, decimal? precio_Millar, decimal? reajuste_Precio_Kilo, decimal? reajuste_Precio_Millar, string flag_IGV, 
            string flag_Incluido_Gastos, string flag_DestararBobinaExtruida, string flag_DestararBobinaImpresa, string flag_PesarxPaquete, 
            string flag_PesarxFardo, string flag_PesarxCaja, string flag_Comision, string nota_Pedido, string flag_NuevoRepetidoHistorico, 
            string flag_NoExisteEspecificacion, string idUsuario, string pedido_General, byte? idTipoVenta, string nota, string flag_DestararBobinaLaminado,
            string flag_DestararBobinaCorte, decimal? metros, DateTime? fecha_Orden_Compra, string observacion_CD,
            string idUsuario_CD, string idUsuario_PC_CD, DateTime? fecha_Servidor_CD, byte? idCondicionProceso, short? idTrabajador)
        {
            IdNumeroPedido = idNumeroPedido;
            Numero_Pedido = numero_Pedido;
            Numero_Orden_Compra = numero_Orden_Compra;
            IdEstandar = idEstandar;
            IdEmpresa = idEmpresa;
            IdCondicionCobranza = idCondicionCobranza;
            Fecha_Pedido = fecha_Pedido;
            Fecha_Entrega = fecha_Entrega;
            Flag_CantidadKg = flag_CantidadKg;
            Cantidad_Kilos = cantidad_Kilos;
            Merma = merma;
            Fecha_Servidor = fecha_Servidor;
            Porcentaje_Merma = porcentaje_Merma;
            Total_Kilos = total_Kilos;
            IdSeVendePor = idSeVendePor;
            Cantidad_Millares = cantidad_Millares;
            Precio_Kilo = precio_Kilo;
            Precio_Millar = precio_Millar;
            Reajuste_Precio_Kilo = reajuste_Precio_Kilo;
            Reajuste_Precio_Millar = reajuste_Precio_Millar;
            Flag_IGV = flag_IGV;
            Flag_Incluido_Gastos = flag_Incluido_Gastos;
            Flag_DestararBobinaExtruida = flag_DestararBobinaExtruida;
            Flag_DestararBobinaImpresa = flag_DestararBobinaImpresa;
            Flag_PesarxPaquete = flag_PesarxPaquete;
            Flag_PesarxFardo = flag_PesarxFardo;
            Flag_PesarxCaja = flag_PesarxCaja;
            Flag_Comision = flag_Comision;
            Nota_Pedido = nota_Pedido;
            Flag_NuevoRepetidoHistorico = flag_NuevoRepetidoHistorico;
            Flag_NoExisteEspecificacion = flag_NoExisteEspecificacion;
            IdUsuario = idUsuario;
            Pedido_General = pedido_General;
            IdTipoVenta = idTipoVenta;
            Nota = nota;
            Flag_DestararBobinaLaminado = flag_DestararBobinaLaminado;
            Flag_DestararBobinaCorte = flag_DestararBobinaCorte;
            Metros = metros;
            Fecha_Orden_Compra = fecha_Orden_Compra;
            Observacion_CD = observacion_CD;
            IdUsuario_CD = idUsuario_CD;
            IdUsuario_PC_CD = idUsuario_PC_CD;
            Fecha_Servidor_CD = fecha_Servidor_CD;
            IdCondicionProceso = idCondicionProceso;
            IdTrabajador = idTrabajador;
        }

     
        public virtual ICollection<PR_xOrdenProduccionInd> PR_xOrdenProduccionInd { get; set; }
        public virtual ICollection<PR_xPedidos_DetSustrato_LM> PR_xPedidos_DetSustrato_LM { get; set; }
        public virtual PR_aTipoVenta PR_xVentaProducto { get; set; }

    }
}
