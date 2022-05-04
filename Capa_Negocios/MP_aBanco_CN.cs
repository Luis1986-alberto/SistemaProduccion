using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class MP_aBanco_CN
    {
        public static readonly MP_aBanco_CN _Instancia = new MP_aBanco_CN();

        public static MP_aBanco_CN Instancia
        { get { return MP_aBanco_CN._Instancia; } }


        public List<MP_aBanco>Lista_Bancos()
        { return MP_aBanco_CD._Instancia.Lista_Bancos().ToList(); }

        public IEnumerable<MP_aBanco>TraerPorId(Int32 idbanco)
        { return MP_aBanco_CD._Instancia.Traer_BancoPorId(idbanco); }

        public IEnumerable<MP_aBanco>Buscar_NombreBanco(string nombrebanco)
        {
            var lista = MP_aBanco_CD._Instancia.Lista_Bancos();
            return from BAN in lista where BAN.Nombre_Banco == nombrebanco select BAN;
        }

        public string Agregar(MP_aBanco banco)
        {
            if (Buscar_NombreBanco(banco.Nombre_Banco).Count() > 0) return "YA EXISTE ESTE BANCO REGISTRADO";
            return MP_aBanco_CD._Instancia.Agregar_Banco(banco);
        }

        public string Actualizar(MP_aBanco banco)
        {
            if (Buscar_NombreBanco(banco.Nombre_Banco).Count() > 0) return "YA EXISTE ESTE BANCO REGISTRADO";
            return MP_aBanco_CD._Instancia.Actualizar_Banco(banco);
        }

        public string Elilminar(Int32 idbanco)
        {
            return MP_aBanco_CD._Instancia.Eliminar_Banco(idbanco);
        }



    }
}
