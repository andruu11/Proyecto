using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//referenciamos libreria de mysql
using System.Collections;
using Proy.usuario;   
namespace Proy
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection(); //referenciamos el metodo de la libreria para una nueva conexion
        String variableconexion;//declaramos una variable para referenciar los parametros
        public Form1()
        {
            InitializeComponent();
            IniciarConexion();
            txtboxpas.PasswordChar = '*';
            
            
        }
        private void IniciarConexion() {
            try {
                variableconexion = ("Server=127.0.0.1; database=prueba_progra; Uid=root; pwd=;");//almacenamos los parametros de conexion
                conexion.ConnectionString = variableconexion; // igualamos nuestro string a un metodo de conexion en base a nuestra variable
                conexion.Open();//inicializamos la conexion
                MessageBox.Show("La conexion se ha realizado con exito");//mostramos mensaje de conexion exitosa
            }catch(MySqlException ex){
               MessageBox.Show("La conexion ha fallado, el error es" + ex);//mostramos el error
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            string msj = Conexion.mensaje();//invocamos el metodo de la clase
            MessageBox.Show(msj);//mostramos el mensaje respectivo
           
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = Usuario_insertar_SQL.ObtenerPrivilegio();
            comboBox1.DisplayMember = "des_privilegio";
            comboBox1.ValueMember = "id_privilegio";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            Usuario pusuario = new Usuario();
            pusuario.usuario = txtboxusuario.Text.Trim();
            string cadenaEncriptada = Encriptar.GetMD5(txtboxpas.Text);
            pusuario.password = cadenaEncriptada.Trim();
            pusuario.fecha_creacion = Convert.ToString(localDate);
            pusuario.id_privilegio = Convert.ToInt32(comboBox1.SelectedValue);
            if (Usuario_insertar_SQL.Agregar(pusuario) > 0) {
                MessageBox.Show("Usuario guardado con exito");
            }else{
                MessageBox.Show("No se pudo almacenar");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //CODIGO PARA CERRAR LA VENTANA
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //CODIGO PARA MINIMIZAR LA VENTANA
            WindowState = FormWindowState.Minimized;
        }

        private void txtboxusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void txtboxpas_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }
      

    }
}
