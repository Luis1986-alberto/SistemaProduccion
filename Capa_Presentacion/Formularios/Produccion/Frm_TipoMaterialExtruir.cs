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
    public partial class Frm_TipoMaterialExtruir : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Editar, bln_Nuevo = false;
        private string str_Campo;

        public Frm_TipoMaterialExtruir()
        {
            InitializeComponent();
        }

        private void Frm_TipoMaterialExtruir_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);

            dgv_Mnt.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;

        }
        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { return; }

            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            tbc_Mnt.SelectTab(1);
            dgv_Mnt.AutoGenerateColumns = false;

            List<PR_aTipoMaterialExtruir> Listado = PR_aTipoMaterialExtruir_CN._Instancia.Lista_TipoMaterialExtruir();

            SortableBindingList<PR_aTipoMaterialExtruir> lst_TipoMaterialExtr = new SortableBindingList<PR_aTipoMaterialExtruir>(Listado);

            dgv_Mnt.DataSource = lst_TipoMaterialExtr;

            dgv_Mnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void Entrada_Datos(byte id)
        {
            var result = PR_aTipoMaterialExtruir_CN.Instancia.TraerPorID(id);

            foreach (var i in result)
            {
                txt_IdTipoMaterialExtruir.Text = i.IdTipoMaterialExtruir.ToString();
                txt_Descripcion.Text = i.Descripcion_MaterialExtruir.ToString();
                txt_Abreviatura.Text = i.Abreviatura.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdTipoMaterialExtruir.Text = "0";
            txt_Descripcion.Text = "";
            txt_Descripcion.Enabled = true;
            txt_Abreviatura.Enabled = true;
            txt_Descripcion.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = true;

            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Descripcion.Enabled = true;
            txt_Abreviatura.Enabled = true;
            txt_Descripcion.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar", " ELIMINAR REGISTRO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = PR_aTipoMaterialExtruir_CN.Instancia.Eliminar_TipoLaminacion(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino un registro", "ELIMINAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "ERROR INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();

        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aTipoMaterialExtruir()
            {
                IdTipoMaterialExtruir = byte.Parse(txt_IdTipoMaterialExtruir.Text),
                Descripcion_MaterialExtruir = txt_Descripcion.Text,
                Abreviatura = txt_Abreviatura.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aTipoMaterialExtruir_CN._Instancia.Agregar_TipoMaterialExtruir(datos); }
            if (bln_Editar) { rpta = PR_aTipoMaterialExtruir_CN._Instancia.Actualizar_TipoMaterialExtruir(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                txt_Abreviatura.Enabled = false;
                txt_Descripcion.Enabled = false;
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            txt_Abreviatura.Enabled = false;
            txt_Descripcion.Enabled = false;
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

            var Listado_Ordenado = (from ordenar in PR_aTipoMaterialExtruir_CN._Instancia.Lista_TipoMaterialExtruir().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in PR_aTipoMaterialExtruir_CN._Instancia.Lista_TipoMaterialExtruir().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex++;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdTipoMaterialExtruir"].Value.ToString()));

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
            if (txt_Descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la descripcion del tipo Material", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Descripcion.Focus();
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

            PrintDocument.DocumentName = "Reporte Tipo Material Extruir";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Tipo Material Extruir", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Tipo Material Extruir", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }



    }
}
