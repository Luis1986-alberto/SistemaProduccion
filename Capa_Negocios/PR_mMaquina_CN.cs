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
    public class PR_mMaquina_CN
    {
        public static readonly PR_mMaquina_CN _Instancia = new PR_mMaquina_CN();

        public static PR_mMaquina_CN Instancia
        { get { return PR_mMaquina_CN._Instancia; } }

        public IEnumerable<PR_mMaquina> Lista_Maquinas()
        {
            return PR_mMaquina_CD.Instancia.Listar();
        }
        public IEnumerable<PR_mMaquina> Lista_Maquinas(PR_mMaquina maquina, string flag_tipomaquina, string flag_empresa, string flag_proveedormaquina)
        {
            return PR_mMaquina_CD.Instancia.Listar(maquina, flag_tipomaquina, flag_empresa, flag_proveedormaquina);
        }

        public IEnumerable<PR_mMaquina> TraerPorID(Int32 idmaquina)
        {
            return PR_mMaquina_CD._Instancia.TraerPorId(idmaquina);
        }

        public string Agregar_Maquina(PR_mMaquina maquina, PictureBox imagen)
        {
            return PR_mMaquina_CD._Instancia.Agregar(maquina, imagen);
        }

        public string Actualizar_Maquina(PR_mMaquina maquina, PictureBox imagen)
        {
            return PR_mMaquina_CD._Instancia.Actualizar(maquina, imagen);
        }

        public string Eliminar(Int32 idmaquina)
        {   
            return PR_mMaquina_CD._Instancia.Eliminar(idmaquina);
        }

        public void Descargar_ImagenMaquina(PictureBox imagen, long idmaquina)
        {
            PR_mMaquina_CD._Instancia.Descargar_Imagen(imagen, idmaquina);
        }



    }

}
