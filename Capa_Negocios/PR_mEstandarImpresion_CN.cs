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
    public class PR_mEstandarImpresion_CN
    {
        public static readonly PR_mEstandarImpresion_CN _Instancia = new PR_mEstandarImpresion_CN();

        public static PR_mEstandarImpresion_CN Instancia
        { get { return PR_mEstandarImpresion_CN._Instancia; } }

        public PR_mEstandarImpresion TraerPorId (Int32 videstandarimp)
        { return PR_mEstandarImpresion_CD._Instancia.TraerPorID(videstandarimp); }



        public void Descargar_ImagenProducto(PictureBox imagen, Int32 videstandarimp)
        {PR_mEstandarImpresion_CD._Instancia.Descargar_Imagen(imagen, videstandarimp);}



    }
}
