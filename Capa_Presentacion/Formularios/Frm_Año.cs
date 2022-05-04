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
    public partial class Frm_Año : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_OutPutId;
        private string str_Mensaje;
        private string str_Campo;

        public Frm_Año()
        {
            InitializeComponent();
        }

        private void Frm_Año_Load(object sender, EventArgs e)
        {
            Carga_Datos();
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);

            dgv_Mnt.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;
        }

        private void Carga_Datos()
        {

            List<PR_aAño> Listado = PR_aAño_CN._Instancia.Lista_Años();

            SortableBindingList<PR_aAño> ListadoAños = new SortableBindingList<PR_aAño>(Listado);

            dgv_Mnt.DataSource = ListadoAños;

            dgv_Mnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { return; }

            if (!bln_Editar)  { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));}
        }

        private void Entrada_Datos(byte vIdAño)
        {
            var Repositorio = PR_aAño_CN._Instancia.TraerID(vIdAño);

            foreach (var Registro in Repositorio)
            {
                txt_IdAño.Text = Registro.IdAño.ToString();
                txt_Año.Text = Registro.Año.ToString();
            }
        }
        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);

            HabilitarControles(true);
            LimpiarControles();
            Estado_Toolbar(bln_Nuevo);

            txt_IdAño.Enabled = true;
            txt_Año.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount > 0)
            {
                bln_Editar = true;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);

                tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
                tbc_Mnt.SelectTab(0);

                HabilitarControles(true);

                txt_Año.Focus();
            }
            else
            {MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}

        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Mnt.RowCount > 0)
                {
                    tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
                    tbc_Mnt.SelectTab(0);

                    if (MessageBox.Show("Esta seguro de eliminar el registro ?", "Ventana de eliminación de registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        str_OutPutId = PR_aAño_CN._Instancia.Eliminar_Año(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));

                        Carga_Datos();

                        tbc_Mnt.SelectTab(1);
                        tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                    }
                    else
                    {
                        tbc_Mnt.SelectTab(1);
                        tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros para eliminar", "Ventana de eliminación de registro", MessageBoxButtons.OK);
                    tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Carga_Datos();
            }
        }
        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            try
            {
                var Datos = new PR_aAño
                {
                    IdAño = byte.Parse(txt_IdAño.Text),
                    Año = Int32.Parse(txt_Año.Text.ToUpper().Trim()),
                };

                if (Verificar_Datos() == false) { return; }

                if (bln_Nuevo) { str_Mensaje = PR_aAño_CN._Instancia.Agregar_Año(Datos); }
                if (bln_Editar) { str_Mensaje = PR_aAño_CN._Instancia.Actualizar_Año(Datos); }

                if (str_Mensaje == "PROCESADO")
                {
                    if (bln_Nuevo) 
                    {MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
                    else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                    bln_Editar = false;
                    bln_Nuevo = false;

                    Estado_Toolbar(bln_Editar);

                    tbc_Mnt.SelectTab(1);
                    tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;

                    HabilitarControles(false);
                    Carga_Datos();

                    dgv_Mnt.ClearSelection();

                    
                }
                else
                {
                    MessageBox.Show(str_Mensaje, "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Carga_Datos();
            }
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            HabilitarControles(false);
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

        private void tls_Refrescar_Click(object sender, EventArgs e)
        {
            Carga_Datos();
        }

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAño"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Años in PR_aAño_CN._Instancia.Lista_Años().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Años).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Años in PR_aAño_CN._Instancia.Lista_Años().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Años).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();

            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
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
        private void HabilitarControles(Boolean vEnabled)
        {
            txt_Año.Enabled = vEnabled;
        }

        private void LimpiarControles()
        {
            txt_Año.Text = "";
            txt_IdAño.Text = "0";
        }

        private bool Verificar_Datos()
        {
            if (txt_Año.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el año", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Año.Focus();
                return false;
            }

            return true;
        }
        private void dgv_Mnt_DoubleClick(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(0);
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

            PrintDocument.DocumentName = "Reporte Años";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Años", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Años", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void txt_Año_Enter(object sender, EventArgs e)
        {
            txt_Año.BackColor = Color.Cornsilk;
        }

        private void txt_Año_Leave(object sender, EventArgs e)
        {
            txt_Año.BackColor = Color.White;
        }

    }
}
