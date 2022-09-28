using Capa_Entidades.Tablas;
using Microsoft.Reporting.WinForms;
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
    public partial class Frm_VisorReporte : Form
    {
        public Frm_VisorReporte()
        {
            InitializeComponent();
        }

        private void Frm_VisorReporte_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void Reporte_ListaTrabajadores(List<PR_mTrabajador> lst_Trabajdores )
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Capa_Presentacion.Reportes.Lista_Trabajadores.rdlc";
            ReportDataSource rds1 = new ReportDataSource("Trabajador", lst_Trabajdores);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
        }
    }
}
