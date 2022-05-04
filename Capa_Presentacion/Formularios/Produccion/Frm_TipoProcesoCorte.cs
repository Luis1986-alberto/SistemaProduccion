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
    public partial class Frm_TipoProcesoCorte : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool Nuevo, editar = false;
        private string str_Campo;

        public Frm_TipoProcesoCorte()
        {
            InitializeComponent();
        }

        private void Frm_TipoProcesoCorte_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
            Cargar_Datos();
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
                Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;

            List<PR_aTipoProcesoCorte> Lista = PR_aTipoProcesoCorte_CN.Instancia.Lista_TipoProcesoCorte();
            SortableBindingList<PR_aTipoProcesoCorte> Lista_Corte = new SortableBindingList<PR_aTipoProcesoCorte>(Lista);
            dgv_Mnt.DataSource = Lista_Corte;
        }

        private void Entrada_Datos(byte id)
        {
            var datos = PR_aTipoProcesoCorte_CN.Instancia.TraerPorID(id);
            foreach (var i in datos)
            {
                txt_IdTipoProcesoCorte.Text = i.IdTipoProcesoCorte.ToString();
                txt_Nombre_TipoProcesoCorte.Text = i.Nombre_TipoProcesoCorte.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            Nuevo = true;
            editar = false;
            tbc_Mnt.SelectTab(0);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Nombre_TipoProcesoCorte.Enabled = true;
            Estado_Toolbar(Nuevo);

            txt_IdTipoProcesoCorte.Text = "0";
            txt_Nombre_TipoProcesoCorte.Text = "";
            txt_Nombre_TipoProcesoCorte.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            Nuevo = false;
            editar = true;
            tbc_Mnt.SelectTab(0);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Nombre_TipoProcesoCorte.Enabled = true;
            Estado_Toolbar(true);
            txt_Nombre_TipoProcesoCorte.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { MessageBox.Show("No existe Registros a Eliminar", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            if (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = PR_aTipoProcesoCorte_CN._Instancia.Eliminar_TipoProcesoCorte(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));

                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el Registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (verificardatos() == false) { return; }

            var datos = new PR_aTipoProcesoCorte()
            {
                IdTipoProcesoCorte = byte.Parse(txt_IdTipoProcesoCorte.Text),
                Nombre_TipoProcesoCorte = txt_Nombre_TipoProcesoCorte.Text,
            };

            if (Nuevo) rpta = PR_aTipoProcesoCorte_CN._Instancia.Agregar_TipoProcesoCorte(datos);
            if (editar) rpta = PR_aTipoProcesoCorte_CN._Instancia.Actualizar_TipoProcesoCorte(datos);

            if (rpta == "PROCESADO")
            {
                if (Nuevo) { MessageBox.Show("Se Agrego un Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "Actualizacion registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show(rpta, "Error al Procesar", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            txt_Nombre_TipoProcesoCorte.Enabled = false;
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Estado_Toolbar(false);
            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            Nuevo = false;
            editar = true;
            tbc_Mnt.SelectTab(0);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Nombre_TipoProcesoCorte.Enabled = true;
            Estado_Toolbar(Nuevo);

            txt_IdTipoProcesoCorte.Text = "0";
            txt_Nombre_TipoProcesoCorte.Focus();
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
            var Listado_Ordenado = (from ordenar in PR_aTipoProcesoCorte_CN._Instancia.Lista_TipoProcesoCorte().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from ordenar in PR_aTipoProcesoCorte_CN._Instancia.Lista_TipoProcesoCorte().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoProcesoCorte"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool verificardatos()
        {
            if (txt_Nombre_TipoProcesoCorte.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_Nombre_TipoProcesoCorte, "Ingrese Estado Formulacion");
                return false;
            }
            return true;
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

            PrintDocument.DocumentName = "Reporte Estado Maquina";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Tipo Proceso Corte ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Tipo Proceso Corte ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }






    }
}
