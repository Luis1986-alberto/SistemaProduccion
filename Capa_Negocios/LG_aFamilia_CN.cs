using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocios
{
    public class LG_aFamilia_CN
    {
        public static readonly LG_aFamilia_CN _Instancia = new LG_aFamilia_CN();

        public static LG_aFamilia_CN Instancia
        { get { return LG_aFamilia_CN._Instancia; } }

        public List<LG_aFamilia> Lista_Familia()
        { return LG_aFamilia_CD._Instancia.Lista_Familia().ToList(); }

        public LG_aFamilia traerPorID(Int32 idfamilia)
        { return LG_aFamilia_CD._Instancia.TraerporIDFamilia(idfamilia); }

        public IEnumerable<LG_aFamilia> Buscar_NombreFamilia(string nombrefamilia)
        {
            var lst = LG_aFamilia_CD._Instancia.Lista_Familia();
            return from FAM in lst where FAM.Nombre_Familia == nombrefamilia select FAM;
        }

        public string Agregar(LG_aFamilia familia)
        {
            if (Buscar_NombreFamilia(familia.Nombre_Familia).ToList().Count > 0) return "YA EXISTE NOMBRE FAMILIA ";
            return LG_aFamilia_CD._Instancia.Agregar_Familia(familia);
        }

        public String Actualizar(LG_aFamilia familia)
        {
            if (Buscar_NombreFamilia(familia.Nombre_Familia).ToList().Count > 0) return "YA EXISTE EL NOMBRE FAMILIA";
            return LG_aFamilia_CD._Instancia.Actualizar_Familia(familia);
        }

        public string Eliminar(Int32 idfamilia)
        {
            return LG_aFamilia_CD._Instancia.Eliminar_Familia(idfamilia);
        }



    }
}
