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
    public partial class Frm_Area : Form
    {
        private bool bln_Nuevo, bln_Editar = false;
        DataGridViewPrinter dgr_Visor_Grilla;
        private string str_Campo;

        public Frm_Area()
        {
            InitializeComponent();
        }

        private void Frm_Area_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdArea"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            List<PR_aArea> Listado = PR_aArea_CN.Instancia.Lista_Areas();
            SortableBindingList<PR_aArea> datos = new SortableBindingList<PR_aArea>(Listado);
            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = datos;
        }

        private void Entrada_Datos(byte id)
        {
            var datos = PR_aArea_CN.Instancia.TraerID(id);
            foreach (var i in datos)
            {
                txt_IdArea.Text = i.IdArea.ToString();
                txt_NombreArea.Text = i.Nombre_Area.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;

            txt_NombreArea.Enabled = true;
            txt_NombreArea.Text = "";
            txt_IdArea.Text = "0";
            txt_NombreArea.Focus();
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

            txt_NombreArea.Enabled = true;
            txt_NombreArea.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Esta Seguro de eliminar este Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rpta = PR_aArea_CN.Instancia.Eliminar(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAdhesivo"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el Registro", "Eliminar registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (Verificar_Datos() == false) return;

            var datos = new PR_aArea()
            {
                IdArea = byte.Parse(txt_IdArea.Text),
                Nombre_Area = txt_NombreArea.Text,
            };

            if (bln_Nuevo) rpta = PR_aArea_CN.Instancia.Agregar(datos);
            if (bln_Editar) rpta = PR_aArea_CN.Instancia.Actualizar(datos);

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) { MessageBox.Show("Se agrego un nuevo Registro", "AGREGAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "ACTUALIZAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(false);
                txt_NombreArea.Enabled = false;

                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "ERROR AL INGRESAR", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Cargar_Datos();

        }

        private bool Verificar_Datos()
        {
            if (txt_NombreArea.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese al Nombre Area", "Ingreso de datos", MessageBoxButtons.OK);
                txt_NombreArea.Focus();
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
            txt_NombreArea.Enabled = false;
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            { PrintDocument.Print(); }
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

            var Listado_Ordenado = (from ordenar in PR_aArea_CN._Instancia.Lista_Areas().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in PR_aArea_CN._Instancia.Lista_Areas().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex--;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdArea"].Value.ToString()));
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex--;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdArea"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex++;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdArea"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdArea"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
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

            PrintDocument.DocumentName = "Reporte Adhesivo";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Tipo Areas", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Tipo Areas", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


    }
}
