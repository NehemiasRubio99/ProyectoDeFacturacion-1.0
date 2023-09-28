
namespace SistemaFacturacion
{
    partial class MantenimientoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtApeCli = new miLibreria.ErrorTxtBox();
            this.txtNomCli = new miLibreria.ErrorTxtBox();
            this.txtIdCli = new miLibreria.ErrorTxtBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(589, 40);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(589, 82);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(589, 124);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 167);
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.Location = new System.Drawing.Point(589, 210);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Codigo:";
            // 
            // txtApeCli
            // 
            this.txtApeCli.Location = new System.Drawing.Point(116, 187);
            this.txtApeCli.Name = "txtApeCli";
            this.txtApeCli.Size = new System.Drawing.Size(275, 20);
            this.txtApeCli.SoloNumeros = false;
            this.txtApeCli.TabIndex = 27;
            this.txtApeCli.Validar = true;
            // 
            // txtNomCli
            // 
            this.txtNomCli.Location = new System.Drawing.Point(116, 136);
            this.txtNomCli.Name = "txtNomCli";
            this.txtNomCli.Size = new System.Drawing.Size(275, 20);
            this.txtNomCli.SoloNumeros = false;
            this.txtNomCli.TabIndex = 26;
            this.txtNomCli.Validar = true;
            // 
            // txtIdCli
            // 
            this.txtIdCli.Location = new System.Drawing.Point(116, 82);
            this.txtIdCli.Name = "txtIdCli";
            this.txtIdCli.Size = new System.Drawing.Size(275, 20);
            this.txtIdCli.SoloNumeros = true;
            this.txtIdCli.TabIndex = 25;
            this.txtIdCli.Validar = true;
            this.txtIdCli.TextChanged += new System.EventHandler(this.txtIdCli_TextChanged);
            // 
            // MantenimientoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(754, 293);
            this.Controls.Add(this.txtApeCli);
            this.Controls.Add(this.txtNomCli);
            this.Controls.Add(this.txtIdCli);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MantenimientoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MantenimientoCliente";
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtIdCli, 0);
            this.Controls.SetChildIndex(this.txtNomCli, 0);
            this.Controls.SetChildIndex(this.txtApeCli, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private miLibreria.ErrorTxtBox txtIdCli;
        private miLibreria.ErrorTxtBox txtNomCli;
        private miLibreria.ErrorTxtBox txtApeCli;
    }
}