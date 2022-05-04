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
    public partial class Frm_EspesorTuco : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_EspesorTuco()
        {
            InitializeComponent();
        }

        private void Frm_EspesorTuco_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cbo_UnidadMedida.DataSource = PR_aUnidadMedidas_CN.Instancia.Lista_UnidadMedida();
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString())); }
        }


        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;
            List<PR_aEspesorTuco> Lista = PR_aEspesorTuco_CN.Instancia.Lista_EspesorTuco();
            SortableBindingList<PR_aEspesorTuco> lst_espesor = new SortableBindingList<PR_aEspesorTuco>(Lista);

            dgv_Mnt.DataSource = lst_espesor;
        }

        private void Entrada_Datos(byte id)
        {
            var datos = PR_aEspesorTuco_CN._Instancia.TraerPorID(id);
            foreach (var i in datos)
            {
                txt_IdEspesorTuco.Text = i.IdEspesorTuco.ToString();
                Nud_EspesorTuco.Value = i.Medida_EspesorTuco;
                Cbo_UnidadMedida.SelectedValue = i.IdUnidadEspesorTuco;
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;
            tbc_Mnt.SelectTab(0);
            txt_IdEspesorTuco.Text = "0";
            Nud_EspesorTuco.Enabled = true;
            Nud_EspesorTuco.Value = decimal.Parse("0.00");
            Cbo_UnidadMedida.Enabled = true;
            Estado_Toolbar(bln_Nuevo);
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Editar = true;
            bln_Nuevo = false;
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);
            Nud_EspesorTuco.Enabled = true;
            Cbo_UnidadMedida.Enabled = true;
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta Seguro que desea eliminar", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                string rpta = PR_aEspesorTuco_CN._Instancia.Eliminar_EspesorTuco(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino con Exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aEspesorTuco
                                            {
                                                IdEspesorTuco = byte.Parse(txt_IdEspesorTuco.Text),
                                                Medida_EspesorTuco = decimal.Parse(Nud_EspesorTuco.Value.ToString()),
                                                IdUnidadEspesorTuco = byte.Parse(Cbo_UnidadMedida.SelectedValue.ToString()),
                                            };
            if (bln_Nuevo) {  rpta = PR_aEspesorTuco_CN._Instancia.Agregar_EspesorTuco(datos); }
            if (bln_Editar) { rpta = PR_aEspesorTuco_CN._Instancia.Actualizar_EspesorTuco(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) { MessageBox.Show("Se agrego un nuevo Registro", "AGREGAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "ACTUALIZAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(false);
                Nud_EspesorTuco.Enabled = false;
                Cbo_UnidadMedida.Enabled = false;

                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "ERROR AL INGRESAR", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Nud_EspesorTuco.Enabled = false;
            Cbo_UnidadMedida.Enabled = false;
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

            var Listado_Ordenado = (from ordenar in PR_aEspesorTuco_CN._Instancia.Lista_EspesorTuco().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in PR_aEspesorTuco_CN._Instancia.Lista_EspesorTuco().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) =>  Cargar_Datos(); 

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex--;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString()));
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex--;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex++;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEspesorTuco"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
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

            PrintDocument.DocumentName = "Reporte Espesor";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Espesor Tucos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Espesor Tuco", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void cmd_unidadmedida_Click(object sender, EventArgs e)
        {
            Frm_UnidadMedida unidadmedida = new Frm_UnidadMedida();
            unidadmedida.ShowDialog();
            Cbo_UnidadMedida.DataSource = PR_aUnidadMedidas_CN.Instancia.Lista_UnidadMedida();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
    }
}
