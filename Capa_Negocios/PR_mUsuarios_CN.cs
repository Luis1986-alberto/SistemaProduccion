using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_mUsuarios_CN
    {
        public static readonly PR_mUsuarios_CN _Instancia = new PR_mUsuarios_CN();

        public static PR_mUsuarios_CN Instancia
        { get { return PR_mUsuarios_CN._Instancia; } }


        public List<PR_mUsuarios> Lista_Usuarios()
        {
            return PR_mUsuarios_CD.Instancia.Lista_Usuarios().ToList();
        }

        public PR_mUsuarios TraerPorId(string idusuario)
        {
            return PR_mUsuarios_CD.Instancia.TraerPorIdUsuarios(idusuario);
        }

        public string Agregar_Usuario(PR_mUsuarios usuarios)
        {
            if (PR_mUsuarios_CD.Instancia.Lista_Usuarios().Count() > 0) return "YA EXISTE ESTE USUARIO";
            return PR_mUsuarios_CD._Instancia.Agregar_Usuario(usuarios);
        }

        public string Actualizar_Usuario(PR_mUsuarios usuarios)
        {
            return PR_mUsuarios_CD._Instancia.Actualizar_Usuario(usuarios);
        }

        public string Eliminar_Usuario(string idusuario)
        {
            //var lista = PR_mMaquina_CD.Instancia.Listar();
            //if ((from Buscar in lista where Buscar.IdProveedor == idproveedor select Buscar).Count() > 0) return "EXISTE MAQUINAS DE ESTE PROVEEDOR";
            return PR_mUsuarios_CD._Instancia.Eliminar_Usuario(idusuario);
        }



    }
}
