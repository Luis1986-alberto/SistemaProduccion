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
    public partial class Frm_TipoMaterialLaminado : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Editar, bln_Nuevo = false;
        private string str_Campo;

        public Frm_TipoMaterialLaminado()
        {
            InitializeComponent();
        }

        private void Frm_TipoMaterialLaminado_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);

            dgv_Mnt.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;

            List<PR_aTipoMaterialLaminado> Listado = PR_aTipoMaterialLaminado_CN._Instancia.Lista_TipoMaterialLaminado();

            SortableBindingList<PR_aTipoMaterialLaminado> ListadoMatLaminado = new SortableBindingList<PR_aTipoMaterialLaminado>(Listado);

            dgv_Mnt.DataSource = ListadoMatLaminado;

            dgv_Mnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { return; }

            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString())); }
        }

        private void Entrada_Datos(byte id)
        {
            var result = PR_aTipoMaterialLaminado_CN.Instancia.TraerPorID(id);
            foreach (var i in result)
            {
                txt_IdTipoLaminacion.Text = i.IdTipoMaterialLaminado.ToString();
                txt_TipoLaminacion.Text = i.Descripcion.ToString();
                txt_Abreviatura.Text = i.Abreviatura.ToString();
                txt_OrdenGerencia.Text = i.Orden_Gerencia.ToString();
                txt_GramajeLineal.Text = i.Gramaje_Lineal.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);

            txt_Abreviatura.Enabled = true;
            txt_GramajeLineal.Enabled = true;
            txt_OrdenGerencia.Enabled = true;
            txt_TipoLaminacion.Enabled = true;
            txt_IdTipoLaminacion.Text = "0";
            txt_TipoLaminacion.Text = "";
            txt_OrdenGerencia.Text = "0";
            txt_GramajeLineal.Text = "000.000";

            Estado_Toolbar(bln_Nuevo);
            txt_TipoLaminacion.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = true;

            tbc_Mnt.SelectTab(0);

            txt_Abreviatura.Enabled = true;
            txt_GramajeLineal.Enabled = true;
            txt_OrdenGerencia.Enabled = true;
            txt_TipoLaminacion.Enabled = true;

            Estado_Toolbar(bln_Editar);
            txt_TipoLaminacion.Focus();
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
                rpta = PR_aTipoMaterialLaminado_CN._Instancia.Eliminar_TipoMaterialLaminado(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aTipoMaterialLaminado()
            {
                IdTipoMaterialLaminado = byte.Parse(txt_IdTipoLaminacion.Text),
                Orden_Gerencia = byte.Parse(txt_OrdenGerencia.Text),
                Abreviatura = txt_Abreviatura.Text,
                Gramaje_Lineal = decimal.Parse(txt_GramajeLineal.Text),
                Descripcion = txt_TipoLaminacion.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aTipoMaterialLaminado_CN._Instancia.Agregar_TipoMaterialLaminado(datos); }
            if (bln_Editar) { rpta = PR_aTipoMaterialLaminado_CN._Instancia.Actualizar_TipoMaterialLaminado(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                txt_TipoLaminacion.Enabled = false;
                txt_OrdenGerencia.Enabled = false;
                txt_GramajeLineal.Enabled = false;
                txt_Abreviatura.Enabled = false;
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            txt_TipoLaminacion.Enabled = false;
            txt_OrdenGerencia.Enabled = false;
            txt_GramajeLineal.Enabled = false;
            txt_Abreviatura.Enabled = false;
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

            var Listado_Ordenado = (from Años in PR_aTipoMaterialLaminado_CN._Instancia.Lista_TipoMaterialLaminado().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Años).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in PR_aTipoMaterialLaminado_CN._Instancia.Lista_TipoMaterialLaminado().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e)
        { Cargar_Datos(); }

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex--;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex++;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialLaminado"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }
        private bool Verificar_Datos()
        {
            if (txt_TipoLaminacion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese eltipo Laminado", "Ingreso de datos", MessageBoxButtons.OK);
                txt_TipoLaminacion.Focus();
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

        private void txt_OrdenGerencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_Campos.SoloNumeros(e);
        }

        private void txt_GramajeLineal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar_Campos.NumerosDecimales(e);
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

            PrintDocument.DocumentName = "Reporte Material Laminado";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Materiales para Laminado", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Materiales para Laminado", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
