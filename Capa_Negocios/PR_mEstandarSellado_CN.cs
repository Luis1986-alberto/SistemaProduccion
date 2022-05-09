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
    public class PR_mEstandarSellado_CN
    {
        public static readonly PR_mEstandarSellado_CN _Instancia = new PR_mEstandarSellado_CN();

        public static PR_mEstandarSellado_CN Instancia
        { get { return PR_mEstandarSellado_CN._Instancia; } }

        public PR_mEstandarSellado TraerPor_Id(Int32 videstandarsellado)
        {
            return PR_mEstandarSellado_CD.Instancia.TraerPorId(videstandarsellado);
        }


        public void Descargar_ImagenProducto(PictureBox imagen, Int32 videstandarsell)
        {
            PR_mEstandarSellado_CD._Instancia.Descargar_Imagen(imagen, videstandarsell);
        }

    }
}
