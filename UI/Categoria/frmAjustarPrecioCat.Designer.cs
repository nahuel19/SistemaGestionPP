namespace UI.Categoria
{
    partial class frmAjustarPrecioCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAjustarPrecioCat));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblPorcentajeAumento = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblNombreValue = new System.Windows.Forms.Label();
            this.lblTxtNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(185, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 196;
            this.label1.Text = "%";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.BackColor = System.Drawing.Color.White;
            this.txtPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentaje.ForeColor = System.Drawing.Color.DimGray;
            this.txtPorcentaje.Location = new System.Drawing.Point(98, 190);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(63, 19);
            this.txtPorcentaje.TabIndex = 194;
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(83, 181);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(93, 39);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 195;
            this.pictureBox2.TabStop = false;
            // 
            // lblPorcentajeAumento
            // 
            this.lblPorcentajeAumento.AutoSize = true;
            this.lblPorcentajeAumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPorcentajeAumento.ForeColor = System.Drawing.Color.DimGray;
            this.lblPorcentajeAumento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPorcentajeAumento.Location = new System.Drawing.Point(79, 157);
            this.lblPorcentajeAumento.Name = "lblPorcentajeAumento";
            this.lblPorcentajeAumento.Size = new System.Drawing.Size(154, 20);
            this.lblPorcentajeAumento.TabIndex = 193;
            this.lblPorcentajeAumento.Text = "Porcentaje Aumento";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(77, 350);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(349, 41);
            this.BtnGuardar.TabIndex = 191;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.BackColor = System.Drawing.Color.White;
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.ForeColor = System.Drawing.Color.DimGray;
            this.txtMotivo.Location = new System.Drawing.Point(92, 277);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(317, 19);
            this.txtMotivo.TabIndex = 189;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, 268);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 190;
            this.pictureBox1.TabStop = false;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMotivo.ForeColor = System.Drawing.Color.DimGray;
            this.lblMotivo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMotivo.Location = new System.Drawing.Point(84, 244);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(55, 20);
            this.lblMotivo.TabIndex = 188;
            this.lblMotivo.Text = "Motivo";
            // 
            // lblNombreValue
            // 
            this.lblNombreValue.AutoSize = true;
            this.lblNombreValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNombreValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNombreValue.Location = new System.Drawing.Point(89, 116);
            this.lblNombreValue.Name = "lblNombreValue";
            this.lblNombreValue.Size = new System.Drawing.Size(0, 20);
            this.lblNombreValue.TabIndex = 185;
            // 
            // lblTxtNombre
            // 
            this.lblTxtNombre.AutoSize = true;
            this.lblTxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTxtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.lblTxtNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTxtNombre.Location = new System.Drawing.Point(78, 92);
            this.lblTxtNombre.Name = "lblTxtNombre";
            this.lblTxtNombre.Size = new System.Drawing.Size(65, 20);
            this.lblTxtNombre.TabIndex = 184;
            this.lblTxtNombre.Text = "Nombre";
            // 
            // frmAjustarPrecioCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblPorcentajeAumento);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblNombreValue);
            this.Controls.Add(this.lblTxtNombre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAjustarPrecioCat";
            this.Text = "Ajuste Precio Categoría";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblPorcentajeAumento;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Label lblNombreValue;
        private System.Windows.Forms.Label lblTxtNombre;
    }
}