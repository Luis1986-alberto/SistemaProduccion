using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aRodillo_CN
    {
        public static readonly PR_aRodillo_CN _Instancia = new PR_aRodillo_CN();

        public static PR_aRodillo_CN Instancia
        { get { return PR_aRodillo_CN._Instancia; } }


        public List<PR_aRodillos> Lista_Rodillos()
        { return PR_aRodillos_CD._Instancia.Lista_Rodillos().ToList(); }

        public IEnumerable<PR_aRodillos> TraerPorID(Int32 idrodillo)
        { return PR_aRodillos_CD._Instancia.Traer_PorIdRodillo(idrodillo); }

        public string Agregar_Rodillos(PR_aRodillos rodillos)
        {
            return PR_aRodillos_CD._Instancia.Agregar_Rodillo(rodillos);
        }

        public string Actualizar_Rodillos(PR_aRodillos rodillos)
        {
            return PR_aRodillos_CD._Instancia.Actualizar_Rodillo(rodillos);
        }

        public string Eliminar_Rodillos(Int32 idrodillo)
        {
            return PR_aRodillos_CD._Instancia.Eliminar_Rodillo(idrodillo);
        }


    }
}
