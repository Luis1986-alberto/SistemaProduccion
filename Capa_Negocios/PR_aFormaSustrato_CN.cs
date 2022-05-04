using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aFormaSustrato_CN
    {
        public static readonly PR_aFormaSustrato_CN _Instancia = new PR_aFormaSustrato_CN();

        public static PR_aFormaSustrato_CN Instancia
        { get { return PR_aFormaSustrato_CN._Instancia; } }

        public List<PR_aFormaSustrato> Lista_FormaSustrato()
        { return PR_aFormaSustrato_CD._Instancia.Lista_FormaSustrato().ToList(); }

        public IEnumerable<PR_aFormaSustrato> TraerPorID(Int32 id)
        { return PR_aFormaSustrato_CD._Instancia.Traer_FormaSustratoPorId(id); }
        public IEnumerable<PR_aFormaSustrato> Buscar_DescripcionForma(string descripcionforma)
        {
            var LST = PR_aFormaSustrato_CD._Instancia.Lista_FormaSustrato().ToList();
            return from buscar in LST where buscar.Descripcion_Forma == descripcionforma select buscar;
        }

        public string Agregar_FormaSustrato(PR_aFormaSustrato formasustrato)
        {
            if (Buscar_DescripcionForma(formasustrato.Descripcion_Forma).Count() > 0) return "Existe una forma Sustrato Registrado";
            return PR_aFormaSustrato_CD._Instancia.Agregar_FormaSustrato(formasustrato);
        }

        public string Actualizar_FormaSustrato(PR_aFormaSustrato formasustrato)
        {
            if (Buscar_DescripcionForma(formasustrato.Descripcion_Forma).Count() > 0) return "Existe una forma Sustrato Registrado";
            return PR_aFormaSustrato_CD._Instancia.Actualizar_FormaSustrato(formasustrato);
        }

        public string Eliminar_FormaSustrato(Int32 idformasustrato)
        { return PR_aFormaSustrato_CD._Instancia.Eliminar_FormaSustrato(idformasustrato); }


    }
}
