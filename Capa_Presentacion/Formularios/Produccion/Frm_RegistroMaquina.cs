using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using Capa_Presentacion.Formularios.Logistica;
using Capa_Presentacion.Framework.ComponetModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_RegistroMaquina : Form
    {
        DataGridViewPrinter dgr_Visor_Grilla;
        private bool bln_Nuevo, bln_Editar = false;
        private string str_Campo;
        public List<PR_mMaquina> lst_maquina = new List<PR_mMaquina>();

        public Frm_RegistroMaquina()
        {
            InitializeComponent();
        }

        private void Frm_RegistroMaquina_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            cbo_marcamaquina.DataSource = PR_aMarcaMaquina_CN._Instancia.Lista_MarcaMaquina();
            cbo_tipomaquina.DataSource = PR_aTipoMaquina_CN._Instancia.Lista_TipoMaquina();
            cbo_FiltroTipoMaquina.DataSource = PR_aTipoMaquina_CN._Instancia.Lista_TipoMaquina();
            Cbo_ProveedorMaquina.DataSource = LG_xProveedor_CN._Instancia.Lista_Proveedores();
            cbo_EmpresaCompra.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
            cbo_FiltroEmpresa.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
            Cbo_AñoFabricacion.DataSource = PR_aAño_CN._Instancia.Lista_Años();
            cbo_EstadoMaquina.DataSource = PR_aEstadoMaquina_CN._Instancia.Lista_EstadoMaquina();

            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["idmaquina"].Value.ToString())); }
        }

        public void Cargar_Datos()
        {
            var datos = new PR_mMaquina
            {
                IdTipoMaquina = byte.Parse(cbo_FiltroTipoMaquina.SelectedValue.ToString()),
                IdEmpresa = byte.Parse(cbo_FiltroEmpresa.SelectedValue.ToString()),
            };
            List<PR_mMaquina> Lista = PR_mMaquina_CN._Instancia.Lista_Maquinas(datos, (chk_TipoMaquina.Checked == true) ? "1" : "0", (chk_FiltroEmpresa.Checked == true) ? "1" : "0", "0").ToList();
            SortableBindingList<PR_mMaquina> lst_maquina = new SortableBindingList<PR_mMaquina>(Lista);

            dgv_Mnt.AutoGenerateColumns = false;
            dgv_Mnt.DataSource = lst_maquina;

        }

        private void Entrada_Datos(Int32 idmaquina)
        {
            var result = PR_mMaquina_CN._Instancia.TraerPorID(idmaquina);
            foreach (var i in result)
            {
                txt_IdMaquina.Text = i.IdMaquina.ToString();
                txt_aliasmaquina.Text = i.Alias_Maquina.ToString();
                txt_modelomaquina.Text = i.Modelo_Maquina.ToString();
                txt_seriemaquina.Text = i.Serie_Maquina.ToString();
                Txt_CodigoMaquina.Text = i.Codigo_Maquina;
                Cbo_AñoFabricacion.SelectedValue = i.IdAño_Fabricacion;
                Dtp_Fecha_Compra.Text = i.Fecha_Compra.ToString();
                cbo_marcamaquina.SelectedValue = i.IdMarcaMaquina;
                cbo_tipomaquina.SelectedValue = i.IdTipoMaquina;
                Cbo_ProveedorMaquina.SelectedValue = i.IdProveedor;
                cbo_EmpresaCompra.SelectedValue = i.IdEmpresa;
                txt_PaisProcedencia.Text = i.Procedencia;
                NUD_CantidadMaxOP.Value = Int32.Parse(i.Numero_Maximo_OP.ToString());
                txt_ProduccionKg.Text = i.Produccion_Kg.ToString();
                txt_produccionmetros.Text = i.Produccion_Metros.ToString();
                txt_horastrabajo.Text = i.Tiempo_Horas.ToString();
                cbo_EstadoMaquina.SelectedValue = i.IdEstadoMaquina;
                Chk_FlagOperativo.Checked = (i.Flag_Operativo.ToString() == "1") ? true : false;
                Chk_Baja.Checked = (i.Flag_Baja.ToString() == "1") ? true : false;
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
            txt_IdMaquina.Text = "0";
            txt_aliasmaquina.Focus();
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
            txt_aliasmaquina.Focus();
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
                rpta = PR_mMaquina_CN._Instancia.Eliminar(int.Parse(dgv_Mnt.SelectedRows[0].Cells["IdMaquina"].Value.ToString()));
                if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
                else { MessageBox.Show(rpta); }
            }
            Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            var datos = new PR_mMaquina()
            {
                IdMaquina = short.Parse(txt_IdMaquina.Text),
                IdMarcaMaquina = byte.Parse(cbo_marcamaquina.SelectedValue.ToString()),
                IdTipoMaquina = byte.Parse(cbo_tipomaquina.SelectedValue.ToString()),
                Procedencia = txt_PaisProcedencia.Text,
                IdUsuario = "Lquiroz",
                Alias_Maquina = txt_aliasmaquina.Text,
                Modelo_Maquina = txt_modelomaquina.Text,
                Serie_Maquina = txt_seriemaquina.Text,
                IdEmpresa = byte.Parse(cbo_EmpresaCompra.SelectedValue.ToString()),
                IdProveedor = short.Parse(Cbo_ProveedorMaquina.SelectedValue.ToString()),
                IdEstadoMaquina = byte.Parse(cbo_EstadoMaquina.SelectedValue.ToString()),
                IdAño_Fabricacion = byte.Parse(Cbo_AñoFabricacion.SelectedValue.ToString()),
                Codigo_Maquina = Txt_CodigoMaquina.Text,
                Fecha_Compra = DateTime.Parse(Dtp_Fecha_Compra.Value.ToShortDateString()),
                Numero_Maximo_OP = int.Parse(NUD_CantidadMaxOP.Value.ToString()),
                Produccion_Kg = decimal.Parse(txt_ProduccionKg.Text),
                Produccion_Metros = decimal.Parse(txt_produccionmetros.Text),
                Tiempo_Horas = decimal.Parse(txt_horastrabajo.Text),
                Flag_Operativo = byte.Parse((Chk_FlagOperativo.Checked == true) ? "1" : "0"),
                Flag_Baja = byte.Parse((Chk_Baja.Checked == true) ? "1" : "0"),
                Ruta_Imagen = Txt_DireccionImagen.Text,
            };

            if (Verificar_Datos() == false) { return; }

            if (bln_Nuevo) { rpta = PR_mMaquina_CN._Instancia.Agregar_Maquina(datos, Img_Producto); }
            if (bln_Editar) { rpta = PR_mMaquina_CN._Instancia.Actualizar_Maquina(datos, Img_Producto); }

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

        private bool Verificar_Datos()
        {
            if (txt_aliasmaquina.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el alias maquina", "Ingreso de datos", MessageBoxButtons.OK);
                txt_aliasmaquina.Focus();
                return false;
            }

            if (txt_modelomaquina.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el modelo maquina", "Ingreso de datos", MessageBoxButtons.OK);
                txt_modelomaquina.Focus();
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
            var Listado_Ordenado = (from maquina in PR_mMaquina_CN._Instancia.Lista_Maquinas() select maquina).ToList();

            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from maquina in PR_mMaquina_CN._Instancia.Lista_Maquinas() select maquina).ToList();
            dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e)
        { Cargar_Datos(); }

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[0].Selected = true;
            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idmaquina"].Value.ToString()));
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

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idmaquina"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idmaquina"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idmaquina"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_Producto.ImageLocation = getImagen.FileName;
                Txt_DireccionImagen.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnLimpiarImagen_Click(object sender, EventArgs e)
        {
            Img_Producto.Image = null;
            Txt_DireccionImagen.Text = "";
        }

        private void Chk_MostrarImagen_CheckedChanged(object sender, EventArgs e)
        {
            Img_Producto.Image = null;
            if (bln_Nuevo == false)
            {
                if (Chk_MostrarImagen.Checked == true)
                { PR_mMaquina_CN._Instancia.Descargar_ImagenMaquina(Img_Producto, Int32.Parse(txt_IdMaquina.Text)); }
            }

            Chk_MostrarImagen.Checked = Chk_MostrarImagen.Checked;
        }

        public void LimpiarControles()
        {
            txt_aliasmaquina.Text = "";
            txt_modelomaquina.Text = "";
            txt_seriemaquina.Text = "";
            Txt_CodigoMaquina.Text = "";
            txt_PaisProcedencia.Text = "";
            NUD_CantidadMaxOP.Value = 0;
            txt_ProduccionKg.Text = "0.00";
            txt_produccionmetros.Text = "0.00";
            txt_horastrabajo.Text = "0";
            Txt_DireccionImagen.Text = "";
            Img_Producto.Image = null;
        }

        private void HabilitarControles(Boolean vEstado)
        {
            cbo_tipomaquina.Enabled = vEstado;
            cbo_marcamaquina.Enabled = vEstado;
            txt_modelomaquina.Enabled = vEstado;
            txt_seriemaquina.Enabled = vEstado;
            txt_aliasmaquina.Enabled = vEstado;
            Cbo_ProveedorMaquina.Enabled = vEstado;
            cbo_EmpresaCompra.Enabled = vEstado;
            txt_PaisProcedencia.Enabled = vEstado;
            Txt_CodigoMaquina.Enabled = vEstado;
            Dtp_Fecha_Compra.Enabled = vEstado;
            Cbo_AñoFabricacion.Enabled = vEstado;
            NUD_CantidadMaxOP.Enabled = vEstado;
            txt_ProduccionKg.Enabled = vEstado;
            txt_produccionmetros.Enabled = vEstado;
            txt_horastrabajo.Enabled = vEstado;
            Chk_Baja.Enabled = vEstado;
            Chk_FlagOperativo.Enabled = vEstado;
            cbo_EstadoMaquina.Enabled = vEstado;
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

        private void cmd_TipoMaquina_Click(object sender, EventArgs e)
        {
            Frm_TipoMaquina tipomaquina = new Frm_TipoMaquina();
            tipomaquina.ShowDialog();
            cbo_tipomaquina.DataSource = PR_aTipoMaquina_CN._Instancia.Lista_TipoMaquina();
        }

        private void cnd_MarcaMaquina_Click(object sender, EventArgs e)
        {
            Frm_MarcaMaquina marcamaquina = new Frm_MarcaMaquina();
            marcamaquina.ShowDialog();
            cbo_marcamaquina.DataSource = PR_aMarcaMaquina_CN._Instancia.Lista_MarcaMaquina();
        }

        private void Cmd_ProveedorMaquina_Click(object sender, EventArgs e)
        {
            Frm_Proveedores proveedores = new Frm_Proveedores();
            proveedores.ShowDialog();
            Cbo_ProveedorMaquina.DataSource = LG_xProveedor_CN._Instancia.Lista_Proveedores();
        }

        private void Cmd_AñoFabricacion_Click(object sender, EventArgs e)
        {
            Frm_Año año = new Frm_Año();
            año.ShowDialog();
            Cbo_AñoFabricacion.DataSource = PR_aAño_CN._Instancia.Lista_Años();
        }

        private void cmd_EmpresasCompra_Click(object sender, EventArgs e)
        {
            Frm_Empresa empresa = new Frm_Empresa();
            empresa.ShowDialog();
            cbo_EmpresaCompra.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void txt_ProduccionKg_KeyPress(object sender, KeyPressEventArgs e)
        { Validar_Campos.NumerosDecimales(e); }

        private void txt_produccionmetros_KeyPress(object sender, KeyPressEventArgs e)
        { Validar_Campos.NumerosDecimales(e); }

        private void txt_horastrabajo_KeyPress(object sender, KeyPressEventArgs e)
        { Validar_Campos.NumerosDecimales(e); }

        private void cmd_EstadoMaquina_Click(object sender, EventArgs e)
        {
            Frm_EstadoMaquina estadomaquina = new Frm_EstadoMaquina();
            estadomaquina.ShowDialog();
            cbo_EstadoMaquina.DataSource = PR_aEstadoMaquina_CN._Instancia.Lista_EstadoMaquina();
        }

        private void chk_TipoMaquina_CheckedChanged(object sender, EventArgs e)
        {
            cbo_FiltroTipoMaquina.Enabled = chk_TipoMaquina.Checked;
            Cargar_Datos();
        }

        private void chk_FiltroEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            cbo_FiltroEmpresa.Enabled = chk_FiltroEmpresa.Checked;
            Cargar_Datos();
        }

        private void cbo_FiltroTipoMaquina_SelectedIndexChanged(object sender, EventArgs e)
        { if (chk_TipoMaquina.Checked == true) Cargar_Datos(); }

        private void cbo_FiltroEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        { if (chk_FiltroEmpresa.Checked == true) Cargar_Datos(); }

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

            PrintDocument.DocumentName = "Reporte Maquinas";
            PrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            PrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            PrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, true, true, "Listado de Maquinas", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, PrintDocument, false, true, "Listado de Maquinas", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


    }
}
