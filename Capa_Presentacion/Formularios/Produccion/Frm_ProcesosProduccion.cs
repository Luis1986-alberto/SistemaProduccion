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
    public partial class Frm_ProcesosProduccion : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_ProcesosProduccion()
        {
            InitializeComponent();
        }

        private void Frm_ProcesosProduccion_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            List<PR_aProcesos> Listado = PR_aProcesos_CN._Instancia.Lista_Procesos();

            SortableBindingList<PR_aProcesos> listadoprocesos = new SortableBindingList<PR_aProcesos>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = listadoprocesos;
        }

        private void Entrada_Datos(int idprocesos)
        {
            var result = PR_aProcesos_CN._Instancia.TraerPorID(idprocesos);
            foreach (var i in result)
            {
                txt_IdProcesos.Text = i.IdProcesos.ToString();
                txt_Procesos.Text = i.Secuencia_Procesos.ToString();

                if (i.Flag_Extrusion.ToString() == "1") Chk_FlagExtrusion.Checked = true;
                else Chk_FlagExtrusion.Checked = false;

                if (i.Flag_Impresion.ToString() == "1") Chk_FlagImpresion.Checked = true;
                else Chk_FlagImpresion.Checked = false;

                if (i.Flag_Sellado.ToString() == "1") Chk_FlagSellado.Checked = true;
                else Chk_FlagSellado.Checked = false;

                if (i.Flag_Corte.ToString() == "1") Chk_FlagCorte.Checked = true;
                else Chk_FlagCorte.Checked = false;

                if (i.Flag_Laminado.ToString() == "1") Chk_FlagLaminado.Checked = true;
                else Chk_FlagLaminado.Checked = false;

                if (i.Flag_Doblado.ToString() == "1") Chk_FlagDoblado.Checked = true;
                else Chk_FlagDoblado.Checked = false;

            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdProcesos.Text = "0";
            
            txt_Procesos.Enabled = true;
            HabilitarControles(true);
            Limpiar();
            txt_Procesos.Focus();
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

            txt_Procesos.Enabled = true;
            HabilitarControles(true);
            txt_Procesos.Focus();
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
                rpta = PR_aProcesos_CN._Instancia.Eliminar(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_aProcesos()
            {
                IdProcesos = byte.Parse(txt_IdProcesos.Text),
                Secuencia_Procesos = txt_Procesos.Text,
                Flag_Extrusion = byte.Parse(Chk_FlagExtrusion.Checked ==true ? "1":"0"),
                Flag_Impresion = byte.Parse(Chk_FlagImpresion.Checked == true ? "1" :"0"),
                Flag_Sellado =  byte.Parse(Chk_FlagSellado.Checked == true ? "1":"0"),
                Flag_Doblado = byte.Parse(Chk_FlagDoblado.Checked == true ? "1" : "0"),
                Flag_Corte = byte.Parse(Chk_FlagCorte.Checked == true ? "1":"0"),
                Flag_Laminado = byte.Parse(Chk_FlagLaminado.Checked == true ? "1":"0"),
                
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_aProcesos_CN._Instancia.Agregar(datos); }
            if (bln_Editar) { rpta = PR_aProcesos_CN._Instancia.Actualizar(datos); }

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                txt_Procesos.Enabled = false;
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
            txt_Procesos.Enabled = false;
            HabilitarControles(false);
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {PrintDocument.Print();}
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

            var Listado_Ordenado = (from procesos in PR_aProcesos_CN._Instancia.Lista_Procesos().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select procesos).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from procesos in PR_aProcesos_CN._Instancia.Lista_Procesos().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select procesos).ToList();

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

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString()));

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

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProcesos"].Value.ToString()));

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
        private void Limpiar()
        {
            txt_Procesos.Text = "";
            Chk_FlagExtrusion.Checked = false;
            Chk_FlagImpresion.Checked = false;
            Chk_FlagSellado.Checked = false;
            Chk_FlagLaminado.Checked = false;
            Chk_FlagDoblado.Checked = false;
            Chk_FlagCorte.Checked = false;
        }
        private void HabilitarControles(Boolean vEnabled)
        {
            txt_Procesos.Enabled = vEnabled;
            Chk_FlagExtrusion.Enabled = vEnabled;
            Chk_FlagImpresion.Enabled = vEnabled;
            Chk_FlagSellado.Enabled = vEnabled;
            Chk_FlagLaminado.Enabled = vEnabled;
            Chk_FlagDoblado.Enabled = vEnabled;
            Chk_FlagCorte.Enabled = vEnabled;
        }
        private bool Verificar_Datos()
        {
            if (txt_Procesos.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese los Procesos", "Ingreso de datos", MessageBoxButtons.OK);
                txt_Procesos.Focus();
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

            PrintDocument.DocumentName = "Reporte Años";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Procesos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Procesos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
