using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proy.usuario
{
    class Usuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string fecha_creacion { get; set; }
        public int id_privilegio { get; set; }

        public Usuario() { }

        public Usuario(int pid_usuario, string pusuario, string password, string fecha_creacion, int id_privilegio)
        {
            this.id_usuario = pid_usuario;
            this.usuario = pusuario;
            this.password = password;
            this.fecha_creacion = fecha_creacion;
            this.id_privilegio = id_privilegio;

        }
    }
   

}
