using System;

namespace Capa_Datos
{
    public class Conexion
    {
        public Cls_Configuracion_INI MiConfiguracion_INI = new Cls_Configuracion_INI();
        public cls_Configuracion_Proyecto MiConfiguracion_Proyecto = new cls_Configuracion_Proyecto();

        public string CadenaConexion { get; set; }
        public string NombreServidor { get; set; }
        public string BaseDatos { get; set; }

        public string Ruta, Valor;
        public byte Proyecto;


        public void LeerSecciones()
        {
            try
            {
                Ruta = MiConfiguracion_Proyecto.Ubicacion_Archivo_Ini();
                //byt_Proyecto = MiConfiguracion_Proyecto.Proyecto_INI();
                Proyecto = 1;

                MiConfiguracion_Proyecto.Servidor_MTS = MiConfiguracion_INI.IniGet(Ruta, Proyecto.ToString(), "Servidor_MTS", Valor);
                MiConfiguracion_Proyecto.Servidor_SQL = MiConfiguracion_INI.IniGet(Ruta, Proyecto.ToString(), "Servidor_SQL", "");
                MiConfiguracion_Proyecto.BDatos = MiConfiguracion_INI.IniGet(Ruta, Proyecto.ToString(), "BDatos", "");

                CadenaConexion = string.Concat("Data Source =", MiConfiguracion_Proyecto.Servidor_SQL, "; Initial Catalog =", MiConfiguracion_Proyecto.BDatos, "; Integrated Security=True");
                NombreServidor = string.Concat(MiConfiguracion_Proyecto.Servidor_SQL);
                BaseDatos = string.Concat(MiConfiguracion_Proyecto.BDatos);
                //ID = miUsuario; Password = miConstraseña

                //MessageBox.Show("Ruta de MTS: " + MiConfiguracion_Proyecto.Servidor_MTS, "Servidor MTS", MessageBoxButtons.OK);
                //MessageBox.Show("Ruta de SQL: " + MiConfiguracion_Proyecto.Servidor_SQL, "Servidor SQL", MessageBoxButtons.OK);
                //MessageBox.Show("Nombre del Equipo : " + Environment.MachineName);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: {0}", Ex);
            }
        }
    }
}
