using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Negocios
{
    public class PR_mEstandarExtrusion_CN
    {
        public static readonly PR_mEstandarExtrusion_CN _Instancia = new PR_mEstandarExtrusion_CN();

        public static PR_mEstandarExtrusion_CN Instancia
        { get { return PR_mEstandarExtrusion_CN._Instancia; } }


        public PR_mEstandarExtrusion TraerPorID(Int32 idestandarextr)
        {
            return PR_mEstandarExtrusion_CD._Instancia.TraerPorID(idestandarextr);
        }

        public void Descargar_ImagenProducto(PictureBox imagen, long idestandar)
        {
            PR_mEstandarExtrusion_CD._Instancia.Descargar_Imagen(imagen, idestandar);
        }

    }
}
