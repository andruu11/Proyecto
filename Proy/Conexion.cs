using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //referenciamos libreria de mysql

namespace Proy
{
    public class Conexion // clase de conexión
    {
        public static MySqlConnection ObtenerConexion() //metodo para conectar nuestra BD
        {
                MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=prueba_progra; Uid=root; pwd=;"); //referenciamos el servidor, nombredebasededatos,usuario,password
                conectar.Open();//metodo para iniciar conexion
                return conectar;//enviamos la conexion iniciada bajo los parametros indicados
       }
/* */
        public static string mensaje() { //metodo para comprobar la conexion
            try
            {
                ObtenerConexion();//referenciamos el conector de la BD
                return "La conexion es exitosa";//enviamos mensaje de conexion exitosa
            }
            catch(MySqlException exp) {//manejamos la excepcion
                return "La conexion ha fallado" + Convert.ToString(exp);//enviamos el mensaje de conexion fallida
               
            }
        }
/* */
    }
}
