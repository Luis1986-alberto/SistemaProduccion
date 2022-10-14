using Capa_Entidades.Tablas;
using Capa_Negocios;
using Capa_Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios.Produccion
{
    public partial class Frm_RegistroTrabajador : Form
    {
        DataGridViewPrinter MyDataGridViewPrinter;
        private bool bln_Nuevo, bln_Editar = false;
        private IEnumerable<PR_mTrabajador> trabajador = null;
        private string str_Campo;

        public Frm_RegistroTrabajador()
        {
            InitializeComponent();
        }

        private void Frm_RegistroTrabajador_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            cbo_CargoTrabajador.DataSource = PR_aCargoTrabajador_CN.Instancia.Lista_CargoTrabajador();
            cbo_tipotrabajador.DataSource = PR_aTipoTrabajador_CN._Instancia.Lista_TipoTrabajador();
            cbo_Empresa.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
            Cbo_LocalArea.DataSource = PR_xLocalArea_CN._Instancia.Lista_Localarea();
            cbo_filtrocargotrabajador.DataSource = PR_aCargoTrabajador_CN.Instancia.Lista_CargoTrabajador();
            cbo_FiltroEmpresa.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (Dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["idtrabajador"].Value.ToString())); }
        }

        private void Entrada_Datos(Int32 idtrabajador)
        {
            var datos = PR_mTrabajador_CN._Intancia.Traer_PorId(idtrabajador);
            txt_IdTrabajador.Text = datos.IdTrabajador.ToString();
            txt_codigotrabajador.Text = datos.Codigo_Trabajador;
            txt_apellidopaterno.Text = datos.Apellido_Paterno;
            txt_apellidomaterno.Text = datos.Apellido_Materno;
            txt_nombres.Text = datos.Nombre;
            txt_dni.Text = datos.DNI;
            txt_telefono.Text = datos.Telefono;
            cbo_tipotrabajador.SelectedValue = datos.IdTipoTrabajador;
            cbo_CargoTrabajador.SelectedValue = datos.IdCargoTrabajador;
            cbo_Empresa.SelectedValue = datos.IdEmpresa;
            Cbo_LocalArea.SelectedValue = datos.IdLocalArea;
            Txt_DireccionImagen.Text = datos.Ruta_Imagen;
        }

        private void Cargar_Datos()
        {
            Dgv_Mnt.AutoGenerateColumns = false;
            trabajador = PR_mTrabajador_CN._Intancia.Lista_Trabajadores((chk_FiltroEmpresa.Checked == true) ? "1" : "0", Int32.Parse(cbo_FiltroEmpresa.SelectedValue.ToString()),
                                                     (chk_Filtrocargotrabajador.Checked == true) ? "1" : "0", Int32.Parse(cbo_filtrocargotrabajador.SelectedValue.ToString()));
            Dgv_Mnt.DataSource = trabajador;
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            bln_Nuevo = true;
            bln_Editar = false;
            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(bln_Nuevo);
            HabilitarControles(true);
            LimpiarControles();
            txt_IdTrabajador.Text = "0";
            txt_codigotrabajador.Focus();
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

        private void HabilitarControles(Boolean vEstado)
        {
            txt_codigotrabajador.Enabled = vEstado;
            txt_apellidopaterno.Enabled = vEstado;
            txt_apellidomaterno.Enabled = vEstado;
            txt_nombres.Enabled = vEstado;
            txt_telefono.Enabled = vEstado;
            txt_dni.Enabled = vEstado;
            cbo_CargoTrabajador.Enabled = vEstado;
            cbo_Empresa.Enabled = vEstado;
            cbo_tipotrabajador.Enabled = vEstado;
            Cbo_LocalArea.Enabled = vEstado;
        }

        private void LimpiarControles()
        {
            txt_codigotrabajador.Text = "";
            txt_apellidopaterno.Text = "";
            txt_apellidomaterno.Text = "";
            txt_nombres.Text = "";
            txt_telefono.Text = "";
            txt_dni.Text = "";
            Txt_DireccionImagen.Text = "";
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay Registro para Modificar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay Registro para Modificar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Esta Seguro de Eliminar ek Registro", "Eliminar Registro Trabajador", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = PR_mTrabajador_CN._Intancia.Eliminar_Trabajador(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdTrabajador"].Value.ToString()));
                Cargar_Datos();
                tbc_Mnt.SelectTab(1);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            }
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            var datos = new PR_mTrabajador
            {
                IdTrabajador = short.Parse(txt_IdTrabajador.Text),
                Codigo_Trabajador = txt_codigotrabajador.Text,
                Nombre = txt_nombres.Text,
                Apellido_Paterno = txt_apellidopaterno.Text,
                Apellido_Materno = txt_apellidomaterno.Text,
                DNI = txt_dni.Text,
                Telefono = txt_telefono.Text,
                IdTipoTrabajador = byte.Parse(cbo_tipotrabajador.SelectedValue.ToString()),
                IdCargoTrabajador = byte.Parse(cbo_CargoTrabajador.SelectedValue.ToString()),
                IdEmpresa = byte.Parse(cbo_Empresa.SelectedValue.ToString()),
                IdLocalArea = byte.Parse(Cbo_LocalArea.SelectedValue.ToString()),
                Ruta_Imagen = Txt_DireccionImagen.Text,
            };


            if (bln_Nuevo) rpta = PR_mTrabajador_CN._Intancia.Agregar_Trabajado(datos, Img_fototrabajador);
            if (bln_Editar) rpta = PR_mTrabajador_CN._Intancia.Actualizar_Trabajador(datos, Img_fototrabajador);

            if (rpta == "PROCESADO")
            {
                if (bln_Nuevo) MessageBox.Show("SE AGREGO UN REGISTRO", "REGISTRO TRABAJADOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (bln_Editar) MessageBox.Show("SE ACTUALIZO UN REGISTRO", "ACTUALIZAR REGISTRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                bln_Editar = false;
                bln_Nuevo = false;

                Estado_Toolbar(bln_Editar);
                tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
                HabilitarControles(false);
                tbc_Mnt.SelectTab(1);
            }
            else { MessageBox.Show(rpta, "ERROR INESPERADO ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            Cargar_Datos();

        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            bln_Nuevo = false;
            bln_Editar = false;
            txt_IdTrabajador.Text = "0";
            tbc_Mnt.SelectTab(1);
            Estado_Toolbar(bln_Nuevo);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            HabilitarControles(false);
            LimpiarControles();
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {
            //if (SetupThePrinting())
            //{
            //    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
            //    MyPrintPreviewDialog.Document = PrintDocument;
            //    (MyPrintPreviewDialog as Form).WindowState = FormWindowState.Maximized;
            //    MyPrintPreviewDialog.ShowDialog();
            //}
        }

       

        private void tls_Previo_Click(object sender, EventArgs e)
        {
            Frm_VisorReporte visorReporte = new Frm_VisorReporte();
            visorReporte.Reporte_ListaTrabajadores(trabajador.ToList());
            visorReporte.ShowDialog();         
        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar buscar = new Frm_Buscar();
            buscar.Configurar(ref Dgv_Mnt, Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name);
            buscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            str_Campo = Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var Listado_Ordenado = (from Años in trabajador.OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null)) select Años).ToList();
            Dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            str_Campo = Dgv_Mnt.Columns[Dgv_Mnt.CurrentCell.ColumnIndex].Name;
            var lista_Ordenado = (from años in trabajador.OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null)) select años).ToList();
            Dgv_Mnt.DataSource = lista_Ordenado;
        }

        private void tls_Refrescar_Click(object sender, EventArgs e)
        { Cargar_Datos(); }

        private void tls_Primero_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) return;

            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[0].Selected = true;
            Entrada_Datos(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["IdTrabajador"].Value.ToString()));
            Dgv_Mnt.FirstDisplayedScrollingRowIndex = Dgv_Mnt.SelectedRows[0].Index;
            Chk_MostrarImagen_CheckedChanged(null, null);
        }

        private void tls_Anterior_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = Dgv_Mnt.SelectedRows[0].Index;

            if (SelectIndex == 0) { return; }
            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[SelectIndex - 1].Selected = true;
            SelectIndex = SelectIndex - 1;
            Entrada_Datos(int.Parse(Dgv_Mnt.SelectedRows[0].Cells["Idtrabajador"].Value.ToString()));
            Chk_MostrarImagen_CheckedChanged(null, null);
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) return;

            int selectIndex = Dgv_Mnt.SelectedRows[0].Index;

            if (Dgv_Mnt.Rows.Count - 1 == selectIndex) return;
            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[selectIndex + 1].Selected = true;
            selectIndex = selectIndex + 1;
            Entrada_Datos(Int32.Parse(Dgv_Mnt.SelectedRows[0].Cells["Idtrabajador"].Value.ToString()));
            Chk_MostrarImagen_CheckedChanged(null, null);
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (Dgv_Mnt.Rows.Count == 0) { return; }
            Dgv_Mnt.ClearSelection();
            Dgv_Mnt.Rows[Dgv_Mnt.Rows.Count - 1].Selected = true;
            Entrada_Datos(int.Parse(Dgv_Mnt.SelectedRows[0].Cells["Idtrabajador"].Value.ToString()));
            Dgv_Mnt.FirstDisplayedScrollingRowIndex = Dgv_Mnt.SelectedRows[0].Index;
            Chk_MostrarImagen_CheckedChanged(null, null);
        }

        private void cbo_FiltroEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        { if (chk_FiltroEmpresa.Checked == true) Cargar_Datos(); }

        private void cbo_filtrocargotrabajador_SelectedIndexChanged(object sender, EventArgs e)
        { if (chk_Filtrocargotrabajador.Checked == true) Cargar_Datos(); }

        private void chk_Filtrocargotrabajador_CheckedChanged(object sender, EventArgs e)
        {
            cbo_filtrocargotrabajador.Enabled = chk_Filtrocargotrabajador.Checked;
            Cargar_Datos();
        }

        private void chk_FiltroEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            cbo_FiltroEmpresa.Enabled = chk_FiltroEmpresa.Checked;
            Cargar_Datos();
        }

        private void cmd_TipoTrabajador_Click(object sender, EventArgs e)
        {
            Frm_TipoTrabajador tipoTrabajador = new Frm_TipoTrabajador();
            tipoTrabajador.ShowDialog();
            cbo_tipotrabajador.DataSource = PR_aTipoTrabajador_CN._Instancia.Lista_TipoTrabajador();
        }

        private void cmd_CargoTrabajador_Click(object sender, EventArgs e)
        {
            Frm_Cargotrabajador cargotrabajador = new Frm_Cargotrabajador();
            cargotrabajador.ShowDialog();
            cbo_CargoTrabajador.DataSource = PR_aCargoTrabajador_CN.Instancia.Lista_CargoTrabajador();
        }

        private void Cmd_LocalArea_Click(object sender, EventArgs e)
        {
            Frm_LocalvsArea localarea = new Frm_LocalvsArea();
            localarea.ShowDialog();
            Cbo_LocalArea.DataSource = PR_xLocalArea_CN._Instancia.Lista_Localarea();
        }

        private void cmd_Empresas_Click(object sender, EventArgs e)
        {
            Frm_Empresa empresa = new Frm_Empresa();
            empresa.ShowDialog();
            cbo_Empresa.DataSource = PR_aEmpresa_CN._Instancia.Lista_Empresas();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog getImagen = new OpenFileDialog();
            getImagen.InitialDirectory = "C:\\";
            getImagen.Filter = "Archivos de imagenes(*.jpg)(*.jpeg)|*.jpg;jpeg";

            if (getImagen.ShowDialog() == DialogResult.OK)
            {
                Img_fototrabajador.ImageLocation = getImagen.FileName;
                Txt_DireccionImagen.Text = getImagen.FileName;
            }
            else { MessageBox.Show("No se selecciono ninguna imagen", "Sin Seleccion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void btnLimpiarImagen_Click(object sender, EventArgs e)
        {
            Img_fototrabajador.Image = null;
            Txt_DireccionImagen.Text = "";
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void Cbo_LocalArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_area.Text = ((PR_xLocalArea)Cbo_LocalArea.SelectedItem).Nombre_Area.ToString();
            txt_local.Text = ((PR_xLocalArea)Cbo_LocalArea.SelectedItem).Nombre_Local.ToString();
        }

        private void Chk_MostrarImagen_CheckedChanged(object sender, EventArgs e)
        {
            Img_fototrabajador.Image = null;

            if (bln_Nuevo == false)
            {
                if (Chk_MostrarImagen.Checked == true)
                { PR_mTrabajador_CN._Intancia.Descargar_FotoTrabajador(Img_fototrabajador, Int32.Parse(txt_IdTrabajador.Text)); }
            }
        }
    }
}
