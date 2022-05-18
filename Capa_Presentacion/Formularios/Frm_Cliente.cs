using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_Cliente : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;
        private int int_OutPutId;
        private int int_IdCliente;
        private string str_Razon_Social;
        private string str_RUC_Empresa;
        private string str_Direccion;
        private string str_Direccion_Fiscal;
        private byte byt_Flag_Natural;
        private string str_Pagina_Web;
        private string str_Nombre_Contacto;
        private string str_Referencias;
        private string str_Observacion;
        private string str_Numero_Telefono1;
        private string str_Numero_Telefono2;
        private string str_Numero_Celular1;
        private string str_Numero_Celular2;
        private string str_Nombre_TipoRubro;

        public Boolean Selecccionar_Registro { get; set; }

        public Frm_Cliente()
        {

            InitializeComponent();
        }

        private void Frm_Cliente_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            cbo_TipoRubro.DataSource = PR_mClientes_CN._Instancia.Lista_Clientes();

            Carga_Combos();
            Carga_Datos();

            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount > 0)
            {
                if (!bln_Editar) { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString())); }
            }
        }

        private void tbc_Mnt_Selected(object sender, TabControlEventArgs e)
        {
            if (dgv_Mnt.RowCount > 0)
            {
                if (bln_Editar) 
                {
                    tbc_Mnt.SelectTab(0);
                    Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString())); 
                }
            }
        }
        private void Carga_Datos()
        {
            List<PR_mClientes> Listado = PR_mClientes_CN._Instancia.Lista_Clientes();

            SortableBindingList<PR_mClientes> Listado_Clientes = new SortableBindingList<PR_mClientes>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = Listado_Clientes;
        }

        private void Carga_Combos()
        {
            var Repositorio_TipoRubros = PR_aTipoRubro_CN._instancia.Lista_TipoRubro();

            cbo_TipoRubro.DataSource = Repositorio_TipoRubros;
        }

        private void Entrada_Datos(int IdCliente)
        {
            var Repositorio = PR_mClientes_CN._Instancia.TraerIdCliente(IdCliente);
            foreach(var Registro in Repositorio) 
            {
                txt_IdCliente.Text = Registro.IdCliente.ToString();
                txt_Razon_Social.Text = Registro.Razon_Social.ToString();
                txt_RUC_Empresa.Text = Registro.RUC_Empresa.ToString();
                txt_Direccion.Text = Registro.Direccion.ToString();
                txt_Direccion_Fiscal.Text = Registro.Direccion_Fiscal.ToString();
                txt_Pagina_Web.Text = Registro.Pagina_Web.ToString();
                txt_Nombre_Contacto.Text = Registro.Nombre_Contacto.ToString();
                txt_Referencias.Text = Registro.Referencias.ToString();
                txt_Numero_Telefono1.Text = Registro.Numero_Telefono1.ToString();
                txt_Numero_Telefono2.Text = Registro.Numero_Telefono2.ToString();
                txt_Numero_Celular1.Text = Registro.Numero_Celular1.ToString();
                txt_Numero_Celular2.Text = Registro.Numero_Celular2.ToString();
                txt_Observacion.Text = Registro.Observacion.ToString();

                chk_Flag_Natural.Checked = Convert.ToBoolean(byte.Parse(Registro.Flag_Natural.ToString()));

                Posicionar_Combos(Registro.IdTipoRubro);
            }
        }

        public void Posicionar_Combos(byte IdTipoRubro)
        {
            cbo_TipoRubro.SelectedIndex = 0;
            cbo_TipoRubro.SelectedValue = IdTipoRubro;
        }
        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            Habilitar_Controles(true);
            Limpiar_Controles();
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;

            txt_RUC_Empresa.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bln_Editar = true;
            bln_Nuevo = false;

            Estado_Toolbar(bln_Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);

            Habilitar_Controles(true);

            txt_RUC_Empresa.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay Registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);

            if (MessageBox.Show("Esta seguro eliminar el registro","Eliminar Registro",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                int IdCliente = PR_mClientes_CN._Instancia.Eliminar_Cliente(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString()));

                Carga_Datos();

                tbc_Mnt.SelectTab(1);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            }
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                var Datos = new PR_mClientes
                {
                    IdCliente = int.Parse(txt_IdCliente.Text),
                    Razon_Social = txt_Razon_Social.Text.ToUpper().Trim(),
                    RUC_Empresa = txt_RUC_Empresa.Text.ToUpper().Trim(),
                    Direccion = txt_Direccion.Text.ToUpper().Trim(),
                    Direccion_Fiscal = txt_Direccion_Fiscal.Text.ToUpper().Trim(),
                    Flag_Natural = Convert.ToByte(chk_Flag_Natural.Checked),
                    Pagina_Web = txt_Pagina_Web.Text.ToUpper().Trim(),
                    Nombre_Contacto = txt_Nombre_Contacto.Text.ToUpper().Trim(),
                    Referencias = txt_Referencias.Text.ToUpper().Trim(),
                    Observacion = txt_Observacion.Text.ToUpper().Trim(),
                    Numero_Telefono1 = txt_Numero_Telefono1.Text.ToUpper().Trim(),
                    Numero_Telefono2 = txt_Numero_Telefono2.Text.ToUpper().Trim(),
                    Numero_Celular1 = txt_Numero_Celular1.Text.ToUpper().Trim(),
                    Numero_Celular2 = txt_Numero_Celular2.Text.ToUpper().Trim(),
                    IdTipoRubro = byte.Parse(cbo_TipoRubro.SelectedValue.ToString()),
                };

                if ((Verificar_Datos() == false)) { return; }

                if (bln_Nuevo) { int_OutPutId = PR_mClientes_CN._Instancia.Agregar_Cliente(Datos); }
                if (bln_Editar) { int_OutPutId = PR_mClientes_CN._Instancia.Actualizar_Cliente(Datos); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.SelectTab(1);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;

                Habilitar_Controles(false);

                Carga_Datos();
                dgv_Mnt.ClearSelection();

                foreach (DataGridViewRow row in dgv_Mnt.Rows)
                if (row.Cells["IdCliente"].Value.ToString() == int_OutPutId.ToString()) { row.Selected = true; }  

                dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Inesperado",MessageBoxButtons.OK,MessageBoxIcon.Error );
                Carga_Datos();
            }
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Habilitar_Controles(false);
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting()) { PrintDocument.Print(); }
        }

        private void tls_Previo_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = PrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void tls_Refrescar_Click(object sender, EventArgs e)
        {Carga_Datos();}

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString()));
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Cliente in PR_mClientes_CN._Instancia.Lista_Clientes().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Cliente).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Cliente in PR_mClientes_CN._Instancia.Lista_Clientes().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Cliente).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void dgv_Mnt_DoubleClick(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(0);

            if (Selecccionar_Registro == true)
            {
                int_IdCliente = int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCliente"].Value.ToString());
                str_Razon_Social = dgv_Mnt.SelectedRows[0].Cells["Razon_Social"].Value.ToString();
                str_RUC_Empresa = dgv_Mnt.SelectedRows[0].Cells["RUC_Empresa"].Value.ToString();
                str_Direccion = dgv_Mnt.SelectedRows[0].Cells["Direccion"].Value.ToString();
                str_Direccion_Fiscal = dgv_Mnt.SelectedRows[0].Cells["Direccion_Fiscal"].Value.ToString();
                byt_Flag_Natural = byte.Parse(dgv_Mnt.SelectedRows[0].Cells["Flag_Natural"].Value.ToString());
                str_Pagina_Web = dgv_Mnt.SelectedRows[0].Cells["Pagina_Web"].Value.ToString();
                str_Nombre_Contacto = dgv_Mnt.SelectedRows[0].Cells["Nombre_Contacto"].Value.ToString();
                str_Referencias = dgv_Mnt.SelectedRows[0].Cells["Referencias"].Value.ToString();
                str_Observacion = dgv_Mnt.SelectedRows[0].Cells["Observacion"].Value.ToString();
                str_Numero_Telefono1 = dgv_Mnt.SelectedRows[0].Cells["Numero_Telefono1"].Value.ToString();
                str_Numero_Telefono2 = dgv_Mnt.SelectedRows[0].Cells["Numero_Telefono2"].Value.ToString();
                str_Numero_Celular1 = dgv_Mnt.SelectedRows[0].Cells["Numero_Celular1"].Value.ToString();
                str_Numero_Celular2 = dgv_Mnt.SelectedRows[0].Cells["Numero_Celular2"].Value.ToString();
                str_Nombre_TipoRubro = dgv_Mnt.SelectedRows[0].Cells["Nombre_TipoRubro"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
        private void Habilitar_Controles(Boolean vEnabled)
        {
            txt_Razon_Social.Enabled = vEnabled;
            txt_RUC_Empresa.Enabled = vEnabled;
            txt_Direccion.Enabled = vEnabled;
            txt_Direccion_Fiscal.Enabled = vEnabled;
            chk_Flag_Natural.Enabled = vEnabled;
            txt_Pagina_Web.Enabled = vEnabled;
            txt_Nombre_Contacto.Enabled = vEnabled;
            txt_Referencias.Enabled = vEnabled;
            txt_Observacion.Enabled = vEnabled;
            txt_Numero_Telefono1.Enabled = vEnabled;
            txt_Numero_Telefono2.Enabled = vEnabled;
            txt_Numero_Celular1.Enabled = vEnabled;
            txt_Numero_Celular2.Enabled = vEnabled;

            cbo_TipoRubro.Enabled = vEnabled;
        }

        private void Limpiar_Controles()
        {
            cbo_TipoRubro.Text = "";

            chk_Flag_Natural.Checked = false;

            txt_IdCliente.Text = "0";
            txt_Razon_Social.Text = "";
            txt_RUC_Empresa.Text = "";
            txt_Direccion.Text = "";
            txt_Direccion_Fiscal.Text = "";
            txt_Pagina_Web.Text = "";
            txt_Nombre_Contacto.Text = "";
            txt_Referencias.Text = "";
            txt_Observacion.Text = "";
            txt_Numero_Telefono1.Text = "";
            txt_Numero_Telefono2.Text = "";
            txt_Numero_Celular1.Text = "";
            txt_Numero_Celular2.Text = "";
        }

        public bool Verificar_Datos()
        {
            if (txt_Razon_Social.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre del cliente", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Razon_Social.Focus();
                return false;
            }
            if (txt_RUC_Empresa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el R.U.C. del cliente", "Ingreso de datos", MessageBoxButtons.OK);
                txt_RUC_Empresa.Focus();
                return false;
            }

            if (txt_Direccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese dirección del cliente", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Direccion.Focus();
                return false;
            }

            if (txt_Direccion_Fiscal.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese dirección fiscal del cliente", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Direccion_Fiscal.Focus();
                return false;
            }

            return true;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            PrintDocument.DocumentName = "Reporte Clientes";

            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Clientes", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Clientes", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        private void txt_Razon_Social_Enter(object sender, EventArgs e)
        {
            txt_Razon_Social.BackColor = Color.Cornsilk;
        }
        private void txt_Razon_Social_Leave(object sender, EventArgs e)
        {
            txt_Razon_Social.BackColor = Color.White;
        }
        private void txt_RUC_Empresa_Enter(object sender, EventArgs e)
        {
            txt_RUC_Empresa.BackColor = Color.Cornsilk;
        }
        private void txt_RUC_Empresa_Leave(object sender, EventArgs e)
        {
            txt_RUC_Empresa.BackColor = Color.White;
        }

        private void txt_Direccion_Enter(object sender, EventArgs e)
        {
            txt_Direccion.BackColor = Color.Cornsilk;
        }
        private void txt_Direccion_Leave(object sender, EventArgs e)
        {
            txt_Direccion.BackColor = Color.White;
        }

        private void txt_Direccion_Fiscal_Enter(object sender, EventArgs e)
        {
            txt_Direccion_Fiscal.BackColor = Color.Cornsilk;
        }
        private void txt_Direccion_Fiscal_Leave(object sender, EventArgs e)
        {
            txt_Direccion_Fiscal.BackColor = Color.White;
        }
        private void txt_Pagina_Web_Enter(object sender, EventArgs e)
        {
            txt_Pagina_Web.BackColor = Color.Cornsilk;
        }
        private void txt_Pagina_Web_Leave(object sender, EventArgs e)
        {
            txt_Pagina_Web.BackColor = Color.White;
        }
        private void txt_Nombre_Contacto_Enter(object sender, EventArgs e)
        {
            txt_Nombre_Contacto.BackColor = Color.Cornsilk;
        }
        private void txt_Nombre_Contacto_Leave(object sender, EventArgs e)
        {
            txt_Nombre_Contacto.BackColor = Color.White;
        }
        private void txt_Referencias_Enter(object sender, EventArgs e)
        {
            txt_Referencias.BackColor = Color.Cornsilk;
        }
        private void txt_Referencias_Leave(object sender, EventArgs e)
        {
            txt_Referencias.BackColor = Color.White;
        }
        private void txt_Numero_Telefono1_Enter(object sender, EventArgs e)
        {
            txt_Numero_Telefono1.BackColor = Color.Cornsilk;
        }
        private void txt_Numero_Telefono1_Leave(object sender, EventArgs e)
        {
            txt_Numero_Telefono1.BackColor = Color.White;
        }
        private void txt_Numero_Telefono2_Enter(object sender, EventArgs e)
        {
            txt_Numero_Telefono2.BackColor = Color.Cornsilk;
        }
        private void txt_Numero_Telefono2_Leave(object sender, EventArgs e)
        {
            txt_Numero_Telefono2.BackColor = Color.White;
        }
        private void txt_Numero_Celular1_Enter(object sender, EventArgs e)
        {
            txt_Numero_Celular1.BackColor = Color.Cornsilk;
        }
        private void txt_Numero_Celular1_Leave(object sender, EventArgs e)
        {
            txt_Numero_Celular1.BackColor = Color.White;
        }
        private void txt_Numero_Celular2_Enter(object sender, EventArgs e)
        {
            txt_Numero_Celular2.BackColor = Color.Cornsilk;
        }
        private void txt_Numero_Celular2_Leave(object sender, EventArgs e)
        {
            txt_Numero_Celular2.BackColor = Color.White;
        }
        private void txt_Observacion_Enter(object sender, EventArgs e)
        {
            txt_Observacion.BackColor = Color.Cornsilk;
        }
        private void txt_Observacion_Leave(object sender, EventArgs e)
        {
            txt_Observacion.BackColor = Color.White;
        }
        private void cbo_TipoRubro_Enter(object sender, EventArgs e)
        {
            cbo_TipoRubro.BackColor = Color.Cornsilk;
        }
        private void cbo_TipoRubro_Leave(object sender, EventArgs e)
        {
            cbo_TipoRubro.BackColor = Color.White;
        }

        private void cmd_Rubro_Click(object sender, EventArgs e)
        {
            Frm_TipoRubro tiporubro = new Frm_TipoRubro();
            tiporubro.ShowDialog();
            cbo_TipoRubro.DataSource = PR_aTipoRubro_CN._instancia.Lista_TipoRubro();
        }


    }
}
