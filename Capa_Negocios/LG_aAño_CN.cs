using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class LG_aAño_CN
    {
        public static readonly LG_aAño_CN _Instancia = new LG_aAño_CN();

        public static LG_aAño_CN Instancia
        { get { return LG_aAño_CN._Instancia; } }

        public List<LG_aAño> Lista_Años()
        { return LG_aAño_CD._Instancia.Lista_aAños().ToList(); }

        public IEnumerable<LG_aAño> TraerID(byte idaño)
        { return LG_aAño_CD._Instancia.Traer_AñoPorId(idaño); }

        public IEnumerable<LG_aAño> Buscar_Año(Int32 año)
        {
            var lst = LG_aAño_CD._Instancia.Lista_aAños().ToList();
            return from A in lst where A.Año == año select A;
        }

        public string Agregar_Año(LG_aAño año)
        {
            if (Buscar_Año(año.Año).Count() > 0) return "Existe Año Registrado";
            return LG_aAño_CD._Instancia.Agregar_Año(año);
        }

        public string Actualizar_Año(LG_aAño año)
        {
            if (Buscar_Año(año.Año).Count() > 0) return "Existe Año Registrado";
            return LG_aAño_CD._Instancia.Actualizar_Año(año);
        }

        public string Eliminar_Año(Int32 idaño)
        { return LG_aAño_CD._Instancia.Eliminar_Año(idaño); }



    }
}
