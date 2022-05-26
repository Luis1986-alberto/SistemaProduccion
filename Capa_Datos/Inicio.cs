using System;

namespace Capa_Datos
{
    public class Inicio
    {
        public Conexion MiConfiguracion = new Conexion();

        public string CadenaConexion { get; set; }
        public string NombreServidor { get; set; }
        public string BaseDatos { get; set; }
        public string IdUsuario { get; set; }

        public void LeerConfiguracion()
        {
            try
            {
                MiConfiguracion.LeerSecciones();
                CadenaConexion = MiConfiguracion.CadenaConexion;
                NombreServidor = MiConfiguracion.NombreServidor;
                BaseDatos = MiConfiguracion.BaseDatos;
                //CargaDatos();
            }
            catch (Exception Ex)
            {
                throw new Exception("error ", Ex);//MessageBox.Show("Error: {0}", Ex.ToString());
            }

        }
    }
}
