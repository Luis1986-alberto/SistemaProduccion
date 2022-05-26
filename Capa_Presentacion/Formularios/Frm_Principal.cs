using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capa_Presentacion.Formularios
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Frm_Principal_Closing);
        }

        void Frm_Principal_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void cmd_Produccion_Click(object sender, EventArgs e)
        {

        }

        private void cmd_CorePrincipal_Click(object sender, EventArgs e)
        {
            MDIFrm_CorePrincipal produccion = new MDIFrm_CorePrincipal();
            produccion.ShowDialog();

        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            this.Text = "Sistema de Producción - " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        }
    }
}

