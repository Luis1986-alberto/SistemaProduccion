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
    public partial class Frm_Etiquetadoras : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_Etiquetadoras()
        {
            InitializeComponent();
        }

        private void Frm_Etiquetadoras_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
            Cargar_Datos();
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idetiquetadora"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;
            List<PR_aEtiquetadoras> lista = PR_aEtiquetadoras_CN._Instancia.Lista_Etiquetadoras();
            SortableBindingList<PR_aEtiquetadoras> Lsta_etiquetadoras = new SortableBindingList<PR_aEtiquetadoras>(lista);

            dgv_Mnt.DataSource = Lsta_etiquetadoras;
        }

        private void Entrada_Datos(byte IdEtiquetadora)
        {
            var datos = PR_aEtiquetadoras_CN._Instancia.traerPorId(IdEtiquetadora);

            foreach (var i in datos)
            {
                txt_IdEtiquetadora.Text = i.IdEtiquetadora.ToString();
                txt_MarcaEtiquetadora.Text = i.Marca_Etiquetadora.ToString();
                txt_ModeloEtiquetadora.Text = i.Modelo_Etiquetadora.ToString();
                txt_CodigoEtiquetadora.Text = i.Codigo_Etiquetadora.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdEtiquetadora.Text = "0";
            txt_CodigoEtiquetadora.Text = "";
            txt_MarcaEtiquetadora.Text = "";
            txt_ModeloEtiquetadora.Text = "";

            txt_CodigoEtiquetadora.Enabled = true;
            txt_MarcaEtiquetadora.Enabled = true;
            txt_ModeloEtiquetadora.Enabled = true;
            Estado_Toolbar(true);
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = true;

            tbc_Mnt.SelectTab(0);

            txt_CodigoEtiquetadora.Enabled = true;
            txt_MarcaEtiquetadora.Enabled = true;
            txt_ModeloEtiquetadora.Enabled = true;
            Estado_Toolbar(true);
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = PR_aEtiquetadoras_CN._Instancia.Eliminar_Etiquetadora(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEtiquetadora"].Value.ToString()));
                if (rpta == "PROCESADO") MessageBox.Show("Se Elimino Con Exito", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(rpta, "No se Elimino", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (Verificar_Datos() == false) { return; }

            var datos = new PR_aEtiquetadoras()
            {
                IdEtiquetadora = byte.Parse(txt_IdEtiquetadora.Text),
                Codigo_Etiquetadora = txt_CodigoEtiquetadora.Text,
                Marca_Etiquetadora = txt_MarcaEtiquetadora.Text,
                Modelo_Etiquetadora = txt_ModeloEtiquetadora.Text,
            };

            if (bln_Nuevo) { rpta = PR_aEtiquetadoras_CN._Instancia.Agregar_Etiquetadora(datos); }
            if (bln_Editar) { rpta = PR_aEtiquetadoras_CN._Instancia.Actualizar_Etiquetadora(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) { MessageBox.Show("Se Agrego UN Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualiso un Registro", "Actualizacion Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show(rpta, "Informacion ", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            txt_CodigoEtiquetadora.Enabled = false;
            txt_MarcaEtiquetadora.Enabled = false;
            txt_ModeloEtiquetadora.Enabled = false;
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Estado_Toolbar(false);
            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            txt_CodigoEtiquetadora.Enabled = false;
            txt_MarcaEtiquetadora.Enabled = false;
            txt_ModeloEtiquetadora.Enabled = false;
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Estado_Toolbar(false);
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
            var Listado_Ordenado = (from etiquetadoras in PR_aEtiquetadoras_CN._Instancia.Lista_Etiquetadoras().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select etiquetadoras).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from etiquetadoras in PR_aEtiquetadoras_CN._Instancia.Lista_Etiquetadoras().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select etiquetadoras).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEtiquetadora"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEtiquetadora"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEtiquetadora"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEtiquetadora"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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

        private bool Verificar_Datos()
        {
            if (txt_MarcaEtiquetadora.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_MarcaEtiquetadora, "Ingrese Marca");
                return false;
            }
            if (txt_ModeloEtiquetadora.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_ModeloEtiquetadora, "Ingrese Modelo");
                return false;
            }
            if (txt_CodigoEtiquetadora.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_CodigoEtiquetadora, "Ingrese Codigo");
                return false;
            }
            return true;
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

            PrintDocument.DocumentName = "Reporte Etiquetadoras";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Etiquetadoras", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Etiquetadoras", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


    }
}
