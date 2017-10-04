using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //importar la libreria de lo Forms y utilizar evento

namespace Proy
{
    class validar
    {
        public static void SoloNumeros(KeyPressEventArgs pE) {
            if (char.IsDigit(pE.KeyChar)) {
                pE.Handled = false;
            }
            else if(char.IsControl(pE.KeyChar)){
                pE.Handled = false;
            } else{
                pE.Handled = true;
            }
                                                             }
        public static void SoloLetras(KeyPressEventArgs pE){
            if (Char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            else
            {
                pE.Handled = true;
            }
                                                            }
        }
}
