using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_Buscar : Form
    {
        public DataGridView rGrilla { get; set; }
        public Boolean bln_Ingreso { get; set; }
        public string str_Nombre_Campo;
        public string str_Tipo_Campo;

        public Frm_Buscar()
        {
            InitializeComponent();
        }

        public void Configurar(ref DataGridView vDgv_Mnt, string vNombre_Campo)
        {
            rGrilla = vDgv_Mnt;
            str_Nombre_Campo = vNombre_Campo;
            bln_Ingreso = false;
        }
        private void Frm_Buscar_Load(object sender, EventArgs e)
        {
            txt_Buscar.Text = rGrilla.SelectedRows[0].Cells[str_Nombre_Campo].Value.ToString();
            this.Text = "Buscado por:" + str_Nombre_Campo;
            str_Tipo_Campo = rGrilla.SelectedRows[0].Cells[str_Nombre_Campo].ValueType.ToString();
        }

        private void Tipo_Busqueda()
        {
            switch (str_Tipo_Campo.ToString())
            {
                case "System.String": MessageBox.Show("Cadena"); break;
                case "System.Char": MessageBox.Show("Cadena"); break;
                case "System.Boolean": MessageBox.Show("T/F"); break;
                case "System.Datetime": MessageBox.Show("T/F"); break;
                case "System.DatetimeOffset": MessageBox.Show("T/F"); break;
                case "System.Decimal": MessageBox.Show("Numero"); break;
                case "System.Double": MessageBox.Show("Numero"); break;
                case "System.Int16": MessageBox.Show("Numero"); break;
                case "System.Int32": MessageBox.Show("Numero"); break;
                case "System.Int64": MessageBox.Show("Numero"); break;
                case "System.SByte": MessageBox.Show("Numero"); break;
                case "System.Single": MessageBox.Show("Numero"); break;
                case "System.UInt16": MessageBox.Show("Numero"); break;
                case "System.UInt32": MessageBox.Show("Numero"); break;
                case "System.UInt64": MessageBox.Show("Numero"); break;
                case "System.Byte": MessageBox.Show("Numero"); break;

            }


        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            bln_Ingreso = true;
            this.Close();
        }

        bool BuscarLINQ(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();
            if (Columna == string.Empty)
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    from DataGridViewCell cells in row.Cells
                                                    where cells.OwningRow.Equals(row) && cells.Value == TextoABuscar
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            else
            {
                IEnumerable<DataGridViewRow> obj = (from DataGridViewRow row in grid.Rows.Cast<DataGridViewRow>()
                                                    where row.Cells[Columna].Value.ToString().ToUpper().Contains(TextoABuscar.ToUpper())
                                                    select row);
                if (obj.Any())
                {
                    grid.Rows[obj.FirstOrDefault().Index].Selected = true;
                    return true;
                }

            }
            return encontrado;

        }
        bool Buscar(string TextoABuscar, string Columna, DataGridView grid)
        {
            bool encontrado = false;
            if (TextoABuscar == string.Empty) return false;
            if (grid.RowCount == 0) return false;
            grid.ClearSelection();
            if (Columna == string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        if (cell.Value == TextoABuscar)
                        {
                            row.Selected = true;
                            return true;
                        }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells[Columna].Value.ToString() == TextoABuscar)
                    {
                        row.Selected = true;
                        return true;
                    }
                }
            }
            return encontrado;
        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            var bln_Resultado = BuscarLINQ(txt_Buscar.Text.ToString().ToUpper(), str_Nombre_Campo.ToUpper(), rGrilla);
            if (bln_Resultado == true) { rGrilla.FirstDisplayedScrollingRowIndex = rGrilla.SelectedRows[0].Index; }
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            var bln_Resultado = BuscarLINQ(txt_Buscar.Text.ToString().ToUpper(), str_Nombre_Campo.ToUpper(), rGrilla);
            if (bln_Resultado == true) { rGrilla.FirstDisplayedScrollingRowIndex = rGrilla.SelectedRows[0].Index; }
        }
    }
}
