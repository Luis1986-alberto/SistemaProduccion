﻿using Capa_Presentacion.Formularios;
using System;
using System.Windows.Forms;

namespace Capa_Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIFrm_CorePrincipal());
        }
    }
}
