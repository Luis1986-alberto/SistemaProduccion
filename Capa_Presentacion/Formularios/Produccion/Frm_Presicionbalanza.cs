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
    public partial class Frm_Presicionbalanza : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool Nuevo = false;
        private bool Editar = false;
        private string str_Campo;

        public Frm_Presicionbalanza()
        {
            InitializeComponent();
        }

        private void Frm_Presicionbalanza_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);

            dgv_Mnt.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { return; }

            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;

            List<PR_aPrecisionBalanza> Listado = PR_aPrecisionBalanza_CN._Instancia.Lista_PresicionBalanza();
            SortableBindingList<PR_aPrecisionBalanza> ListadoCarreta = new SortableBindingList<PR_aPrecisionBalanza>(Listado);

            dgv_Mnt.DataSource = ListadoCarreta;
            dgv_Mnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Entrada_Datos(byte vidcarreta)
        {
            var Repositorio = PR_aCarreta_CN._Instancia.TraerID(vidcarreta);

            foreach (var Registro in Repositorio)
            {
                txt_IdPresicionbalanza.Text = Registro.IdCarreta.ToString();
                Nud_Precision_Balanza.Text = Registro.Pesos_Kilos.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            Nuevo = true;
            Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdPresicionbalanza.Text = "0";
            Nud_Precision_Balanza.Value = 0;

            Nud_Precision_Balanza.Enabled = true;
            Nud_Precision_Balanza.Focus();

        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            Nuevo = false;
            Editar = true;
            tbc_Mnt.SelectTab(0);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            Nud_Precision_Balanza.Enabled = true;
            Estado_Toolbar(true);
            Nud_Precision_Balanza.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { MessageBox.Show("No existe Registros a Eliminar", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            if (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = PR_aPrecisionBalanza_CN._Instancia.Eliminar_PresicionBalanza(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString()));

                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el Registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (Verificar_Datos() == false) { return; }

            var datos = new PR_aPrecisionBalanza()
            {
                IdPrecisionBalanza = byte.Parse(txt_IdPresicionbalanza.Text),
                Precision_Balanza = Nud_Precision_Balanza.Value,
            };

            if (Nuevo) rpta = PR_aPrecisionBalanza_CN._Instancia.Agregar_PresicionBalanza(datos);
            if (Editar) rpta = PR_aPrecisionBalanza_CN._Instancia.Actualizar_PresicionBalanza(datos);

            if (rpta == "PROCESADO")
            {
                if (Nuevo) { MessageBox.Show("Se Agrego un Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "Actualizacion registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show(rpta, "Error al Procesar", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            Nud_Precision_Balanza.Enabled = false;
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Estado_Toolbar(false);
            Cargar_Datos();
        }

        private bool Verificar_Datos()
        {
            if (Nud_Precision_Balanza.Value == 0)
            {
                MessageBox.Show("Ingrese el Nombre Estado", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(Nud_Precision_Balanza, "Ingrese Presicion Balanza ");
                return false;
            }

            return true;
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            Editar = false;
            Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Nud_Precision_Balanza.Enabled = false;
            Estado_Toolbar(Editar);
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
            var Listado_Ordenado = (from ordenar in PR_aPrecisionBalanza_CN._Instancia.Lista_PresicionBalanza().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from ordenar in PR_aPrecisionBalanza_CN._Instancia.Lista_PresicionBalanza().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdPrecisionBalanza"].Value.ToString()));

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

            PrintDocument.DocumentName = "Reporte Procesos";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Presicion Balanza ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Presicion Balanza ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

    }
}
