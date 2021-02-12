namespace UI.Presupuesto
{
    partial class frmPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresupuesto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloPresupuesto = new System.Windows.Forms.Label();
            this.btnPDF = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelecProducto = new System.Windows.Forms.Button();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.btnQuitarProdLista = new System.Windows.Forms.Button();
            this.btnAgregarProdALista = new System.Windows.Forms.Button();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblTotValue = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblTituloPresupuesto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 103);
            this.panel1.TabIndex = 112;
            // 
            // lblTituloPresupuesto
            // 
            this.lblTituloPresupuesto.AutoSize = true;
            this.lblTituloPresupuesto.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPresupuesto.ForeColor = System.Drawing.Color.DimGray;
            this.lblTituloPresupuesto.Location = new System.Drawing.Point(32, 31);
            this.lblTituloPresupuesto.Name = "lblTituloPresupuesto";
            this.lblTituloPresupuesto.Size = new System.Drawing.Size(469, 40);
            this.lblTituloPresupuesto.TabIndex = 74;
            this.lblTituloPresupuesto.Text = "GENERAR PRESUPUESTO";
            // 
            // btnPDF
            // 
            this.btnPDF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPDF.BackColor = System.Drawing.Color.IndianRed;
            this.btnPDF.FlatAppearance.BorderSize = 0;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.ForeColor = System.Drawing.Color.White;
            this.btnPDF.Location = new System.Drawing.Point(805, 134);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(91, 41);
            this.btnPDF.TabIndex = 119;
            this.btnPDF.Text = "PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.DimGray;
            this.txtCantidad.Location = new System.Drawing.Point(419, 150);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(63, 19);
            this.txtCantidad.TabIndex = 158;
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCant.ForeColor = System.Drawing.Color.DimGray;
            this.lblCant.Location = new System.Drawing.Point(414, 119);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(73, 20);
            this.lblCant.TabIndex = 156;
            this.lblCant.Text = "Cantidad";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(405, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 159;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelecProducto
            // 
            this.btnSelecProducto.BackColor = System.Drawing.Color.Teal;
            this.btnSelecProducto.FlatAppearance.BorderSize = 0;
            this.btnSelecProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecProducto.ForeColor = System.Drawing.Color.White;
            this.btnSelecProducto.Location = new System.Drawing.Point(336, 148);
            this.btnSelecProducto.Name = "btnSelecProducto";
            this.btnSelecProducto.Size = new System.Drawing.Size(39, 26);
            this.btnSelecProducto.TabIndex = 155;
            this.btnSelecProducto.Text = "...";
            this.btnSelecProducto.UseVisualStyleBackColor = false;
            this.btnSelecProducto.Click += new System.EventHandler(this.btnSelecProducto_Click);
            // 
            // TxtProducto
            // 
            this.TxtProducto.BackColor = System.Drawing.Color.White;
            this.TxtProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProducto.ForeColor = System.Drawing.Color.DimGray;
            this.TxtProducto.Location = new System.Drawing.Point(49, 150);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(260, 19);
            this.TxtProducto.TabIndex = 153;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(34, 141);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(292, 39);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 154;
            this.pictureBox10.TabStop = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducto.ForeColor = System.Drawing.Color.DimGray;
            this.lblProducto.Location = new System.Drawing.Point(44, 120);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(73, 20);
            this.lblProducto.TabIndex = 152;
            this.lblProducto.Text = "Producto";
            // 
            // btnQuitarProdLista
            // 
            this.btnQuitarProdLista.BackColor = System.Drawing.Color.Firebrick;
            this.btnQuitarProdLista.FlatAppearance.BorderSize = 0;
            this.btnQuitarProdLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarProdLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProdLista.ForeColor = System.Drawing.Color.White;
            this.btnQuitarProdLista.Location = new System.Drawing.Point(593, 142);
            this.btnQuitarProdLista.Name = "btnQuitarProdLista";
            this.btnQuitarProdLista.Size = new System.Drawing.Size(40, 33);
            this.btnQuitarProdLista.TabIndex = 160;
            this.btnQuitarProdLista.Text = "-";
            this.btnQuitarProdLista.UseVisualStyleBackColor = false;
            this.btnQuitarProdLista.Click += new System.EventHandler(this.btnQuitarProdLista_Click);
            // 
            // btnAgregarProdALista
            // 
            this.btnAgregarProdALista.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAgregarProdALista.FlatAppearance.BorderSize = 0;
            this.btnAgregarProdALista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarProdALista.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProdALista.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProdALista.Location = new System.Drawing.Point(539, 142);
            this.btnAgregarProdALista.Name = "btnAgregarProdALista";
            this.btnAgregarProdALista.Size = new System.Drawing.Size(42, 33);
            this.btnAgregarProdALista.TabIndex = 157;
            this.btnAgregarProdALista.Text = "+";
            this.btnAgregarProdALista.UseVisualStyleBackColor = false;
            this.btnAgregarProdALista.Click += new System.EventHandler(this.btnAgregarProdALista_Click);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.White;
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.ColumnHeadersVisible = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle14;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.DimGray;
            this.metroGrid1.Location = new System.Drawing.Point(49, 262);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            this.metroGrid1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(557, 246);
            this.metroGrid1.TabIndex = 165;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(383, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 162;
            this.label4.Text = "Precio Venta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(517, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 164;
            this.label2.Text = "Cantidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(131, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 161;
            this.label1.Text = "Producto";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(911, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 41);
            this.button1.TabIndex = 120;
            this.button1.Text = "EXCEL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTot.ForeColor = System.Drawing.Color.DimGray;
            this.lblTot.Location = new System.Drawing.Point(401, 524);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(76, 20);
            this.lblTot.TabIndex = 166;
            this.lblTot.Text = "TOTAL  $";
            // 
            // lblTotValue
            // 
            this.lblTotValue.AutoSize = true;
            this.lblTotValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotValue.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotValue.Location = new System.Drawing.Point(485, 524);
            this.lblTotValue.Name = "lblTotValue";
            this.lblTotValue.Size = new System.Drawing.Size(0, 20);
            this.lblTotValue.TabIndex = 167;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod.ForeColor = System.Drawing.Color.DimGray;
            this.lblCod.Location = new System.Drawing.Point(53, 236);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(38, 20);
            this.lblCod.TabIndex = 168;
            this.lblCod.Text = "Cod";
            // 
            // frmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1034, 661);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.lblTotValue);
            this.Controls.Add(this.lblTot);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelecProducto);
            this.Controls.Add(this.TxtProducto);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.btnQuitarProdLista);
            this.Controls.Add(this.btnAgregarProdALista);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPresupuesto";
            this.Text = "frmPresupuesto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPresupuesto_FormClosing);
            this.Load += new System.EventHandler(this.frmPresupuesto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label lblTituloPresupuesto;
        public System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSelecProducto;
        public System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnQuitarProdLista;
        private System.Windows.Forms.Button btnAgregarProdALista;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblTotValue;
        private System.Windows.Forms.Label lblCod;
    }
}