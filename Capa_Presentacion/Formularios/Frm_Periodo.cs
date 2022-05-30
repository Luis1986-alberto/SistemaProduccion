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
    public partial class Frm_Periodo : Form
    {
        private bool bln_Nuevo;
        DataGridViewPrinter dgr_Visor_Grilla;
        public List<LG_xPeriodo> lst_Periodo = new List<LG_xPeriodo>();


        public Frm_Periodo()
        {
            InitializeComponent();
        }

        private void Frm_Periodo_Load(object sender, EventArgs e)
        {
            tbc_mnt.SelectTab(1);

            tbc_mnt.Selecting += new TabControlCancelEventHandler(tbc_mnt_Selecting);
            cbo_años.DataSource = LG_aAño_CN._Instancia.Lista_Años();
            cbo_NombreMes.DataSource = LG_aMes_CN._Instancia.Lista_Mes();
            Cargar_Datos();
        }

        private void tbc_mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (Dgv_Mnt.SelectedRows.Count > 0)
            {
                Entrada_Datos(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].Value.ToString()));
            }
        }

        private void Cargar_Datos()
        {
            Dgv_Mnt.AutoGenerateColumns = false;
            lst_Periodo = LG_xPeriodo_CN.Instancia.Lista_Periodo();

            SortableBindingList<LG_xPeriodo> Lista = new SortableBindingList<LG_xPeriodo>(lst_Periodo);
            Dgv_Mnt.DataSource = Lista;
        }

        private void Entrada_Datos(Int32 idperiodo)
        {
            var result = LG_xPeriodo_CN.Instancia.TraerPorID(idperiodo);
            txt_IdPeriodo.Text = result.IdPeriodo.ToString();
            txt_Periodo.Text = result.Nombre_Periodo;
            cbo_años.SelectedValue = result.IdAño;
            cbo_NombreMes.SelectedValue = result.IdMes;
            Chk_Flagcerrado.Checked = (result.Flag_Cerrado == 1) ? true : false;
            dtp_FechaInicio.Value = result.Fecha_Inicio;
            dtp_FechaFinal.Value = result.Fecha_Final;
        }


        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            HabilitarControles(true);
            LimpiarControles();

            tbc_mnt.SelectTab(0);
            Estado_Toolbar(true);
            tbc_mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Periodo.Focus();
            txt_IdPeriodo.Text = "0";
        }

        private void HabilitarControles(Boolean vestado)
        {
            txt_Periodo.Enabled = vestado;
            cbo_años.Enabled = vestado;
            cbo_NombreMes.Enabled = vestado;
            Chk_Flagcerrado.Enabled = vestado;
            dtp_FechaInicio.Enabled = vestado;
            dtp_FechaFinal.Enabled = vestado;
        }

        private void LimpiarControles()
        {
            txt_Periodo.Text = "";
            Chk_Flagcerrado.Checked = false;
            dtp_FechaInicio.Value = DateTime.Now;
            dtp_FechaFinal.Value = DateTime.Now;
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

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            txt_IdPeriodo.Text = "0";
            Estado_Toolbar(true);
            HabilitarControles(true);
            tbc_mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_Periodo.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) return;
            if (MessageBox.Show("Esta Seguro que desea eliminar el registro", "ELIMINAR REGISTRO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = LG_xPeriodo_CN._Instancia.Eliminar_Periodo(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].ToString()));

                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el registro", "ELIMINAR REGISTRO", MessageBoxButtons.OK); }
                else { MessageBox.Show(rpta, "ERROR ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                Cargar_Datos();
                tbc_mnt.SelectTab(1);
                tbc_mnt.TabPages["tbp_Listado"].Enabled = true;
            }
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta;
            var datos = new LG_xPeriodo()
            {
                IdPeriodo = Int32.Parse(txt_IdPeriodo.Text),
                Nombre_Periodo = txt_Periodo.Text,
                IdAño = int.Parse(cbo_años.SelectedValue.ToString()),
                IdMes = byte.Parse(cbo_NombreMes.SelectedValue.ToString()),
                Flag_Cerrado = byte.Parse((Chk_Flagcerrado.Checked == true) ? "1" : "0"),
                Fecha_Inicio = DateTime.Parse(dtp_FechaInicio.Value.ToShortDateString()),
                Fecha_Final = DateTime.Parse(dtp_FechaFinal.Value.ToShortDateString()),
            };

            if (bln_Nuevo) rpta = LG_xPeriodo_CN._Instancia.Agregar_Periodo(datos);
            else rpta = LG_xPeriodo_CN._Instancia.Actualizar_Periodo(datos);

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) { MessageBox.Show("Se Agrego Nuevo Registro", "AGREGAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "ACTUALIZA REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show(rpta, "ERROR AL INESPERADO", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            Cargar_Datos();
            HabilitarControles(false);
            Estado_Toolbar(false);
            tbc_mnt.SelectTab(1);
            tbc_mnt.TabPages["tbp_Listado"].Enabled = true;
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            HabilitarControles(false);
            Estado_Toolbar(false);
            tbc_mnt.SelectTab(1);
            tbc_mnt.TabPages["tbp_Listado"].Enabled = true;
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void tls_Previo_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = PrintDocument;
                (MyPrintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref Dgv_Mnt, Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            string campo = Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_ordenada = (from ordenar in lst_Periodo.OrderBy(r => r.GetType().GetProperty(campo).GetValue(r, null)) select ordenar).ToList();
            Dgv_Mnt.DataSource = lista_ordenada;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            string campo = Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_ordenada = (from ordenar in lst_Periodo.OrderByDescending(r => r.GetType().GetProperty(campo).GetValue(r, null)) select ordenar).ToList();
            Dgv_Mnt.DataSource = lista_ordenada;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) return;

            Dgv_Mnt.ClearSelection();
            Entrada_Datos(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].Value.ToString()));

            Dgv_Mnt.FirstDisplayedScrollingRowIndex = Dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) return;

            int SelectIndex = Dgv_Mnt.SelectedRows[0].Index;
            if (SelectIndex == 0) { return; }
            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;

            Entrada_Datos(int.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = Dgv_Mnt.SelectedRows[0].Index;
            if (Dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;
            Entrada_Datos(int.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) { return; }

            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[Dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(int.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdPeriodo"].Value.ToString()));
            Dgv_Mnt.FirstDisplayedScrollingRowIndex = Dgv_Mnt.SelectedRows[0].Index;
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

            PrintDocument.DocumentName = "Lista de Periodos";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(Dgv_Mnt, PrintDocument, true, true, "Listado de Periodos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(Dgv_Mnt, PrintDocument, false, true, "Listado de Periodos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }


    }
}
