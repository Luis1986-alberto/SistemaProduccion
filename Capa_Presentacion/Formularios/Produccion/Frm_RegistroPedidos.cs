using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_RegistroPedidos : Form
    {
        
        private bool bln_Nuevo, bln_Editar = false;        
        private List<PR_xPedidos> lst_pedidos = new List<PR_xPedidos>();

        public Frm_RegistroPedidos()
        {
            InitializeComponent();
        }

        private void Frm_RegistroPedidos_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);

            Cargar_Combos();
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString())); }
        }

        private void Cargar_Combos()
        {
            cbo_FiltroCliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            cbo_tipoventa.DataSource = PR_aTipoVenta_CN._Instancia.Lista_TipoVenta();
            cbo_condicioncobranza.DataSource = LG_aCondicionCobranza_CN._Instancia.Lista_CondicionCobranza();
            cbo_facturadopor.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
            cbo_sevendepor.DataSource = PR_aSeVendePor_CN._Instancia.Lista_SeVendePor();
            cbo_tipomoneda.DataSource = PR_aTipoMoneda_CN._Instancia.Lista_TipoMoneda();
            cbo_condicionproceso.DataSource = PR_aCondicionProceso_CN._Instancia.Lista_CondicionProceso();
            cbo_vendedor.DataSource = PR_mTrabajador_CN._Intancia.lst_FiltrarDescripciontipotrabajador("ADMIN");          
            
        }


        public void Cargar_Datos()
        {
            lst_pedidos = PR_xPedidos_CN._Instancia.Lista_Pedidos( (chk_FiltroCliente.Checked == true) ? "1" : "0", Int32.Parse(cbo_FiltroCliente.SelectedValue.ToString()),
                                                           (Chk_FiltroRango.Checked == true) ? "1" : "0", Dtp_FechaInicial.Value, Dtp_FechaFinal.Value);
            SortableBindingList<PR_xPedidos> lista = new SortableBindingList<PR_xPedidos>(lst_pedidos);
            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = lista;
        }

        private void Entrada_Datos(Int32 idpedidos)
        {
            var datos = PR_xPedidos_CN.Instancia.Traer_PorId(idpedidos);

            foreach (var i in datos)
            {
                txt_IdNumeroPedido.Text = i.IdNumeroPedido.ToString();
                txt_pedidogeneral.Text = i.Pedido_General.ToString();
                txt_numeropedido.Text = i.Numero_Pedido.ToString();
                txt_ordencompra.Text = i.Numero_Orden_Compra.ToString();
                dtp_fechaordencompra.Value = i.Fecha_Orden_Compra.Value;
                dtp_fechapedido.Value = i.Fecha_Pedido.Value;
                dtp_fechaentrega.Value = i.Fecha_Entrega.Value;
                chk_destararextrusion.Checked = (i.Flag_DestararBobinaExtruida =="1")?true:false;
                chk_destararimpresion.Checked = (i.Flag_DestararBobinaImpresa == "1")?true:false;
                chk_destararlaminado.Checked = (i.Flag_DestararBobinaLaminado == "1")?true:false;
                chk_destararcorte.Checked = (i.Flag_DestararBobinaCorte == "1")?true:false;
                rb_ventasKilos.Checked = (i.Flag_CantidadKg == "1") ? true : false;
                rb_ventamillares.Checked= (i.Flag_CantidadKg == "0") ? true : false;
                nud_ventakilos.Value = i.Cantidad_Kilos;
                txt_ventamillares.Text = i.Cantidad_Millares.ToString();
                nud_merma.Value = i.Merma;
                txt_PorcentajeMerma.Text = i.Porcentaje_Merma.ToString();
                txt_totalkgpedido.Text = i.Total_Kilos.ToString();
                txt_metrospedido.Text = i.Metros.ToString();
                cbo_tipoventa.SelectedValue = i.IdTipoVenta;
                cbo_condicioncobranza.SelectedValue = i.IdCondicionCobranza;
                cbo_facturadopor.SelectedValue = i.IdEmpresa;
                cbo_sevendepor.SelectedValue = i.IdSeVendePor;
                cbo_tipomoneda.SelectedValue = i.IdTipoMoneda;
                nud_preciokilo.Value = i.Precio_Kilo;
                nud_reajusteporkilo.Value = i.Reajuste_Precio_Kilo;
                nud_preciomillar.Value = i.Precio_Millar;
                nud_reajustepormillar.Value = i.Reajuste_Precio_Millar;
                txt_notaventa.Text = i.Nota_Pedido;
                cbo_vendedor.SelectedValue = i.IdTrabajador;
                chk_comisionventa.Checked = (i.Flag_Comision == "1") ? true : false;
                chk_gastosincluidos.Checked = (i.Flag_Incluido_Gastos == "1") ? true : false;
                chk_masIGV.Checked = (i.Flag_MasIGV == "1") ? true : false;
                cbo_condicionproceso.SelectedValue = i.IdCondicionProceso;
                Cbo_Cliente.SelectedValue = i.IdCliente;
                cbo_Estandar.SelectedValue = i.IdEstandar;
            }
        }

        private void cbo_FiltroCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cbo_FiltroTipoProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dtp_FechaFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Dtp_FechaInicial_ValueChanged(object sender, EventArgs e)
        {

        }

        
        private void chk_FiltroTipoEstandar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;
            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tp_Listado"].Enabled = false;
            HabilitarControles(true);
            Limpiar_Controles();
            txt_IdNumeroPedido.Text = "0";
            txt_pedidogeneral.Focus();
        }

        private void Estado_Toolbar(Boolean vEditarForm, Boolean vUnloadForm = true)
        {
            tls_Agregar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Modificar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Eliminar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Grabar.Enabled = (vUnloadForm) ? vEditarForm : false;
            tls_Deshacer.Enabled = (vUnloadForm) ? vEditarForm : false;
            tls_Imprimir.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Previo.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Buscar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_OrdenASC.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_OrdenDsc.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Refrescar.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Primero.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Anterior.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Siguiente.Enabled = (vUnloadForm) ? !vEditarForm : false;
            tls_Ultimo.Enabled = (vUnloadForm) ? !vEditarForm : false;
        }

        private void HabilitarControles(Boolean vestado)
        {
            txt_pedidogeneral.Enabled = vestado;
            txt_numeropedido.Enabled = vestado;
            txt_ordencompra.Enabled = vestado;
            dtp_fechaordencompra.Enabled = vestado;
            dtp_fechapedido.Enabled = vestado;
            dtp_fechaentrega.Enabled = vestado;
            chk_destararextrusion.Enabled = vestado;
            chk_destararimpresion.Enabled = vestado;
            chk_destararlaminado.Enabled = vestado;
            chk_destararcorte.Enabled = vestado;
            rb_ventasKilos.Enabled = vestado;
            nud_ventakilos.Enabled = vestado;
            rb_ventamillares.Enabled = vestado;
            txt_ventamillares.Enabled = vestado;
            nud_merma.Enabled = vestado;          
            cbo_tipoventa.Enabled = vestado;
            cbo_condicioncobranza.Enabled = vestado;
            cbo_facturadopor.Enabled = vestado;
            cbo_sevendepor.Enabled = vestado;
            nud_preciokilo.Enabled = vestado;
            nud_reajusteporkilo.Enabled = vestado;
            nud_preciomillar.Enabled = vestado;
            nud_reajustepormillar.Enabled = vestado;
            cbo_tipomoneda.Enabled = vestado;
            txt_notaventa.Enabled = vestado;
            cbo_vendedor.Enabled = vestado;
            chk_comisionventa.Enabled = vestado;
            chk_gastosincluidos.Enabled = vestado;
            cbo_condicionproceso.Enabled = vestado;           
            Cbo_Cliente.Enabled = vestado;
            cmd_Clientes.Enabled = vestado;
            txt_CodigoEstandar.Enabled = vestado;
            cbo_Estandar.Enabled = vestado;
            cmd_VerEstandar.Enabled = vestado;
            chk_masIGV.Enabled = vestado;
            cbo_condicionproceso.Enabled = vestado;
        }

        private void Limpiar_Controles()
        {
            txt_pedidogeneral.Text = " ";
            txt_numeropedido.Text = " ";
            txt_ordencompra.Text = " ";
            chk_destararextrusion.Checked = false;
            chk_destararimpresion.Checked = false;
            chk_destararlaminado.Checked = false;
            chk_destararlaminado.Checked = false;
            rb_ventasKilos.Checked = false;
            rb_ventamillares.Checked = false;
            nud_ventakilos.Text = "0.00";
            txt_ventamillares.Text = "0.00";
            nud_merma.Text = "0.00";
            txt_PorcentajeMerma.Text = "0.00";
            txt_totalkgpedido.Text = "0.00";
        }

        private void cmd_Clientes_Click(object sender, EventArgs e)
        {
            Frm_Cliente cliente = new Frm_Cliente();
            cliente.ShowDialog();
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
        }

        private void btn_TipoVenta_Click(object sender, EventArgs e)
        {
            Frm_TipoVenta tipoventa = new Frm_TipoVenta();
            tipoventa.ShowDialog();
            cbo_tipoventa.DataSource = PR_aTipoVenta_CN._Instancia.Lista_TipoVenta();
        }

        private void btn_CondicionCobranza_Click(object sender, EventArgs e)
        {
            Frm_CondicionCobranza condicioncobranza = new Frm_CondicionCobranza();
            condicioncobranza.ShowDialog();
            cbo_condicioncobranza.DataSource = LG_aCondicionCobranza_CN._Instancia.Lista_CondicionCobranza();
        }

        private void btn_FacturadoPor_Click(object sender, EventArgs e)
        {
            Frm_Empresa empresa = new Frm_Empresa();
            empresa.ShowDialog();
            cbo_facturadopor.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
        }

        private void btn_SeVendePor_Click(object sender, EventArgs e)
        {
            Frm_SeVendePor sevendepor = new Frm_SeVendePor();
            sevendepor.ShowDialog();
            cbo_sevendepor.DataSource = PR_aSeVendePor_CN._Instancia.Lista_SeVendePor();
        }

        private void btn_Moneda_Click(object sender, EventArgs e)
        {
            Frm_TipoMoneda tipomoneda = new Frm_TipoMoneda();
            tipomoneda.ShowDialog();
            cbo_tipomoneda.DataSource = PR_aTipoMoneda_CN._Instancia.Lista_TipoMoneda();
        }

        private void btn_Vendedor_Click(object sender, EventArgs e)
        {
            Frm_RegistroTrabajador trabajador = new Frm_RegistroTrabajador();
            trabajador.ShowDialog();
            cbo_vendedor.DataSource = PR_mTrabajador_CN._Intancia.Lista_Trabajadores("0", 0, "0", 0);
        }

        private void cmd_VerEstandar_Click(object sender, EventArgs e)
        {
            Frm_ConsEstandart consestandart = new Frm_ConsEstandart();
            consestandart.idEstandart = Int32.Parse(cbo_Estandar.SelectedValue.ToString());
            consestandart.ShowDialog();
        }

        private void Cbo_Cliente_SelectedIndexChanged(object sender, EventArgs e)
        {cbo_Estandar.DataSource = PR_mEstandar_CN._Instancia.Filtrar_PorIdCliente(Int32.Parse(Cbo_Cliente.SelectedValue.ToString()));}        

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta= "";
            Calcular_Totales();
            var datos = new PR_xPedidos()
            {
                IdNumeroPedido = Int32.Parse(txt_IdNumeroPedido.Text),
                Pedido_General = txt_pedidogeneral.Text,
                Numero_Pedido = txt_numeropedido.Text,
                Numero_Orden_Compra = txt_ordencompra.Text,
                Fecha_Orden_Compra = dtp_fechaordencompra.Value,
                Fecha_Pedido = dtp_fechapedido.Value,
                Fecha_Entrega = dtp_fechaentrega.Value,
                Flag_DestararBobinaExtruida = (chk_destararextrusion.Checked == true) ? "1" : "0",
                Flag_DestararBobinaCorte = (chk_destararcorte.Checked == true) ? "1" : "0",
                Flag_DestararBobinaImpresa = (chk_destararimpresion.Checked == true) ? "1" : "0",
                Flag_DestararBobinaLaminado = (chk_destararlaminado.Checked == true) ? "1" : "0",
                Flag_CantidadKg = (rb_ventasKilos.Checked == true) ? "1" : "0",
                Cantidad_Kilos = decimal.Parse(nud_ventakilos.Value.ToString()),
                Cantidad_Millares = decimal.Parse(txt_ventamillares.Text),
                Merma = decimal.Parse(nud_merma.Value.ToString()),
                Porcentaje_Merma = decimal.Parse(txt_PorcentajeMerma.Text),
                Total_Kilos = decimal.Parse(txt_totalkgpedido.Text),
                Metros = decimal.Parse(txt_metrospedido.Text),
                IdEstandar = Int32.Parse(cbo_Estandar.SelectedValue.ToString()),
                IdTipoVenta = byte.Parse(cbo_tipoventa.SelectedValue.ToString()),
                IdCondicionCobranza = byte.Parse(cbo_condicioncobranza.SelectedValue.ToString()),
                IdEmpresa = byte.Parse(cbo_facturadopor.SelectedValue.ToString()),
                IdSeVendePor = byte.Parse(cbo_sevendepor.SelectedValue.ToString()),
                IdTipoMoneda = byte.Parse(cbo_tipomoneda.SelectedValue.ToString()),
                Precio_Kilo = decimal.Parse(nud_preciokilo.Value.ToString()),
                Precio_Millar = decimal.Parse(nud_preciomillar.Value.ToString()),
                Reajuste_Precio_Kilo = decimal.Parse(nud_reajusteporkilo.Value.ToString()),
                Reajuste_Precio_Millar = decimal.Parse(nud_reajustepormillar.Value.ToString()),
                Nota_Pedido = txt_notaventa.Text,
                IdTrabajador = short.Parse(cbo_vendedor.SelectedValue.ToString()),
                Flag_MasIGV = (chk_masIGV.Checked == true) ? "1" : "0",
                Flag_Incluido_Gastos = (chk_gastosincluidos.Checked == true) ? "1" : "0",
                Flag_Comision = (chk_comisionventa.Checked == true) ? "1" : "0",
                IdCondicionProceso = byte.Parse(cbo_condicionproceso.SelectedValue.ToString()),
                IdUsuario = Variables_Globales.IdUsuario,
                Flag_NuevoRepetidoHistorico = "0",
            };

            if (bln_Nuevo)  rpta = PR_xPedidos_CN._Instancia.Agregar_Pedidos(datos);
            if (bln_Editar) rpta = PR_xPedidos_CN._Instancia.Actualizar_Pedidos(datos);

            if (rpta == "PROCESADO") {
                MessageBox.Show("SE REALIZO EL PROCESO CON EXITO", "SE PROCESO ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HabilitarControles(false);
                Cargar_Datos();
                tbc_Mnt.TabPages["tp_Listado"].Enabled = true;
                tbc_Mnt.SelectTab(1);}
            else MessageBox.Show(rpta, "OCURRIO EL SIGUIENTE ERROR :", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString()));
            HabilitarControles(true);
            bln_Editar = true;
        }

        private void btn_CondicionProceso_Click(object sender, EventArgs e)
        {
            Frm_CondicionProceso condicionproceso = new Frm_CondicionProceso();
            condicionproceso.ShowDialog();
            cbo_condicionproceso.DataSource = PR_aCondicionProceso_CN._Instancia.Lista_CondicionProceso();
        }

        private void Chk_FiltroRango_CheckedChanged(object sender, EventArgs e)
        {
            Dtp_FechaInicial.Enabled = Chk_FiltroRango.Checked;
            Dtp_FechaFinal.Enabled = Chk_FiltroRango.Checked;
        }

        private void chk_FiltroCliente_CheckedChanged(object sender, EventArgs e)
        {
            cbo_FiltroCliente.Enabled = chk_FiltroCliente.Checked;
        }

        private void Limpiarcontroles()
        {
            txt_pedidogeneral.Text = "";
            txt_numeropedido.Text = "";
            txt_ordencompra.Text = "";

            chk_destararextrusion.Checked = false;
            chk_destararimpresion.Checked = false;
            chk_destararlaminado.Checked = false;
            chk_destararcorte.Checked = false;
            rb_ventasKilos.Checked = false;
            rb_ventamillares.Checked = false;
            nud_ventakilos.Text = "0.00";
            txt_ventamillares.Text = "0.00";
            nud_merma.Text = "0.00";
            txt_PorcentajeMerma.Text = "0.00";
            nud_preciokilo.Text = "0.00";
            nud_preciomillar.Text = "0.00";
            txt_notaventa.Text = " ";
        }

        private void nud_ventakilos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_Campos.NumerosDecimales(e);            
            Calcular_Totales();
        }

        private void nud_merma_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_Campos.NumerosDecimales(e);
            if (nud_ventakilos.Value == 0)
            {
                nud_ventakilos.Focus();
                return;
            }
            Calcular_Totales();                
        }

        private void nud_ventakilos_KeyUp(object sender, KeyEventArgs e)=> Calcular_Totales();
        private void txt_ventamillares_KeyPress(object sender, KeyPressEventArgs e)=> Validar_Campos.NumerosDecimales(e);
        private void nud_merma_KeyUp(object sender, KeyEventArgs e)=> Calcular_Totales();
        private void nud_ventakilos_Click(object sender, EventArgs e) => Calcular_Totales();
        private void nud_merma_Click(object sender, EventArgs e)=>Calcular_Totales();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdNumeroPedido"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            string str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_ordenado = (from pedidos in lst_pedidos.OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                  select pedidos).ToList();
            dgv_Mnt.DataSource = lista_ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            string str_campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_ordenado = (from pedidos in lst_pedidos.OrderBy(r => r.GetType().GetProperty(str_campo).GetValue(r, null)) select pedidos).ToList();
            dgv_Mnt.DataSource = lista_ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void txt_numeropedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter | e.KeyChar == (char)Keys.Tab)
            {
                List<PR_xPedidos> lsta = PR_xPedidos_CN._Instancia.Buscar_PedidosIndustrial(txt_numeropedido.Text);
                if (lsta.Count > 0) MessageBox.Show("CAMBIAR EL N° DE PEDIDO " + txt_numeropedido.Text, "ERROR EXISTE N° PEDIDO :", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = false;
            tbc_Mnt.SelectTab(1);
            Estado_Toolbar(false);
            tbc_Mnt.TabPages["tp_Listado"].Enabled = true;
            HabilitarControles(false);
        }

        private void cbo_FiltroCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {if(chk_FiltroCliente.Checked == true)Cargar_Datos();}

        private void Calcular_Totales()
        {
            if (nud_ventakilos.Value == 0) return;
            decimal e = (100 / nud_ventakilos.Value);
            txt_PorcentajeMerma.Text =(decimal.Round((nud_merma.Value * e),2)).ToString();
            txt_totalkgpedido.Text = (decimal.Parse(nud_ventakilos.Value.ToString()) + decimal.Parse(nud_merma.Value.ToString())).ToString();
        }



    }
}
