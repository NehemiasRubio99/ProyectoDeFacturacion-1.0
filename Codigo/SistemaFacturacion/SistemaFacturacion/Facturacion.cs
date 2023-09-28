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
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        
        private void Facturacion_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE id_usuario=" + VentanaLogin.Codigo;
            DataSet ds;

            ds = Utilidades.Ejecutar(cmd);

            lblVendedor.Text = ds.Tables[0].Rows[0]["nom_usu"].ToString().Trim();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(txtCodigoCli.Text.Trim()) == false)
                {
                    string cmd = string.Format("SELECT nom_clientes FROM Clientes WHERE id_clientes='{0}'", txtCodigoCli.Text.Trim());

                    DataSet ds = Utilidades.Ejecutar(cmd);

                    txtCliente.Text = ds.Tables[0].Rows[0]["nom_clientes"].ToString().Trim();

                    txtCodPro.Focus();

                }
            } catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error);
            }
            
        }
        public static int cont_fila = 0;
        public static double total;

        private void btnColocar_Click(object sender, EventArgs e)
        {
            
            if (Utilidades.ValidarFormulario(this, errorProvider1) == false)
            {
                bool existe = false;

                int num_fila = 0;


                //Agregar cuando la tabla está vacia
                
                if (cont_fila == 0)
                {
                    
                    dataGridView1.Rows.Add(txtCodPro.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text);

                    double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);

                    dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                    cont_fila++;

                }
                
                else
                {
                    
                    //Comprobar a que fila corresponde el producto
                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        if (Fila.Cells[0].Value.ToString() == txtCodPro.Text)
                        {
                            existe = true;

                            num_fila = Fila.Index;
                            
                        }
                    }
                    if (existe == true)
                    {
                        dataGridView1.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();

                        double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value);

                        dataGridView1.Rows[num_fila].Cells[4].Value = importe;

                    }

                    else
                    {
                        
                        dataGridView1.Rows.Add(txtCodPro.Text, txtDescripcion.Text, txtPrecio.Text, txtCantidad.Text);

                        double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);

                        dataGridView1.Rows[cont_fila].Cells[4].Value = importe;

                        cont_fila++;

                       

                    }
                }

                total = 0;

                //Calcular el total
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    total += Convert.ToDouble(fila.Cells[4].Value); 
                }

                lblTotal.Text = "$ " + total.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cont_fila > 0)
            {
                total = total - (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));

                lblTotal.Text = "$ " + total.ToString();

                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

                cont_fila--;

            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ConsultarClientes ConCli = new ConsultarClientes();

            ConCli.ShowDialog();

            if(ConCli.DialogResult== DialogResult.OK)
            {
                txtCodigoCli.Text = ConCli.dataGridView1.Rows[ConCli.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtCliente.Text= ConCli.dataGridView1.Rows[ConCli.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtCodPro.Focus();
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ConsultarProductos ConPro = new ConsultarProductos();

            ConPro.ShowDialog();

            if (ConPro.DialogResult== DialogResult.OK)
            {
                txtCodPro.Text = ConPro.dataGridView1.Rows[ConPro.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtDescripcion.Text = ConPro.dataGridView1.Rows[ConPro.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtPrecio.Text = ConPro.dataGridView1.Rows[ConPro.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                txtCantidad.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();

        }

        public override void Nuevo()
        {
            txtCodigoCli.Text = "";
            txtCliente.Text = "";
            txtCodPro.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            lblTotal.Text = "$ 0";
            dataGridView1.Rows.Clear();
            cont_fila = 0;
            total = 0;
            txtCodigoCli.Focus();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (cont_fila != 0)
            {
                try
                {
                    string cmd = string.Format("Exec ActualizaFacturas '{0}'", txtCodigoCli.Text.Trim());

                    DataSet ds = Utilidades.Ejecutar(cmd);

                    string NumFac = ds.Tables[0].Rows[0]["NumFac"].ToString().Trim();

                    foreach (DataGridViewRow Fila in dataGridView1.Rows)
                    {
                        cmd = string.Format("Exec ActualizaDetalles '{0}','{1}','{2}','{3}'", NumFac, Fila.Cells[0].Value.ToString(), Fila.Cells[2].Value.ToString(), Fila.Cells[3].Value.ToString());
                        ds = Utilidades.Ejecutar(cmd);


                    }
                    
                    cmd="Exec DatosFactura "+ NumFac;
                    ds = Utilidades.Ejecutar(cmd);

                    //VENTANA REPORTE

                    Reporte rp = new Reporte();
                    rp.reportViewer1.LocalReport.DataSources[0].Value = ds.Tables[0];

                    rp.ShowDialog();

                    Nuevo();


                }catch(Exception error)
                {
                    MessageBox.Show("Error: " + error.Message);
                }



            }
        }
    }
}
