namespace UI.Categoria
{
    partial class FrmCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategoria));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureLupa = new System.Windows.Forms.PictureBox();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.pictureBoxBuscar = new System.Windows.Forms.PictureBox();
            this.BtnLimapiar = new System.Windows.Forms.Button();
            this.lblTxtNombre = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTituloCat = new System.Windows.Forms.Label();
            this.lblDGnombre = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.pictureBoxNombre = new System.Windows.Forms.PictureBox();
            this.lblMantenimiento = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.btnAjustaPrecioCat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLupa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNombre)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLupa
            // 
            this.pictureLupa.Image = ((System.Drawing.Image)(resources.GetObject("pictureLupa.Image")));
            this.pictureLupa.Location = new System.Drawing.Point(25, 127);
            this.pictureLupa.Name = "pictureLupa";
            this.pictureLupa.Size = new System.Drawing.Size(25, 25);
            this.pictureLupa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLupa.TabIndex = 78;
            this.pictureLupa.TabStop = false;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtBuscar.BackColor = System.Drawing.Color.White;
            this.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.TxtBuscar.Location = new System.Drawing.Point(55, 128);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(231, 19);
            this.TxtBuscar.TabIndex = 76;
            this.TxtBuscar.TextChanged += new System.EventHandler(this.TxtBuscar_TextChanged);
            // 
            // pictureBoxBuscar
            // 
            this.pictureBoxBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxBuscar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBuscar.Image")));
            this.pictureBoxBuscar.Location = new System.Drawing.Point(13, 118);
            this.pictureBoxBuscar.Name = "pictureBoxBuscar";
            this.pictureBoxBuscar.Size = new System.Drawing.Size(292, 39);
            this.pictureBoxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBuscar.TabIndex = 77;
            this.pictureBoxBuscar.TabStop = false;
            // 
            // BtnLimapiar
            // 
            this.BtnLimapiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnLimapiar.BackColor = System.Drawing.Color.Peru;
            this.BtnLimapiar.FlatAppearance.BorderSize = 0;
            this.BtnLimapiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimapiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimapiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimapiar.Location = new System.Drawing.Point(631, 345);
            this.BtnLimapiar.Name = "BtnLimapiar";
            this.BtnLimapiar.Size = new System.Drawing.Size(118, 41);
            this.BtnLimapiar.TabIndex = 75;
            this.BtnLimapiar.Text = "LIMPIAR";
            this.BtnLimapiar.UseVisualStyleBackColor = false;
            this.BtnLimapiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // lblTxtNombre
            // 
            this.lblTxtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTxtNombre.AutoSize = true;
            this.lblTxtNombre.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTxtNombre.Location = new System.Drawing.Point(498, 250);
            this.lblTxtNombre.Name = "lblTxtNombre";
            this.lblTxtNombre.Size = new System.Drawing.Size(78, 20);
            this.lblTxtNombre.TabIndex = 74;
            this.lblTxtNombre.Text = "Nombre";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.DarkMagenta;
            this.panelTitulo.Controls.Add(this.lblTituloCat);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(20, 60);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(792, 40);
            this.panelTitulo.TabIndex = 73;
            // 
            // lblTituloCat
            // 
            this.lblTituloCat.AutoSize = true;
            this.lblTituloCat.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCat.ForeColor = System.Drawing.Color.White;
            this.lblTituloCat.Location = new System.Drawing.Point(11, 9);
            this.lblTituloCat.Name = "lblTituloCat";
            this.lblTituloCat.Size = new System.Drawing.Size(114, 20);
            this.lblTituloCat.TabIndex = 0;
            this.lblTituloCat.Text = "CATEGORÍA";
            // 
            // lblDGnombre
            // 
            this.lblDGnombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDGnombre.AutoSize = true;
            this.lblDGnombre.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDGnombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDGnombre.Location = new System.Drawing.Point(41, 176);
            this.lblDGnombre.Name = "lblDGnombre";
            this.lblDGnombre.Size = new System.Drawing.Size(78, 20);
            this.lblDGnombre.TabIndex = 69;
            this.lblDGnombre.Text = "Nombre";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnEliminar.BackColor = System.Drawing.Color.Tomato;
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.White;
            this.BtnEliminar.Location = new System.Drawing.Point(224, 498);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(118, 41);
            this.BtnEliminar.TabIndex = 71;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnEditar.BackColor = System.Drawing.Color.DarkCyan;
            this.BtnEditar.FlatAppearance.BorderSize = 0;
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.ForeColor = System.Drawing.Color.White;
            this.BtnEditar.Location = new System.Drawing.Point(224, 450);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(118, 41);
            this.BtnEditar.TabIndex = 70;
            this.BtnEditar.Text = "EDITAR";
            this.BtnEditar.UseVisualStyleBackColor = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.DimGray;
            this.metroGrid1.Location = new System.Drawing.Point(53, 201);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.ReadOnly = true;
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            this.metroGrid1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(302, 226);
            this.metroGrid1.TabIndex = 72;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNombre.BackColor = System.Drawing.Color.White;
            this.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.ForeColor = System.Drawing.Color.DimGray;
            this.TxtNombre.Location = new System.Drawing.Point(499, 282);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(243, 19);
            this.TxtNombre.TabIndex = 65;
            // 
            // pictureBoxNombre
            // 
            this.pictureBoxNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxNombre.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNombre.Image")));
            this.pictureBoxNombre.Location = new System.Drawing.Point(484, 273);
            this.pictureBoxNombre.Name = "pictureBoxNombre";
            this.pictureBoxNombre.Size = new System.Drawing.Size(275, 39);
            this.pictureBoxNombre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNombre.TabIndex = 68;
            this.pictureBoxNombre.TabStop = false;
            // 
            // lblMantenimiento
            // 
            this.lblMantenimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMantenimiento.AutoSize = true;
            this.lblMantenimiento.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMantenimiento.ForeColor = System.Drawing.Color.DimGray;
            this.lblMantenimiento.Location = new System.Drawing.Point(528, 179);
            this.lblMantenimiento.Name = "lblMantenimiento";
            this.lblMantenimiento.Size = new System.Drawing.Size(182, 26);
            this.lblMantenimiento.TabIndex = 67;
            this.lblMantenimiento.Text = "Mantenimiento";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGuardar.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.White;
            this.BtnGuardar.Location = new System.Drawing.Point(492, 345);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(118, 41);
            this.BtnGuardar.TabIndex = 66;
            this.BtnGuardar.Text = "GUARDAR";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnAjustaPrecioCat
            // 
            this.btnAjustaPrecioCat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAjustaPrecioCat.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAjustaPrecioCat.FlatAppearance.BorderSize = 0;
            this.btnAjustaPrecioCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjustaPrecioCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjustaPrecioCat.ForeColor = System.Drawing.Color.White;
            this.btnAjustaPrecioCat.Location = new System.Drawing.Point(76, 466);
            this.btnAjustaPrecioCat.Name = "btnAjustaPrecioCat";
            this.btnAjustaPrecioCat.Size = new System.Drawing.Size(118, 56);
            this.btnAjustaPrecioCat.TabIndex = 79;
            this.btnAjustaPrecioCat.Text = "AJUSTAR PRECIO";
            this.btnAjustaPrecioCat.UseVisualStyleBackColor = false;
            this.btnAjustaPrecioCat.Click += new System.EventHandler(this.btnAjustaPrecioCat_Click);
            // 
            // FrmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 560);
            this.Controls.Add(this.btnAjustaPrecioCat);
            this.Controls.Add(this.pictureLupa);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.pictureBoxBuscar);
            this.Controls.Add(this.BtnLimapiar);
            this.Controls.Add(this.lblTxtNombre);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.lblDGnombre);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnEditar);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.pictureBoxNombre);
            this.Controls.Add(this.lblMantenimiento);
            this.Controls.Add(this.BtnGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCategoria";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Load += new System.EventHandler(this.FrmCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLupa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBuscar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNombre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLupa;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.PictureBox pictureBoxBuscar;
        private System.Windows.Forms.Button BtnLimapiar;
        private System.Windows.Forms.Label lblTxtNombre;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTituloCat;
        private System.Windows.Forms.Label lblDGnombre;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnEditar;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.PictureBox pictureBoxNombre;
        private System.Windows.Forms.Label lblMantenimiento;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button btnAjustaPrecioCat;
    }
}