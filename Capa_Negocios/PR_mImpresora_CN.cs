using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_mImpresora_CN
    {
        public static readonly PR_mImpresora_CN _Instancia = new PR_mImpresora_CN();

        public static PR_mImpresora_CN Instancia
        { get { return PR_mImpresora_CN._Instancia; } }


        public List<PR_mImpresora> Lista_Impresora()
        { return PR_mImpresora_CD._Instancia.Listar().ToList(); }

        public IEnumerable<PR_mImpresora> TraerID(byte idimpresora)
        { return PR_mImpresora_CD._Instancia.TraerPorId(idimpresora); }

        public IEnumerable<PR_mImpresora> Buscar_idmaquinaidrodillo(Int32 idmaquina, Int32 idrodillo)
        {
            var lista = PR_mImpresora_CD._Instancia.Listar();
            return from Buscar in lista where Buscar.IdMaquina == idmaquina && Buscar.IdRodillo == idrodillo select Buscar;
        }

        public string Agregar_Impresora(PR_mImpresora impresora)
        {
            if (Buscar_idmaquinaidrodillo(impresora.IdMaquina, impresora.IdRodillo).Count() > 0) return "Existe impresora y Rodillo Registrado";
            return PR_mImpresora_CD._Instancia.Agregar(impresora);
        }

        public string Actualizar_Impresora(PR_mImpresora impresora)
        {
            if (Buscar_idmaquinaidrodillo(impresora.IdMaquina, impresora.IdRodillo).Count() > 0) return "Existe impresora y Rodillo Registrado";
            return PR_mImpresora_CD._Instancia.Actualizar(impresora);
        }

        public string Eliminar_Impresora(Int32 idcondicioncobranza)
        { return LG_aCondicionCobranza_CD._Instancia.Eliminar(idcondicioncobranza); }




    }
}
