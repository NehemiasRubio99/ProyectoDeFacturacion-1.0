using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using miLibreria;
namespace SistemaFacturacion
{
    public partial class VentanaUser : FormBase
    {
        public VentanaUser()
        {
            InitializeComponent();
        }

        private void VentanaUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        private void VentanaUser_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE id_usuario= " + VentanaLogin.Codigo;

            DataSet DS = Utilidades.Ejecutar(cmd);

            lblNameUs.Text = DS.Tables[0].Rows[0]["nom_usu"].ToString();
            lblUsUs.Text = DS.Tables[0].Rows[0]["usuario"].ToString();
            lblCodUs.Text = DS.Tables[0].Rows[0]["id_usuario"].ToString();

            string url = DS.Tables[0].Rows[0]["foto"].ToString();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal ConP = new ContenedorPrincipal();
            this.Hide();
            ConP.Show();
        }
    }
}
