using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aEstado_OP_CN
    {
        public static readonly PR_aEstado_OP_CN _Instancia = new PR_aEstado_OP_CN();

        public static PR_aEstado_OP_CN Instancia
        { get { return PR_aEstado_OP_CN._Instancia; } }

        public List<PR_aEstado_OP> Lista_Estado_OP()
        { return PR_aEstado_OP_CD._Instancia.Lista_EstadoOP().ToList(); }

        public IEnumerable<PR_aEstado_OP> TraerPorID(byte id)
        { return PR_aEstado_OP_CD._Instancia.Traer_EstadoOPPorId(id); }

        public IEnumerable<PR_aEstado_OP> Buscar_DescripcionOP(string descripcionop)
        {
            var lst = PR_aEstado_OP_CD._Instancia.Lista_EstadoOP().ToList();
            return from AD in lst where AD.Descripcion_EstadoOP == descripcionop select AD;
        }

        public string Agregar_EstadoOP(PR_aEstado_OP estadoop)
        {
            if (Buscar_DescripcionOP(estadoop.Descripcion_EstadoOP).Count() > 0) return "Existe un Estado OP Registrado";
            return PR_aEstado_OP_CD._Instancia.Agregar_Estado_OP(estadoop);
        }

        public string Actualizar_EstadoOP(PR_aEstado_OP estadoop)
        {
            if (Buscar_DescripcionOP(estadoop.Descripcion_EstadoOP).Count() > 0) return "Existe un Estado Registrado";
            return PR_aEstado_OP_CD._Instancia.Actualizar_EstadoOP(estadoop);
        }

        public string Eliminar_Estado(Int32 idestadoop)
        { return PR_aEstado_OP_CD._Instancia.Eliminar_EstadoOP(idestadoop); }


    }
}
