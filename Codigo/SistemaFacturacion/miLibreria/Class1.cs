using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace miLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(String cmd)
        {
            SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-IHCV84E\\SQLEXPRESS;Initial Catalog=Administracion;Integrated Security=True");
            Conexion.Open();

            DataSet DS = new DataSet();
            SqlDataAdapter DP = new SqlDataAdapter(cmd, Conexion);

            DP.Fill(DS);

            Conexion.Close();

            return DS;
        }

        public static Boolean ValidarFormulario(Control objeto, ErrorProvider errorProvider)
        {
            Boolean HayErrores = false;

            foreach(Control Item in objeto.Controls)
            {
                if (Item is ErrorTxtBox)
                {
                    ErrorTxtBox obj = (ErrorTxtBox)Item;

                    if(obj.Validar== true)
                    {
                        if (string.IsNullOrEmpty(obj.Text.Trim()))
                        {
                            errorProvider.SetError(obj, "No puede estar vacio");
                            HayErrores = true;
                        }
                    if(obj.SoloNumeros == true)
                     {
                            int cont = 0, LetrasEncontradas = 0;
                            foreach(char letra in obj.Text.Trim())
                            {
                                if (char.IsLetter(obj.Text.Trim(), cont))
                                {
                                    LetrasEncontradas++;
                                    cont++;
                                }
                            }

                            if (LetrasEncontradas != 0)
                            {
                                HayErrores = true;

                                errorProvider.SetError(obj, "Solo Numeros");
                            }
                     }
                    }
                }
            }

            return HayErrores;
        }

    }
}
