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
    public partial class Frm_MarcaMaterial : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool Nuevo = false;
        private bool Editar = false;
        private string str_Campo;

        public Frm_MarcaMaterial()
        {
            InitializeComponent();
        }

        private void Frm_MarcaMaterial_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
            Cargar_Datos();
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMarcaMaterial"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;
            List<MP_aMarcaMaterial> Lista = MP_aMarcaMaterial_CN.Instancia.Listar_MarcaMaterial().ToList();
            SortableBindingList<MP_aMarcaMaterial> Lista_FamiliaProd = new SortableBindingList<MP_aMarcaMaterial>(Lista);
            dgv_Mnt.DataSource = Lista_FamiliaProd;
        }

        private void Entrada_Datos(Int32 id)
        {
            var datos = MP_aMarcaMaterial_CN.Instancia.TraerPorID(id);
            foreach (var i in datos)
            {
                txt_IdMarcaMaterial.Text = i.IdMarcaMaterial.ToString();
                txt_Descripcion_MarcaMaterial.Text = i.Descripcion;
                txt_Abreviatura_MarcaMaterial.Text = i.Abreviatura_MarcaMaterial.ToString();
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            Nuevo = true;
            Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(Nuevo);
            Habilitar_Controles(true);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdMarcaMaterial.Text = "0";
            txt_Abreviatura_MarcaMaterial.Text = "";
            txt_Descripcion_MarcaMaterial.Text = "";
            txt_Descripcion_MarcaMaterial.Focus();

        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Editar = true;
            Nuevo = false;

            Estado_Toolbar(Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);
            Habilitar_Controles(true);
            txt_Descripcion_MarcaMaterial.Focus();
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
                rpta = MP_aMarcaMaterial_CN._Instancia.Eliminar(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdmarcaMaterial"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new MP_aMarcaMaterial()
            {
                IdMarcaMaterial = Int32.Parse(txt_IdMarcaMaterial.Text),
                Descripcion = txt_Descripcion_MarcaMaterial.Text,
                Abreviatura_MarcaMaterial = txt_Abreviatura_MarcaMaterial.Text
            };

            if (Verificar_Datos() == false) { return; }

            if (Nuevo) { rpta = MP_aMarcaMaterial_CN._Instancia.Agregar(datos); }
            if (Editar) { rpta = MP_aMarcaMaterial_CN._Instancia.Actualizar(datos); }

            if (rpta == "PROCESADO")
            {
                if (Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                Editar = false;
                Nuevo = false;

                Estado_Toolbar(Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                Habilitar_Controles(false);
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            Editar = false;
            Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Habilitar_Controles(false);
            Estado_Toolbar(false);
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

            var Listado_Ordenado = (from Ordenar in MP_aMarcaMaterial_CN._Instancia.Listar_MarcaMaterial().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Ordenar in MP_aMarcaMaterial_CN._Instancia.Listar_MarcaMaterial().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMarcaMaterial"].Value.ToString()));
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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMarcaMaterial"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex++;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMarcaMaterial"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMarcaMaterial"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void Habilitar_Controles(Boolean vEnabled)
        {
            txt_Abreviatura_MarcaMaterial.Enabled = vEnabled;
            txt_Descripcion_MarcaMaterial.Enabled = vEnabled;
        }


        private bool Verificar_Datos()
        {
            if (txt_Descripcion_MarcaMaterial.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_Descripcion_MarcaMaterial, "Ingrese Marca Material");
                return false;
            }

            if (txt_Abreviatura_MarcaMaterial.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Faltan Alfunos Datos", "Mensaje Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorIcono.SetError(txt_Abreviatura_MarcaMaterial, "Ingrese Abreviatura");
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

            PrintDocument.DocumentName = "Reporte MarcaMaterial";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Marca Material", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Marca Material", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
