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
    public partial class Frm_TipoProducto : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_TipoProducto()
        {
            InitializeComponent();
        }

        private void Frm_TipoProducto_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString())); }
        }
        private void Cargar_Datos()
        {
            List<PR_aTipoProducto> Listado = PR_aTipoProducto_CN._Instancia.Lista_TipoProducto();

            SortableBindingList<PR_aTipoProducto> ListadoProd = new SortableBindingList<PR_aTipoProducto>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = ListadoProd;
        }

        private void Entrada_Datos(byte idtipoproducto)
        {
            var result = PR_aTipoProducto_CN._Instancia.TraerPorID(idtipoproducto);
            foreach (var i in result)
            {
                txt_IdTipoProducto.Text = i.IdTipoProducto.ToString();
                txt_nombretipoproducto.Text = i.Nombre_TipoProducto.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdTipoProducto.Text = "0";
            txt_nombretipoproducto.Text = "";
            txt_nombretipoproducto.Enabled = true;
            txt_nombretipoproducto.Focus();
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

            txt_nombretipoproducto.Enabled = true;
            txt_nombretipoproducto.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("Esta Seguro Eliminar el Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rpta = PR_aTipoProducto_CN._Instancia.Eliminar_TipoProducto(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aTipoProducto()
            {
                IdTipoProducto = byte.Parse(txt_IdTipoProducto.Text),
                Nombre_TipoProducto = txt_nombretipoproducto.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aTipoProducto_CN._Instancia.Agregar_TipoProducto(datos); }
            if (bln_Editar) { rpta = PR_aTipoProducto_CN._Instancia.Actualizar_TipoProducto(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                txt_nombretipoproducto.Enabled = false;
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado"); }

            Cargar_Datos();
        }

        private bool Verificar_Datos()
        {
            if (txt_nombretipoproducto.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el tipo de impresion", "Ingreso de datos", MessageBoxButtons.OK);
                txt_nombretipoproducto.Focus();
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
            txt_nombretipoproducto.Enabled = false;
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

            var Listado_Ordenado = (from tipoproducto in PR_aTipoProducto_CN._Instancia.Lista_TipoProducto().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select tipoproducto).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from tipoproducto in PR_aTipoProducto_CN._Instancia.Lista_TipoProducto().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select tipoproducto).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["idtipoproducto"].Value.ToString()));

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

            PrintDocument.DocumentName = "Reporte TipoProduccion";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Tipo Producto", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Tipo Producto", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


    }
}
