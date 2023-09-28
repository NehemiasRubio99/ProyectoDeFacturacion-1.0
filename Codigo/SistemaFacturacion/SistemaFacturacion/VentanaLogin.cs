using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using miLibreria;


namespace SistemaFacturacion
{
    public partial class VentanaLogin : FormBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        public static String Codigo = "";
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = String.Format("Select * FROM Usuarios WHERE usuario='{0}' AND contraseña= '{1}'", txtUsu.Text.Trim(),txtContra.Text.Trim());
                DataSet ds = Utilidades.Ejecutar(CMD);

                string cuenta = ds.Tables[0].Rows[0]["usuario"].ToString().Trim();
                string contra = ds.Tables[0].Rows[0]["contraseña"].ToString().Trim();

                Codigo = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

                if(cuenta == txtUsu.Text.Trim() && contra== txtContra.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status_admin"].ToString().Trim()) == true)
                    {
                        VentanaAdmin ventAdm = new VentanaAdmin();
                        this.Hide();
                        ventAdm.Show();
                    }
                    else
                    {
                        VentanaUser ventUs = new VentanaUser();
                        this.Hide();
                        ventUs.Show();
                    }

                }
               


            }catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
                //MessageBox.Show("Usuario o contraseña INCORRECTA");
            }

        }

        

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
