using System;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_PaisProcedencia : Form
    {
        //DataGridViewPrinter dgr_Visor_Grilla;
        //private bool bln_Nuevo = false;
        //private bool bln_Editar = false;
        //private string str_Campo;

        public Frm_PaisProcedencia()
        {
            InitializeComponent();
        }

        private void Frm_PaisProcedencia_Load(object sender, EventArgs e)
        {
            tbc_Mnt.SelectTab(1);
            Cargar_Datos();
            tbc_Mnt.Selecting += new TabControlCancelEventHandler(tbc_Mnt_Selecting);
        }

        private void tbc_Mnt_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (dgv_Mnt.SelectedRows.Count > 0)
            { Entrada_Datos(Int32.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString())); }
        }

        private void Cargar_Datos()
        {
            //List<aPaisProcedencia> Listado = aPaisProcedencia_CN._Instancia.Lista_PaisProcedencia();

            //SortableBindingList<aPaisProcedencia> ListadoMes = new SortableBindingList<aPaisProcedencia>(Listado);

            //dgv_Mnt.AutoGenerateColumns = false;
            //dgv_Mnt.DataSource = ListadoMes;
        }

        private void Entrada_Datos(int idpasisprocedencia)
        {
            //var result = aPaisProcedencia_CN._Instancia.Traer_PaisProcedenciaPorId(idpasisprocedencia);
            //foreach (var i in result)
            //{
            //    txt_IdPaisProcedencia.Text = i.IdPaisProcedencia.ToString();
            //    txt_NombrePais.Text = i.Nombre_Pais.ToString();
            //}
        }

        private void tls_Agregar_Click(object sender, EventArgs e)
        {
            //bln_Nuevo = true;
            //bln_Editar = false;

            tbc_Mnt.SelectTab(0);
            Estado_Toolbar(true);
            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            txt_IdPaisProcedencia.Text = "0";
            txt_NombrePais.Text = "";
            txt_NombrePais.Enabled = true;
            txt_NombrePais.Focus();
        }

        private void tls_Modificar_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.RowCount == 0)
            {
                MessageBox.Show("No hay registro para modificar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //bln_Editar = true;
            //bln_Nuevo = false;

            //Estado_Toolbar(bln_Editar);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = false;
            tbc_Mnt.SelectTab(0);

            txt_NombrePais.Enabled = true;
            txt_NombrePais.Focus();
        }

        private void tls_Eliminar_Click(object sender, EventArgs e)
        {
            //string rpta = "";

            //if (dgv_Mnt.RowCount == 0)
            //{
            //    MessageBox.Show("No hay registro para Eliminar", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (MessageBox.Show("Esta Seguro Eliminar el Registro", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    rpta = aPaisProcedencia_CN._Instancia.Eliminar_PaisProcedencia(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString()));
            //    if (rpta == "PROCESADO") { MessageBox.Show("Se elimino el registro", "Eliminar Registro"); }
            //    else { MessageBox.Show(rpta); }
            //}
            //Cargar_Datos();
        }

        private void tls_Grabar_Click(object sender, EventArgs e)
        {
            //string rpta = "";
            //var datos = new aPaisProcedencia()
            //{
            //    IdPaisProcedencia = int.Parse(txt_IdPaisProcedencia.Text),
            //    Nombre_Pais = txt_NombrePais.Text,
            //};

            //if (Verificar_Datos() == false) { return; }

            //if (bln_Nuevo) { rpta = aPaisProcedencia_CN._Instancia.Agregar_PaisProcedencia(datos); }
            //if (bln_Editar) { rpta = aPaisProcedencia_CN._Instancia.Actualizar_PaisProcedencia(datos); }

            //if (rpta == "PROCESADO")
            //{
            //    if (bln_Nuevo)
            //    { MessageBox.Show("Se Agrego un nuevo Registro", "Agregar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            //    else { MessageBox.Show("Se Actualizo el registro", "Actualizar Registro", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            //    bln_Editar = false;
            //    bln_Nuevo = false;

            //    Estado_Toolbar(bln_Editar);
            //    tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            //    txt_NombrePais.Enabled = false;
            //    tbc_Mnt.SelectTab(1);
            //}
            //else { MessageBox.Show(rpta, "error Inesperado"); }

            //Cargar_Datos();
        }

        private void tls_Deshacer_Click(object sender, EventArgs e)
        {
            //bln_Editar = false;
            //bln_Nuevo = false;

            tbc_Mnt.SelectTab(1);

            tbc_Mnt.TabPages["tbp_Listado"].Enabled = true;
            txt_NombrePais.Enabled = false;
            //Estado_Toolbar(bln_Editar);
        }

        private void tls_Imprimir_Click(object sender, EventArgs e)
        {

        }

        private void tls_Previo_Click(object sender, EventArgs e)
        {

        }

        private void tls_Buscar_Click(object sender, EventArgs e)
        {
            Frm_Buscar fBuscar = new Frm_Buscar();
            fBuscar.Configurar(ref dgv_Mnt, dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name);
            fBuscar.ShowDialog();
        }

        private void tls_OrdenASC_Click(object sender, EventArgs e)
        {
            //str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            //var Listado_Ordenado = (from pais in aPaisProcedencia_CN._Instancia.Lista_PaisProcedencia().OrderBy(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
            //                        select pais).ToList();

            //dgv_Mnt.DataSource = Listado_Ordenado;
        }

        private void tls_OrdenDsc_Click(object sender, EventArgs e)
        {
            //str_Campo = dgv_Mnt.Columns[dgv_Mnt.CurrentCell.ColumnIndex].Name;

            //var Listado_Ordenado = (from pais in aPaisProcedencia_CN._Instancia.Lista_PaisProcedencia().OrderByDescending(r => r.GetType().GetProperty(str_Campo).GetValue(r, null))
            //                        select pais).ToList();

            //dgv_Mnt.DataSource = Listado_Ordenado;
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

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString()));

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

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString()));
        }

        private void tls_Siguiente_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            int SelectIndex = dgv_Mnt.SelectedRows[0].Index;

            if (dgv_Mnt.Rows.Count - 1 == SelectIndex) { return; }
            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[SelectIndex + 1].Selected = true;
            SelectIndex = SelectIndex + 1;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString()));
        }

        private void tls_Ultimo_Click(object sender, EventArgs e)
        {
            if (dgv_Mnt.Rows.Count == 0) { return; }

            dgv_Mnt.ClearSelection();
            dgv_Mnt.Rows[dgv_Mnt.Rows.Count - 1].Selected = true;

            Entrada_Datos(int.Parse(dgv_Mnt.SelectedRows[0].Cells["idpaisprocedencia"].Value.ToString()));

            dgv_Mnt.FirstDisplayedScrollingRowIndex = dgv_Mnt.SelectedRows[0].Index;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

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
            if (txt_NombrePais.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el nombre del pais ", "Ingreso de datos", MessageBoxButtons.OK);
                txt_NombrePais.Focus();
                return false;
            }

            return true;
        }

    }
}
