using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void Cargar_Combos()
        {
            cbo_FiltroCliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
            Cbo_Cliente.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();
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

        private void chk_FiltroCliente_CheckedChanged_1(object sender, EventArgs e)
        {
            cbo_FiltroCliente.Enabled = chk_FiltroCliente.Checked;
        }

        private void chk_FiltroCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {

        }


        private void Habilitarcontroles()
        {

        }

        

        private void Limpiarcontroles()
        {

        }

       
       

    }
}
