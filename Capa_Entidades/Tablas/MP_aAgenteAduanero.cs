using System;

namespace Capa_Entidades.Tablas
{
    public class MP_aAgenteAduanero
    {
        public Int32 IdAgenteAduanero { get; set; }
        public string Razon_Social_Agente { get; set; }
        public string Direccion_Agente { get; set; }
        public string Numero_RUC_Agente { get; set; }
        public string Numero_Telefono_Agente { get; set; }
        public string Numero_Celular_Agente { get; set; }
        public string Numero_Fax_Agente { get; set; }
        public string Correo_Agente { get; set; }

        public MP_aAgenteAduanero()
        { }

        public MP_aAgenteAduanero(int idAgenteAduanero, string razon_Social_Agente, string direccion_Agente, string numero_RUC_Agente,
                                  string numero_Telefono_Agente, string numero_Celular_Agente, string numero_Fax_Agente, string correo_Agente)
        {
            IdAgenteAduanero = idAgenteAduanero;
            Razon_Social_Agente = razon_Social_Agente;
            Direccion_Agente = direccion_Agente;
            Numero_RUC_Agente = numero_RUC_Agente;
            Numero_Telefono_Agente = numero_Telefono_Agente;
            Numero_Celular_Agente = numero_Celular_Agente;
            Numero_Fax_Agente = numero_Fax_Agente;
            Correo_Agente = correo_Agente;
        }


    }
}
