namespace UI.Precio
{
    partial class frmPrecioFormulario
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
            this.LblProd = new System.Windows.Forms.Label();
            this.LblDesde = new System.Windows.Forms.Label();
            this.LblHasta = new System.Windows.Forms.Label();
            this.LblCosto = new System.Windows.Forms.Label();
            this.LblPrecio = new System.Windows.Forms.Label();
            this.CbProd = new System.Windows.Forms.ComboBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.TxtCosto = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblProd
            // 
            this.LblProd.AutoSize = true;
            this.LblProd.Location = new System.Drawing.Point(89, 74);
            this.LblProd.Name = "LblProd";
            this.LblProd.Size = new System.Drawing.Size(50, 13);
            this.LblProd.TabIndex = 0;
            this.LblProd.Text = "Producto";
            // 
            // LblDesde
            // 
            this.LblDesde.AutoSize = true;
            this.LblDesde.Location = new System.Drawing.Point(101, 108);
            this.LblDesde.Name = "LblDesde";
            this.LblDesde.Size = new System.Drawing.Size(38, 13);
            this.LblDesde.TabIndex = 1;
            this.LblDesde.Text = "Desde";
            // 
            // LblHasta
            // 
            this.LblHasta.AutoSize = true;
            this.LblHasta.Location = new System.Drawing.Point(101, 136);
            this.LblHasta.Name = "LblHasta";
            this.LblHasta.Size = new System.Drawing.Size(35, 13);
            this.LblHasta.TabIndex = 2;
            this.LblHasta.Text = "Hasta";
            // 
            // LblCosto
            // 
            this.LblCosto.AutoSize = true;
            this.LblCosto.Location = new System.Drawing.Point(102, 172);
            this.LblCosto.Name = "LblCosto";
            this.LblCosto.Size = new System.Drawing.Size(34, 13);
            this.LblCosto.TabIndex = 3;
            this.LblCosto.Text = "Costo";
            // 
            // LblPrecio
            // 
            this.LblPrecio.AutoSize = true;
            this.LblPrecio.Location = new System.Drawing.Point(99, 204);
            this.LblPrecio.Name = "LblPrecio";
            this.LblPrecio.Size = new System.Drawing.Size(37, 13);
            this.LblPrecio.TabIndex = 4;
            this.LblPrecio.Text = "Precio";
            // 
            // CbProd
            // 
            this.CbProd.FormattingEnabled = true;
            this.CbProd.Location = new System.Drawing.Point(145, 71);
            this.CbProd.Name = "CbProd";
            this.CbProd.Size = new System.Drawing.Size(159, 21);
            this.CbProd.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(145, 102);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 6;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(145, 136);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 7;
            // 
            // TxtCosto
            // 
            this.TxtCosto.Location = new System.Drawing.Point(145, 169);
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(100, 20);
            this.TxtCosto.TabIndex = 8;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(145, 201);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(100, 20);
            this.TxtPrecio.TabIndex = 9;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(145, 256);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(103, 23);
            this.BtnGuardar.TabIndex = 17;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            // 
            // frmPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 394);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.TxtPrecio);
            this.Controls.Add(this.TxtCosto);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.CbProd);
            this.Controls.Add(this.LblPrecio);
            this.Controls.Add(this.LblCosto);
            this.Controls.Add(this.LblHasta);
            this.Controls.Add(this.LblDesde);
            this.Controls.Add(this.LblProd);
            this.Name = "frmPrecio";
            this.Text = "frmPrecio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblProd;
        private System.Windows.Forms.Label LblDesde;
        private System.Windows.Forms.Label LblHasta;
        private System.Windows.Forms.Label LblCosto;
        private System.Windows.Forms.Label LblPrecio;
        private System.Windows.Forms.ComboBox CbProd;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.TextBox TxtCosto;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Button BtnGuardar;
    }
}