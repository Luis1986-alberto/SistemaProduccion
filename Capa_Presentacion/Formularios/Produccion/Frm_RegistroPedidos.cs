using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_RegistroPedidos : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo, bln_Editar = false;
        private string str_Campo;
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
            if (dgv_mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_mnt.SelectedRows[0].Cells["IdPedidos"].Value.ToString())); }
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
            dgv_mnt.AutoGenerateColumns = false;
            dgv_mnt.DataSource = lista;
        }

        private void Entrada_Datos(Int32 idpedidos)
        {
            var datos = PR_xPedidos_CN.Instancia.Traer_PorId(idpedidos);

            foreach (var i in datos)
            {
                txt_pedidogeneral.Text = i.Pedido_General.ToString();
                txt_numeropedido.Text = i.Numero_Pedido.ToString();
                txt_ordencompra.Text = i.Numero_Orden_Compra.ToString();
                dtp_fechaordencompra.Value = i.Fecha_Orden_Compra.Value;
                dtp_fechapedido.Value = i.Fecha_Pedido.Value;
                dtp_fechaentrega.Value = i.Fecha_Entrega.Value;
                chk_destararextrusion.Checked = Boolean.Parse(i.Flag_DestararBobinaExtruida);
                chk_destararimpresion.Checked = Boolean.Parse(i.Flag_DestararBobinaImpresa);
                chk_destararlaminado.Checked = Boolean.Parse(i.Flag_DestararBobinaLaminado);
                chk_destararcorte.Checked = Boolean.Parse(i.Flag_DestararBobinaCorte);
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
            nud_Porcentajemerma.Enabled = vestado;
            nud_totalKG.Enabled = vestado;
            cbo_tipoventa.Enabled = vestado;
            cbo_condicioncobranza.Enabled = vestado;
            cbo_facturadopor.Enabled = vestado;
            cbo_sevendepor.Enabled = vestado;
            nud_preciokilo.Enabled = vestado;
            nud_preciomillar.Enabled = vestado;
            cbo_tipomoneda.Enabled = vestado;
            txt_notaventa.Enabled = vestado;
            cbo_vendedor.Enabled = vestado;
            chk_comisionventa.Enabled = vestado;
            chk_gastosincluidos.Enabled = vestado;
            cbo_condicionproceso.Enabled = vestado;
            txt_observacionpedido.Enabled = vestado;
            Cbo_Cliente.Enabled = vestado;
            cmd_Clientes.Enabled = vestado;
            txt_CodigoEstandar.Enabled = vestado;
            cbo_Estandar.Enabled = vestado;
            cmd_VerEstandar.Enabled = vestado;
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
            nud_Porcentajemerma.Text = "0.00";
            nud_totalKG.Text = "0.00";
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
            var datos = new PR_xPedidos
            {
                IdNumeroPedido = Int32.Parse(txt_IdNumeroPedido.Text),
                Pedido_General = txt_pedidogeneral.Text,
                Numero_Pedido =txt_numeropedido.Text,
                Numero_Orden_Compra = txt_ordencompra.Text,
                Fecha_Orden_Compra = dtp_fechaordencompra.Value,
                Fecha_Pedido = dtp_fechapedido.Value,
                Fecha_Entrega = dtp_fechaentrega.Value,
                Flag_DestararBobinaExtruida = (chk_destararextrusion.Checked == true)?"1":"0",
                Flag_DestararBobinaCorte = (chk_destararcorte.Checked == true)?"1":"0",
                Flag_DestararBobinaImpresa = (chk_destararimpresion.Checked == true)?"1":"0",
                Flag_DestararBobinaLaminado = (chk_destararlaminado.Checked == true)?"1":"0",
                IdSeVendePor = byte.Parse(cbo_sevendepor.SelectedValue.ToString()),



            };
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            
            HabilitarControles(true);

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

        

        private void txt_pedidogeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                List<PR_xPedidos> lsta = PR_xPedidos_CN._Instancia.Buscar_PedidosIndustrial(txt_pedidogeneral.Text);
                if (lsta.Count > 0) MessageBox.Show("Existe este NUMERO PEDIDO" + txt_pedidogeneral.Text);
            }
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
            nud_Porcentajemerma.Text = "0.00";
            nud_preciokilo.Text = "0.00";
            nud_preciomillar.Text = "0.00";
            txt_notaventa.Text = " ";
        }





    }
}
