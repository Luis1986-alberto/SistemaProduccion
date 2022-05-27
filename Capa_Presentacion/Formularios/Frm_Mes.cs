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
    public partial class Frm_Mes : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;      
        private string str_Campo;

        public Frm_Mes()
        {
            InitializeComponent();
        }

        private void Frm_Mes_Load(object sender, EventArgs e)
        {
            Carga_Datos();
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);

            dgv_Mnt.AlternatingRowsDefaultCellStyle.BackColor = Color.SeaShell;
        }

        private void Carga_Datos()
        {
            List<LG_aMes> Listado = LG_aMes_CN._Instancia.Lista_Mes().ToList();

            SortableBindingList<LG_aMes> ListadoAños = new SortableBindingList<LG_aMes>(Listado);
            dgv_Mnt.DataSource = ListadoAños;
            dgv_Mnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { return; }
            if (!bln_Editar) { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString())); }
        }

        private void Entrada_Datos(byte vIdMes)
        {
            var Repositorio = LG_aMes_CN._Instancia.traerPorID(vIdMes);
            txt_IdMeses.Text = Repositorio.IdMes.ToString();
            txt_Mes.Text = Repositorio.Mes.ToString();
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = true;

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);

            HabilitarControles(true);
            LimpiarControles();
            Estado_Toolbar(bln_Nuevo);

            txt_IdMeses.Text = "0";
            txt_Mes.Enabled = true;
            txt_Mes.Focus();
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
                txt_Mes.Focus();
            }
            else { MessageBox.Show("No Existe elementos a modificar", "Modificar Elementos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount > 0)
            {
                if (MessageBox.Show("Esta Seguro que desea Eliminar", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string rpta = LG_aMes_CN._Instancia.Eliminar(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString()));
                    if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Question); }
                    else { MessageBox.Show("Error al Eliminar el registro" + rpta, "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else { MessageBox.Show("No Existe elementos a Eliminar", "Eliminar Elementos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new LG_aMes
            {
                IdMes = byte.Parse(txt_IdMeses.Text),
                Mes = txt_Mes.Text
            };

            if (bln_Nuevo) rpta = LG_aMes_CN._Instancia.Agregar(datos);
            if (bln_Editar) rpta = LG_aMes_CN._Instancia.Actualizar(datos);

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) MessageBox.Show("Se Agrego un Nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Se Actualiso unregisdtro", "Actualizar Rgeistro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bln_Nuevo = false;
                bln_Editar = false;

                HabilitarControles(false);
                Estado_Toolbar(false);
                Carga_Datos();

                tbc_Mnt.SelectTab(1);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            }
            else { MessageBox.Show(rpta, "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = false;

            HabilitarControles(false);
            Estado_Toolbar(false);
            Carga_Datos();

            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if(SetupThePrinting())
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
                (MyPrintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
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
            var Lista_Ordenado =( from meses in LG_aMes_CN._Instancia.Lista_Mes().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null)) 
                                  select meses).ToList();
            dgv_Mnt.DataSource = Lista_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_ordenada = (from meses in LG_aMes_CN._Instancia.Lista_Mes().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                  select meses).ToList();
            dgv_Mnt.DataSource = lista_ordenada;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Carga_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) return;

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected= true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString()));
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

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMes"].Value.ToString()));
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
        private void HabilitarControles(Boolean vEnabled)
        {
            txt_Mes.Enabled = vEnabled;
        }

        private void LimpiarControles()
        {
            txt_Mes.Text = "";
            txt_IdMeses.Text = " ";
        }

        private bool Verificar_Datos()
        {
            if (txt_Mes.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el mes", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Mes.Focus();
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

            PrintDocument.DocumentName = "Reporte Meses";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Meses", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Meses", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
