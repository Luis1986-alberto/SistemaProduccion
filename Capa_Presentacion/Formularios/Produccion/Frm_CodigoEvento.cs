using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_CodigoEvento : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_CodigoEvento()
        {
            InitializeComponent();
        }

        private void Frm_CodigoEvento_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            cbo_local.DataSource = PR_aLocal_CN._Instancia.Lista_Locales();
            cbo_area.DataSource = PR_aArea_CN._Instancia.Lista_Areas();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
            Cargar_Datos();
        }
        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            List<PR_aCodigoEvento> Listado = PR_aCodigoEvento_CN._Instancia.Lista_CodigoEvento();
            SortableBindingList<PR_aCodigoEvento> lst_codigoevento = new SortableBindingList<PR_aCodigoEvento>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = lst_codigoevento;
        }

        private void Entrada_Datos(byte idcodigoevento)
        {
            var result = PR_aCodigoEvento_CN._Instancia.TraerID(idcodigoevento);
            foreach (var i in result)
            {
                txt_IdCodigoEvento.Text = i.IdCodigoEvento.ToString();
                txt_descripcionevento.Text = i.Descripcion.ToString();
                txt_codigoevento.Text = i.Codigo_Evento.ToString();
                RB_EventoColaborador.Checked = (i.Flag_EventoColaborador == "1") ? true : false;
                Rb_EventoMaquina.Checked = (i.Flag_EventoMaquina == "1") ? true : false;
                RB_EventoMaterial.Checked = (i.Flag_EventoMaterial == "1") ? true : false;
                cbo_area.SelectedValue = i.IdArea;
                cbo_local.SelectedValue = i.IdLocal;
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = true;
            tbc_Mnt.SelectTab(0);
            Habilitarcontroles(true);
            Estado_Toolbar(bln_Nuevo);
            txt_IdCodigoEvento.Text = "0";
            txt_codigoevento.Text = "";
            txt_descripcionevento.Text = "";
            RB_EventoColaborador.Checked = false;
            Rb_EventoMaquina.Checked = false;
            RB_EventoMaterial.Checked = false;
            txt_descripcionevento.Focus();

        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);
            bln_Editar = true;
            bln_Nuevo = false;

            Habilitarcontroles(true);
            Estado_Toolbar(true);
            txt_descripcionevento.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            string rpta;

            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Esta Seguro Eliminar el Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rpta = PR_aCodigoEvento_CN._Instancia.Eliminar_CodigoEvento(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aCodigoEvento()
            {
                IdCodigoEvento = byte.Parse(txt_IdCodigoEvento.Text),
                Descripcion = txt_descripcionevento.Text,
                Codigo_Evento = txt_codigoevento.Text,
                Flag_EventoColaborador = (RB_EventoColaborador.Checked == true) ? "1" : "0",
                Flag_EventoMaquina = (Rb_EventoMaquina.Checked == true) ? "1" : "0",
                Flag_EventoMaterial = (RB_EventoMaterial.Checked == true) ? "1" : "0",
                IdLocal = byte.Parse(cbo_local.SelectedValue.ToString()),
                IdArea = byte.Parse(cbo_area.SelectedValue.ToString()),
                IdUsuario = SystemInformation.UserName,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aCodigoEvento_CN._Instancia.Agregar_CodigoEvento(datos); }
            if (bln_Editar) { rpta = PR_aCodigoEvento_CN._Instancia.Actualizar_CodigoEvento(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                Habilitarcontroles(false);
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            Cargar_Datos();
        }
        private bool Verificar_Datos()
        {
            if (txt_descripcionevento.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion ", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txt_descripcionevento.Text.Trim() == "")
                    txt_descripcionevento.Focus();
                return false;
            }

            if (txt_codigoevento.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el codigo ", "Ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txt_codigoevento.Text.Trim() == "")
                    txt_codigoevento.Focus();
                return false;
            }


            return true;
        }
        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Habilitarcontroles(false);
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintDocument.Print();
            }
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

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Ordenar in PR_aCodigoEvento_CN._Instancia.Lista_CodigoEvento().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Ordenar in PR_aCodigoEvento_CN._Instancia.Lista_CodigoEvento().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdCodigoEvento"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void Habilitarcontroles(Boolean vEstado)
        {
            txt_descripcionevento.Enabled = vEstado;
            txt_codigoevento.Enabled = vEstado;
            RB_EventoColaborador.Enabled = vEstado;
            Rb_EventoMaquina.Enabled = vEstado;
            RB_EventoMaterial.Enabled = vEstado;
            cbo_area.Enabled = vEstado;
            cbo_local.Enabled = vEstado;

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

            PrintDocument.DocumentName = "Reporte Condición Proceso";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Condicion Procesos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Condicion Procesos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void cbo_local_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_area.DataSource = PR_xLocalArea_CN._Instancia.TraerIdLocal(Int32.Parse(cbo_local.SelectedValue.ToString()));
        }
    }
}
