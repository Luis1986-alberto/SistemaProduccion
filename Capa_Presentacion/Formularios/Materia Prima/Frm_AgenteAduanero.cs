using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_AgenteAduanero : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool Nuevo = false;
        private bool Editar = false;
        private string str_Campo;

        public Frm_AgenteAduanero()
        {
            InitializeComponent();
        }

        private void Frm_AgenteAduanero_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            dgv_Mnt.AutoGenerateColumns = false;
            List<MP_aAgenteAduanero> lista = MP_aAgenteAduanero_CN._Instancia.Lista_AgenteAduanero();
            SortableBindingList<MP_aAgenteAduanero> Lsta_etiquetadoras = new SortableBindingList<MP_aAgenteAduanero>(lista);
            dgv_Mnt.DataSource = Lsta_etiquetadoras;
        }

        private void Entrada_Datos(byte Id)
        {
            var datos = MP_aAgenteAduanero_CN._Instancia.TraerPorId(Id);

            foreach (var i in datos)
            {
                txt_IdAgenteAduanero.Text = i.IdAgenteAduanero.ToString();
                txt_Razon_Social_Agente.Text = i.Razon_Social_Agente;
                txt_Direccion_Agente.Text = i.Direccion_Agente;
                txt_Numero_RUC_Agente.Text = i.Numero_RUC_Agente;
                txt_Numero_Telefono_Agente.Text = i.Numero_Telefono_Agente;
                txt_Numero_Celular_Agente.Text = i.Numero_Celular_Agente;
                txt_Numero_Fax_Agente.Text = i.Numero_Fax_Agente;
                txt_Correo_Agente.Text = i.Correo_Agente;
            }
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            Nuevo = true;
            Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            LimpiarControles();
            HabilitarControles(true);
            txt_IdAgenteAduanero.Text = "0";
            txt_Razon_Social_Agente.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            Nuevo = false;
            Editar = true;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            HabilitarControles(true);
            txt_Razon_Social_Agente.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0) { MessageBox.Show("No existe Registros a Eliminar", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            if (MessageBox.Show("Esta Seguro de Eliminar", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string rpta = MP_aAgenteAduanero_CN._Instancia.Eliminar(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString()));

                if (rpta == "PROCESADO") { MessageBox.Show("Se Elimino el Registro", "Eliminar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show(rpta, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            if (Verificar_Datos() == false) { return; }

            var datos = new MP_aAgenteAduanero()
            {
                IdAgenteAduanero = byte.Parse(txt_IdAgenteAduanero.Text),
                Razon_Social_Agente = txt_Razon_Social_Agente.Text,
                Direccion_Agente = txt_Direccion_Agente.Text,
                Numero_RUC_Agente = txt_Numero_RUC_Agente.Text,
                Numero_Telefono_Agente = txt_Numero_Telefono_Agente.Text,
                Numero_Celular_Agente = txt_Numero_Celular_Agente.Text,
                Numero_Fax_Agente = txt_Numero_Fax_Agente.Text,
                Correo_Agente = txt_Correo_Agente.Text,
            };

            if (Nuevo) rpta = MP_aAgenteAduanero_CN._Instancia.Agregar(datos);
            if (Editar) rpta = MP_aAgenteAduanero_CN._Instancia.Actualizar(datos);

            if (rpta == "PROCESADO")
            {
                if (Nuevo) { MessageBox.Show("Se Agrego un Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el Registro", "Actualizacion registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else { MessageBox.Show(rpta, "Error al Procesar", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            HabilitarControles(false);
            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Estado_Toolbar(false);
            Cargar_Datos();

        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            Editar = false;
            Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            HabilitarControles(false);
            Estado_Toolbar(Editar);
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

            var Listado_Ordenado = (from ordenar in MP_aAgenteAduanero_CN._Instancia.Lista_AgenteAduanero().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in MP_aAgenteAduanero_CN._Instancia.Lista_AgenteAduanero().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            _ = SelectIndex - 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdAgenteAduanero"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private bool Verificar_Datos()
        {
            if (txt_Razon_Social_Agente.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Razon Social", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(txt_Razon_Social_Agente, "Ingrese Razon Social");
                return false;
            }
            else { ErrorIcono.SetError(txt_Razon_Social_Agente, null); }

            if (txt_Direccion_Agente.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la Direccion", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(txt_Direccion_Agente, "Ingrese Direccion");
                return false;
            }
            else { ErrorIcono.SetError(txt_Direccion_Agente, null); }

            if (txt_Numero_RUC_Agente.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el Numero de RUC", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(txt_Numero_RUC_Agente, "Ingrese Numero RUC");
                return false;
            }
            else { ErrorIcono.SetError(txt_Numero_RUC_Agente, null); }

            if (new EmailAddressAttribute().IsValid(txt_Correo_Agente.Text))
            { }
            else
            {
                MessageBox.Show("Ingrese el Correo Valido", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(txt_Correo_Agente, "Ingrese Correo");
                return false;
            }

            return true;
        }

        private void LimpiarControles()
        {
            txt_Razon_Social_Agente.Text = "";
            txt_Direccion_Agente.Text = "";
            txt_Numero_RUC_Agente.Text = "";
            txt_Numero_Telefono_Agente.Text = "";
            txt_Numero_Celular_Agente.Text = "";
            txt_Numero_Fax_Agente.Text = "";
            txt_Correo_Agente.Text = "";
        }

        private void HabilitarControles(Boolean vEnabled)
        {
            txt_Razon_Social_Agente.Enabled = vEnabled;
            txt_Direccion_Agente.Enabled = vEnabled;
            txt_Numero_RUC_Agente.Enabled = vEnabled;
            txt_Numero_Telefono_Agente.Enabled = vEnabled;
            txt_Numero_Celular_Agente.Enabled = vEnabled;
            txt_Numero_Fax_Agente.Enabled = vEnabled;
            txt_Correo_Agente.Enabled = vEnabled;
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

            PrintDocument.DocumentName = "Reporte Agentes";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Agente Aduanero ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Agente Aduanero ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
