using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//referenciamos libreria de mysql
using System.Data;

namespace Proy.usuario
{
    class Usuario_insertar_SQL
    {
        public static int Agregar(Usuario pUsuario) {
            int retorno = 0;
            MySqlCommand consulta = new MySqlCommand(string.Format("INSERT INTO usuario (usuario, password, fecha_creacion, id_privilegio) VALUES ('{0}','{1}','{2}','{3}')", pUsuario.usuario, pUsuario.password, pUsuario.fecha_creacion, pUsuario.id_privilegio), Conexion.ObtenerConexion() );
            retorno = consulta.ExecuteNonQuery();
            return retorno;
        }

        public static List<Privilegio> ObtenerPrivilegio() //metodo de tipo lista
        {
            List<Privilegio> _lista = new List<Privilegio>(); //creamos la lista

            MySqlConnection conexion = Conexion.ObtenerConexion(); //establecemos conexion

            MySqlCommand _comando = new MySqlCommand("select id_privilegio , des_privilegio from privilegio", conexion); // enviamos la consulta
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Privilegio pPrivilegio = new Privilegio();

                pPrivilegio.id_privilegio = _reader.GetInt32(0);
                pPrivilegio.des_privilegio = _reader.GetString(1);

                _lista.Add(pPrivilegio);
            }

            return _lista;
        }

        public static int Autentificar(Usuario lUsuario)
        {
                    int resultado = 0; //declaramos la variable entera
                    try
                    {
                        MySqlCommand consultas = new MySqlCommand(string.Format("SELECT usuario, des_privilegio FROM usuario INNER JOIN privilegio ON usuario.id_privilegio = privilegio.id_privilegio WHERE usuario = '{0}' AND password = '{1}'", lUsuario.usuario, lUsuario.password), Conexion.ObtenerConexion()); // realizamos la consulta
                        MySqlDataAdapter consultas_ap = new MySqlDataAdapter(consultas); //puente entre dataset y mysql
                        DataTable dt = new DataTable(); // creamos data table
                        consultas_ap.Fill(dt);//ejecuta consulta
                        if (dt.Rows.Count == 1)
                        {
                             
                             if (dt.Rows[0][1].ToString() == "Admin")
                             {
                                 resultado = 3;
                             }
                             else if (dt.Rows[0][1].ToString() == "Usuario")
                             {
                                 resultado = 4;
                             }
                            
                        }
                        else {
                            resultado = 10;
                        }

                    }
                    catch { 
                    }
            return resultado;
                }
    }
}
