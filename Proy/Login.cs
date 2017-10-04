using Proy.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proy
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Usuario lusuario = new Usuario();
            lusuario.usuario = txtusuario.Text.Trim();
            string cadenaEncriptada = Encriptar.GetMD5(txtpass.Text);
            lusuario.password = cadenaEncriptada.Trim();
            if (Usuario_insertar_SQL.Autentificar(lusuario) == 3)
            {
                this.Hide();
                Form1 form_admin = new Form1();
                form_admin.ShowDialog();
            }
            else if (Usuario_insertar_SQL.Autentificar(lusuario) == 4)
            {
                this.Hide();
                Form2 form_usuario = new Form2();
                form_usuario.ShowDialog();
            }
            else if (Usuario_insertar_SQL.Autentificar(lusuario) == 10)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
