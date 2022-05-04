using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aPosicionTaca_CN
    {
        public static readonly PR_aPosicionTaca_CN _Instancia = new PR_aPosicionTaca_CN();

        public static PR_aPosicionTaca_CN Instancia
        { get { return PR_aPosicionTaca_CN._Instancia; } }

        public List<PR_aPosicionTaca>Lista_PosicionTaca()
        { return PR_aPosicionTaca_CD._Instancia.Lista_PosicionTaca().ToList(); }

        public List<PR_aPosicionTaca>Lista_TraerPorId(byte idposiciontaca) 
        { return PR_aPosicionTaca_CD._Instancia.Traer_PosicionTacaPorID(idposiciontaca).ToList(); }

        public IEnumerable<PR_aPosicionTaca> Buscar_PosicionTaca(string posiciontaca)
        {
            var lista= PR_aPosicionTaca_CD._Instancia.Lista_PosicionTaca().ToList();
            return from buscar in lista where buscar.Posicion_Taca == posiciontaca select buscar;
        }

        public string Agregar(PR_aPosicionTaca posiciontaca)
        {
            if (Buscar_PosicionTaca(posiciontaca.Posicion_Taca).Count() > 0) return "EXISTE LA POSICION REGISTRADA";
            return PR_aPosicionTaca_CD._Instancia.Agregar_PosicionTaca(posiciontaca);
        }

        public string Actualizar(PR_aPosicionTaca posiciontaca)
        {
            if (Buscar_PosicionTaca(posiciontaca.Posicion_Taca).Count() > 0) return "EXISTE LA POSICION REGISTRADA";
            return PR_aPosicionTaca_CD._Instancia.Actualizar_PosicionTaca(posiciontaca);
        }

        public string Eliminar(byte idposiciontaca)
        {
            return PR_aPosicionTaca_CD._Instancia.Eliminar_PosicionTaca(idposiciontaca);
        }

    }
}
