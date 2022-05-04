using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aGrupo_CN
    {
        public static readonly LG_aGrupo_CN _Instancia = new LG_aGrupo_CN();

        public static LG_aGrupo_CN Instancia
        { get { return LG_aGrupo_CN._Instancia; } }

        public List<LG_aGrupo> Lista_Grupos()
        { return LG_aGrupo_CD._Instancia.Lista_Grupos().ToList(); }

        public LG_aGrupo traerPorID(int idestadosolicitud)
        { return LG_aGrupo_CD._Instancia.TraerPorIdGrupos(idestadosolicitud); }

        public IEnumerable<LG_aGrupo> Buscar_EstadoSolicitud(string nombregrupo)
        {
            var lst = LG_aGrupo_CD._Instancia.Lista_Grupos();
            return from GRP in lst where GRP.Nombre_Grupo == nombregrupo select GRP;
        }

        public string Agregar(LG_aGrupo grupos)
        {
            if (Buscar_EstadoSolicitud(grupos.Nombre_Grupo).ToList().Count > 0) return "YA EXISTE GRUPO ";
            return LG_aGrupo_CD._Instancia.Agregar_Grupos(grupos);
        }

        public String Actualizar(LG_aGrupo grupos)
        {
            if (Buscar_EstadoSolicitud(grupos.Nombre_Grupo).ToList().Count > 0) return "YA EXISTE GRUPO ";
            return LG_aGrupo_CD._Instancia.Actualizar_Grupos(grupos);
        }

        public string Eliminar(Int32 idgrupo)
        {
            return LG_aGrupo_CD._Instancia.Eliminar_Grupos(idgrupo);
        }

    }
}
