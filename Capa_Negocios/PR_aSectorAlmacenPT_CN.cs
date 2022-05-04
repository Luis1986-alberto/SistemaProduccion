using Capa_Datos.Repositorio;
using Capa_Entidades.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capa_Negocios
{
    public class PR_aSectorAlmacenPT_CN
    {
        public static readonly PR_aSectorAlmacenPT_CN _Instancia = new PR_aSectorAlmacenPT_CN();

        public static PR_aSectorAlmacenPT_CN Instancia
        { get { return PR_aSectorAlmacenPT_CN._Instancia; } }

        public List<PR_aSectorAlmacenPT> Lista_SectorAlmacen()
        { return PR_aSectorAlmacenPT_CD._Instancia.Lista_SectorAlmacen().ToList(); }

        public IEnumerable<PR_aSectorAlmacenPT> TraerPorID(Int32 id)
        { return PR_aSectorAlmacenPT_CD._Instancia.Traer_SectorAlmacenPorId(id); }

        public IEnumerable<PR_aSectorAlmacenPT> Buscar_CodigoSector(string codigosector)
        {
            var lista = PR_aSectorAlmacenPT_CD._Instancia.Lista_SectorAlmacen().ToList();
            return from buscar in lista where buscar.Codigo_Sector == codigosector select buscar;
        }

        public string Agregar_SectorAlmacenPT(PR_aSectorAlmacenPT sectoralmacenpt)
        {
            if (Buscar_CodigoSector(sectoralmacenpt.Codigo_Sector).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aSectorAlmacenPT_CD._Instancia.Agregar_SectorAlmacen(sectoralmacenpt);
        }

        public string Actualizar_SectorAlmacenPT(PR_aSectorAlmacenPT sectoralmacenpt)
        {
            if (Buscar_CodigoSector(sectoralmacenpt.Codigo_Sector).Count() > 0) return "Existe una linea Color Registrado";
            return PR_aSectorAlmacenPT_CD._Instancia.Actualizar_SectorAlmacen(sectoralmacenpt);
        }

        public string Eliminar_SectorAlmacenPT(Int32 idsector)
        { return PR_aSectorAlmacenPT_CD._Instancia.Eliminar_SectorAlmacen(idsector); }

    }
}
