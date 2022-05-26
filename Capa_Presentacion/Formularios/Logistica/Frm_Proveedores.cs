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

namespace Capa_Presentacion.Formularios.Logistica
{
    public partial class Frm_Proveedores : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo = false;
        private bool bln_Editar = false;
        private string str_Campo;

        public Frm_Proveedores()
        {
            InitializeComponent();
        }

        private void Frm_Proveedores_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
            Cbo_TipoProveedor.DataSource = LG_aTipoProveedor_CN.Instancia.Lista_TipoProveedor();
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProveedor"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            List<LG_xProveedor> Listado = LG_xProveedor_CN._Instancia.Lista_Proveedores();
            SortableBindingList<LG_xProveedor> listadopieimp = new SortableBindingList<LG_xProveedor>(Listado);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = listadopieimp;
        }

        private void Entrada_Datos(int id)
        {
            var result = LG_xProveedor_CN._Instancia.TraerPorId(id);
            txt_IdProveedor.Text = result.IdProveedor.ToString();
            Txt_RazonSocial.Text = result.Razon_Social_Proveedor;
            Cbo_TipoProveedor.SelectedValue = result.IdTipoProveedor;
            Txt_RUC.Text = result.RUC_Proveedor;
            Txt_Direccion.Text = result.Direccion_Proveedor;
            Txt_PaginaWeb.Text = result.Pagina_Web_Proveedor;
            Txt_telefono1.Text = result.Telefono1_Proveedor;
            Txt_Telefono2.Text = result.Telefono2_Proveedor;
            Txt_CorreoEmpresa.Text = result.Correo_Proveedor;
            Txt_NombreContacto.Text = result.Contacto_Proveedor;
            Txt_TelefonoContacto.Text = result.Telefono_Contacto;
            Txt_CelularContacto.Text = result.Celular1_Proveedor;
            Txt_CorreoContacto.Text = result.Correo_Contacto;
            Txt_Nota.Text = result.Nota;
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            Habilitar(true);
            Limpiar();
            txt_IdProveedor.Text = "0";
            Txt_RazonSocial.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = true;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Editar);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            Habilitar(true);
            Txt_RazonSocial.Focus();
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
                rpta = LG_xProveedor_CN._Instancia.Eliminar_Proveedor(byte.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProveedor"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();

        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string result = "";
            var datos = new LG_xProveedor
            {
                IdProveedor = Int32.Parse(txt_IdProveedor.Text),
                Razon_Social_Proveedor = Txt_RazonSocial.Text,
                RUC_Proveedor = Txt_RUC.Text,
                Telefono1_Proveedor = Txt_telefono1.Text,
                Telefono2_Proveedor = Txt_Telefono2.Text,
                Pagina_Web_Proveedor = Txt_PaginaWeb.Text,
                Direccion_Proveedor = Txt_Direccion.Text,
                Correo_Proveedor = Txt_CorreoEmpresa.Text,
                Contacto_Proveedor = Txt_NombreContacto.Text,
                Telefono_Contacto = Txt_TelefonoContacto.Text,
                Correo_Contacto = Txt_CorreoContacto.Text,
                Nota = Txt_Nota.Text,
                IdTipoProveedor = byte.Parse(Cbo_TipoProveedor.SelectedValue.ToString()),
                Celular1_Proveedor = Txt_CelularContacto.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { result = LG_xProveedor_CN._Instancia.Agregar_Proveedor(datos); }
            if (bln_Editar) { result = LG_xProveedor_CN._Instancia.Actualizar_Proveedor(datos); }

            if (result == "PROCESADO")
            {
                if (bln_Nuevo)
                { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                Habilitar(false);
                tbc_Mnt.SelectTab(1);
                Cargar_Datos();
            }
            else { MessageBox.Show(result, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Editar = false;
            bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            Habilitar(false);
            Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting()) { PrintDocument.Print(); }
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

            var Listado_Ordenado = (from ordenar in LG_aCondicionPago_CN._Instancia.Lista_CondicionPago().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            var Listado_Ordenado = (from ordenar in LG_aCondicionPago_CN._Instancia.Lista_CondicionPago().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
                                    select ordenar).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e) => Cargar_Datos();

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProvedor"].Value.ToString()));
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
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProvedor"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {

            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProvedor"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdProvedor"].Value.ToString()));
            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void Habilitar(Boolean vEnable)
        {
            Txt_RazonSocial.Enabled = vEnable;
            Cbo_TipoProveedor.Enabled = vEnable;
            Txt_RUC.Enabled = vEnable;
            Txt_Direccion.Enabled = vEnable;
            Txt_PaginaWeb.Enabled = vEnable;
            Txt_telefono1.Enabled = vEnable;
            Txt_Telefono2.Enabled = vEnable;
            Txt_CorreoEmpresa.Enabled = vEnable;
            Txt_NombreContacto.Enabled = vEnable;
            Txt_TelefonoContacto.Enabled = vEnable;
            Txt_CelularContacto.Enabled = vEnable;
            Txt_CorreoContacto.Enabled = vEnable;
            Txt_Nota.Enabled = vEnable;
        }

        private void Limpiar()
        {
            Txt_RazonSocial.Text = "";
            Txt_RUC.Text = "";
            Txt_Direccion.Text = "";
            Txt_PaginaWeb.Text = "";
            Txt_telefono1.Text = "";
            Txt_Telefono2.Text = "";
            Txt_CorreoEmpresa.Text = "";
            Txt_NombreContacto.Text = "";
            Txt_TelefonoContacto.Text = "";
            Txt_CelularContacto.Text = "";
            Txt_CorreoContacto.Text = "";
            Txt_Nota.Text = "";
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
            if (Txt_RazonSocial.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Razon Social Proveedor", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(Txt_RazonSocial, "Ingrese Estado Formulacion");
                return false;
            }
            else { ErrorIcono.Clear(); }

            if (Txt_RUC.Text == string.Empty)
            {
                MessageBox.Show("Ingrese RUC ", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(Txt_RUC, "Ingrese Estado Formulacion");
                return false;
            }
            else { ErrorIcono.Clear(); }
            if (Txt_CorreoEmpresa.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Correo Empresa", "Ingreso de datos", MessageBoxButtons.OK);
                ErrorIcono.SetError(Txt_CorreoEmpresa, "Ingrese Estado Formulacion");
                return false;
            }
            else { ErrorIcono.Clear(); }
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

            PrintDocument.DocumentName = "Forma Pago";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            //PrintDocument.Container = FormWindowState.Maximized;

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Forma Pago Pago ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Forma Pago ", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void cmd_TipoProveedor_Click(object sender, EventArgs e)
        {
            Frm_TipoProveedor tipoProveedor = new Frm_TipoProveedor();
            tipoProveedor.ShowDialog();
            Cbo_TipoProveedor.DataSource = LG_aTipoProveedor_CN._Instancia.Lista_TipoProveedor();
        }


    }
}
