using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Presentacion.Clases
{
    public class Tipos_Impresion
    {
        private PrintDocument printdocument = new PrintDocument();
        private DataGridViewPrinter dgr_Visor_Grilla;

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool more = dgr_Visor_Grilla.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        public bool Imprimir_Grilla( DataGridView dgv_Mnt, string Nombre_Reporte,
                                            string Titulo_Reporte)
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

            printdocument.DocumentName = Nombre_Reporte;

            printdocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            printdocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printdocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("Desea que el informe se centre en la página", "Estilo de Impresion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, printdocument, true, true, Titulo_Reporte, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgr_Visor_Grilla = new DataGridViewPrinter(dgv_Mnt, printdocument, false, true, Titulo_Reporte, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;

            
        }
    }
}
