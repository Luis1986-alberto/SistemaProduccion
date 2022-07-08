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
        private List<PR_xPedidosIndustriales> lst_pedidos = new List<PR_xPedidosIndustriales>();

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
            
            //cbo_Estandar.DataSource = PR_mEstandar_CN._Instancia.Lista_Estandares();
        }


        public void Cargar_Datos()
        {
            lst_pedidos = PR_xPedidos_CN._Instancia.Lista_Pedidos( (chk_FiltroCliente.Checked == true) ? "1" : "0", Int32.Parse(cbo_FiltroCliente.SelectedValue.ToString()),
                                                           (Chk_FiltroRango.Checked == true) ? "1" : "0", Dtp_FechaInicial.Value, Dtp_FechaFinal.Value);
            SortableBindingList<PR_xPedidosIndustriales> lista = new SortableBindingList<PR_xPedidosIndustriales>(lst_pedidos);
            dgv_mnt.AutoGenerateColumns = false;
            dgv_mnt.DataSource = lista;
        }

        private void Entrada_Datos(Int32 idpedidos)
        {
            //var datos = PR_aSemana_CN._Instancia.TraerPorID(Id);

            //foreach (var i in datos)
            //{
            //    txt_IdSemana.Text = i.IdSemana.ToString();
            //    txt_NombreSemana.Text = i.Nombre_Semana;
            //}
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

        private void Chk_FiltroRango_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_FiltroTipoEstandar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(0);
            Habilitarcontroles(true);
            Limpiarcontroles();
        }


        private void Habilitarcontroles(Boolean vestado)
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
            txt_ventakilos.Enabled = vestado;
            rb_ventamillares.Enabled = vestado;
            txt_ventamillares.Enabled = vestado;
            txt_merma.Enabled = vestado;
            txt_Porcentajemerma.Enabled = vestado;
            txt_totalKG.Enabled = vestado;
            cbo_tipoventa.Enabled = vestado;
            cbo_condicioncobranza.Enabled = vestado;
            cbo_facturadopor.Enabled = vestado;
            cbo_sevendepor.Enabled = vestado;
            txt_preciokilo.Enabled = vestado;
            txt_preciomillar.Enabled = vestado;
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
            txt_ventakilos.Text = "0.00";
            txt_ventamillares.Text = "0.00";
            txt_merma.Text = "0.00";
            txt_Porcentajemerma.Text = "0.00";
            txt_preciokilo.Text = "0.00";
            txt_preciomillar.Text = "0.00";
            txt_notaventa.Text = " ";



        }


    }
}
