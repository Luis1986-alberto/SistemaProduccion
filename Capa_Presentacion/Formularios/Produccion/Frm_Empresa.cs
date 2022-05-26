using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_Empresa : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_Empresa()
        {
            InitializeComponent();
        }

        private void Frm_Empresa_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString())); }
        }
        private void Cargar_Datos()
        {
            List<PR_aEmpresa> Listado = PR_aEmpresa_CN._Instancia.Lista_Empresas();

            SortableBindingList<PR_aEmpresa> ListadoMes = new SortableBindingList<PR_aEmpresa>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = ListadoMes;
        }

        private void Entrada_Datos(byte idempresa)
        {
            var result = PR_aEmpresa_CN._Instancia.TraerPorID(idempresa);
            foreach (var i in result)
            {
                txt_IdEmpresa.Text = i.IdEmpresa.ToString();
                txt_Nombre_Empresa.Text = i.Nombre_Empresa;
                chk_Activo.Checked = (i.Flag_Activo == 1) ? true : false;
                txt_Ruc_Empresa.Text = i.RUC_Empresa;
                txt_SiglaEmpresa.Text = i.Abreviatura_Empresa;
                txt_DireccionEmpresa.Text = i.Direccion_Empresa;
                txt_telefono1.Text = i.Telefono1_Empresa;
                txt_telefono2.Text = i.Telefono2_Empresa;
                txt_telefono3.Text = i.Telefono3_Empresa;
                Txt_DireccionImagen.Text = i.Ruta_Foto_Empresa;
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            HabilitarControles(true);
            LimpiarControles();

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

            HabilitarControles(true);

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
                rpta = PR_aEmpresa_CN._Instancia.Eliminar_Empresa(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aEmpresa()
            {
                IdEmpresa = byte.Parse(txt_IdEmpresa.Text),
                Nombre_Empresa = txt_Nombre_Empresa.Text,
                Flag_Activo = byte.Parse(chk_Activo.Checked == true ? "1" : "0"),
                RUC_Empresa = txt_Ruc_Empresa.Text,
                Abreviatura_Empresa = txt_SiglaEmpresa.Text,
                Direccion_Empresa = txt_DireccionEmpresa.Text,
                Telefono1_Empresa = txt_telefono1.Text,
                Telefono2_Empresa = txt_telefono2.Text,
                Telefono3_Empresa = txt_telefono3.Text,
                Ruta_Foto_Empresa = Txt_DireccionImagen.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aEmpresa_CN._Instancia.Agregar_Empresa(datos, Img_foto); }
            if (bln_Editar) { rpta = PR_aEmpresa_CN._Instancia.Actualizar_Empresa(datos, Img_foto); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                HabilitarControles(false);
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "error Inesperado"); }

            Cargar_Datos();

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

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();

            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Años in PR_aEmpresa_CN._Instancia.Lista_Empresas().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Años).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from Años in PR_aEmpresa_CN._Instancia.Lista_Empresas().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select Años).ToList();

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString()));

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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdEmpresa"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }


        private void HabilitarControles(Boolean vEnabled)
        {
            txt_Nombre_Empresa.Enabled = vEnabled;
            txt_DireccionEmpresa.Enabled = vEnabled;
            chk_Activo.Enabled = vEnabled;
            txt_Ruc_Empresa.Enabled = vEnabled;
            txt_SiglaEmpresa.Enabled = vEnabled;
            txt_telefono1.Enabled = vEnabled;
            txt_telefono2.Enabled = vEnabled;
            txt_telefono3.Enabled = vEnabled;

        }

        private void LimpiarControles()
        {
            txt_IdEmpresa.Text = "0";
            txt_Nombre_Empresa.Text = "";
            txt_DireccionEmpresa.Text = "";
            chk_Activo.Checked = false;
            txt_Ruc_Empresa.Text = "";
            txt_SiglaEmpresa.Text = "";
            txt_telefono1.Text = "";
            txt_telefono2.Text = "";
            txt_telefono3.Text = "";
            Txt_DireccionImagen.Text = "";
        }

        private bool Verificar_Datos()
        {
            if (txt_Nombre_Empresa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre Empresa", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Nombre_Empresa.Focus();
                return false;
            }

            if (txt_Ruc_Empresa.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el RUC Empresa", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Ruc_Empresa.Focus();
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

            PrintDocument.DocumentName = "Reporte Empresas";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Empresa", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Empresa", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_foto.ImageLocation = getImagen.FileName;
                Txt_DireccionImagen.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnLimpiarImagen_Click(object sender, EventArgs e)
        {
            Img_foto.Image = null;
            Txt_DireccionImagen.Text = "";
        }

        private void Chk_MostrarImagen_CheckedChanged(object sender, EventArgs e)
        { Descargar_Imagen(); }
        private void Descargar_Imagen()
        {
            if (bln_Nuevo == false)
            {
                Img_foto.Image = null;
                if (Txt_DireccionImagen.Text == "") { return; }
                if (Chk_MostrarImagen.Checked == true)
                { PR_aEmpresa_CN._Instancia.Descargar_Imagen(Img_foto, Int32.Parse(txt_IdEmpresa.Text)); }
            }
        }


    }
}
