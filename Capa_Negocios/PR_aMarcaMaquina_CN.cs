using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aMarcaMaquina_CN
    {
        public static readonly PR_aMarcaMaquina_CN _Instancia = new PR_aMarcaMaquina_CN();

        public static PR_aMarcaMaquina_CN Instancia
        { get { return PR_aMarcaMaquina_CN._Instancia; } }

        public List<PR_aMarcaMaquina> Lista_MarcaMaquina()
        { return PR_aMarcaMaquina_CD._Instancia.Lista_MarcaMaquina().ToList(); }

        public IEnumerable<PR_aMarcaMaquina> TraerPorID(Int32 id)
        { return PR_aMarcaMaquina_CD._Instancia.Traer_MarcaMaquinaPorId(id); }

        public IEnumerable<PR_aMarcaMaquina> Buscar_MarcaMaquina(string marcamaquina)
        {
            var lista = PR_aMarcaMaquina_CD._Instancia.Lista_MarcaMaquina().ToList();
            return from buscar in lista where buscar.Descripcion_MarcaMaquina == marcamaquina select buscar;
        }

        public string Agregar_MarcaMaquina(PR_aMarcaMaquina marcamaquina)
        {
            if (Buscar_MarcaMaquina(marcamaquina.Descripcion_MarcaMaquina).Count() > 0) return "Existe una Marca Maquina Registrado";
            return PR_aMarcaMaquina_CD._Instancia.Agregar_MarcaMaquina(marcamaquina);
        }

        public string Actualizar_MarcaMaquina(PR_aMarcaMaquina marcamaquina)
        {
            if (Buscar_MarcaMaquina(marcamaquina.Descripcion_MarcaMaquina).Count() > 0) return "Existe una Marca Maquina Registrado";
            return PR_aMarcaMaquina_CD._Instancia.Actualizar_MarcaMaquina(marcamaquina);
        }

        public string Eliminar_MarcaMaquina(Int32 idmarcamaquina)
        { return PR_aMarcaMaquina_CD._Instancia.Eliminar_MarcaMaquina(idmarcamaquina); }

    }
}
