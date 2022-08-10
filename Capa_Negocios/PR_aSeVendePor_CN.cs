using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class PR_aSeVendePor_CN
    {
        public static readonly PR_aSeVendePor_CN Instancia = new PR_aSeVendePor_CN();

        public static PR_aSeVendePor_CN _Instancia
        { get { return PR_aSeVendePor_CN.Instancia; } }

        public List<PR_aSeVendePor>Lista_SeVendePor()
        { return PR_aSeVendePor_CD.Instancia.Lista_seVendePor().ToList(); }

        public PR_aSeVendePor TraerPor_Id(byte idsevendepor)
        { return PR_aSeVendePor_CD.Instancia.TraerPor_IdSeVendePor(idsevendepor); }

        public IEnumerable<PR_aSeVendePor> Buscar_Descripcion(string sevende_por)
        {
            var lst = PR_aSeVendePor_CD._Instancia.Lista_seVendePor().ToList();
            return from CON in lst where CON.SeVende_Por == sevende_por select CON;
        }

        public string Agregar(PR_aSeVendePor sevendepor)
        {
            if (Buscar_Descripcion(sevendepor.SeVende_Por).ToList().Count() > 0) return "YA EXISTE REGISTRADO ";
            return PR_aSeVendePor_CD.Instancia.Agregar_SeVende_Por(sevendepor);
        }

        public string Actualizar(PR_aSeVendePor sevendepor)
        {
            if (Buscar_Descripcion(sevendepor.SeVende_Por).ToList().Count() > 0) return "YA EXISTE REGISTRADO ";
            return PR_aSeVendePor_CD.Instancia.Actualizar_SeVende_Por(sevendepor);
        }

        public string Eliminar(byte idsevendepor)
        {
            return PR_aSeVendePor_CD.Instancia.Eliminar_SeVende_Por(idsevendepor);
        }


    }
}
