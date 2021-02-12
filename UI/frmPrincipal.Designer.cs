namespace UI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAjustes = new System.Windows.Forms.Button();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cbIdioma = new MetroFramework.Controls.MetroComboBox();
            this.panelAjustes = new System.Windows.Forms.Panel();
            this.BtnTipoDocIdentidad = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.btnCategoriaProd = new System.Windows.Forms.Button();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.PanelUserData = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelAjustes.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.panelMenu.Controls.Add(this.btnAjustes);
            this.panelMenu.Controls.Add(this.lblIdioma);
            this.panelMenu.Controls.Add(this.cbIdioma);
            this.panelMenu.Controls.Add(this.panelAjustes);
            this.panelMenu.Controls.Add(this.btnPresupuesto);
            this.panelMenu.Controls.Add(this.btnVentas);
            this.panelMenu.Controls.Add(this.btnCompras);
            this.panelMenu.Controls.Add(this.btnProveedores);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Controls.Add(this.btnProductos);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Name = "panelMenu";
            // 
            // btnAjustes
            // 
            resources.ApplyResources(this.btnAjustes, "btnAjustes");
            this.btnAjustes.FlatAppearance.BorderSize = 0;
            this.btnAjustes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAjustes.Name = "btnAjustes";
            this.btnAjustes.UseVisualStyleBackColor = true;
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click_1);
            // 
            // lblIdioma
            // 
            resources.ApplyResources(this.lblIdioma, "lblIdioma");
            this.lblIdioma.ForeColor = System.Drawing.Color.White;
            this.lblIdioma.Name = "lblIdioma";
            // 
            // cbIdioma
            // 
            this.cbIdioma.FormattingEnabled = true;
            resources.ApplyResources(this.cbIdioma, "cbIdioma");
            this.cbIdioma.Items.AddRange(new object[] {
            resources.GetString("cbIdioma.Items"),
            resources.GetString("cbIdioma.Items1")});
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.UseSelectable = true;
            this.cbIdioma.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // panelAjustes
            // 
            this.panelAjustes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(109)))), ((int)(((byte)(113)))));
            this.panelAjustes.Controls.Add(this.BtnTipoDocIdentidad);
            this.panelAjustes.Controls.Add(this.button5);
            this.panelAjustes.Controls.Add(this.btnPrecio);
            this.panelAjustes.Controls.Add(this.btnCategoriaProd);
            resources.ApplyResources(this.panelAjustes, "panelAjustes");
            this.panelAjustes.Name = "panelAjustes";
            // 
            // BtnTipoDocIdentidad
            // 
            resources.ApplyResources(this.BtnTipoDocIdentidad, "BtnTipoDocIdentidad");
            this.BtnTipoDocIdentidad.FlatAppearance.BorderSize = 0;
            this.BtnTipoDocIdentidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.BtnTipoDocIdentidad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnTipoDocIdentidad.Name = "BtnTipoDocIdentidad";
            this.BtnTipoDocIdentidad.UseVisualStyleBackColor = true;
            this.BtnTipoDocIdentidad.Click += new System.EventHandler(this.BtnTipoDocIdentidad_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnPrecio
            // 
            resources.ApplyResources(this.btnPrecio, "btnPrecio");
            this.btnPrecio.FlatAppearance.BorderSize = 0;
            this.btnPrecio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnPrecio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.UseVisualStyleBackColor = true;
            // 
            // btnCategoriaProd
            // 
            resources.ApplyResources(this.btnCategoriaProd, "btnCategoriaProd");
            this.btnCategoriaProd.FlatAppearance.BorderSize = 0;
            this.btnCategoriaProd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btnCategoriaProd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCategoriaProd.Name = "btnCategoriaProd";
            this.btnCategoriaProd.UseVisualStyleBackColor = true;
            // 
            // btnPresupuesto
            // 
            resources.ApplyResources(this.btnPresupuesto, "btnPresupuesto");
            this.btnPresupuesto.FlatAppearance.BorderSize = 0;
            this.btnPresupuesto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.UseVisualStyleBackColor = true;
            this.btnPresupuesto.Click += new System.EventHandler(this.btnPresupuesto_Click);
            // 
            // btnVentas
            // 
            resources.ApplyResources(this.btnVentas, "btnVentas");
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            resources.ApplyResources(this.btnCompras, "btnCompras");
            this.btnCompras.FlatAppearance.BorderSize = 0;
            this.btnCompras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.UseVisualStyleBackColor = true;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // btnProveedores
            // 
            resources.ApplyResources(this.btnProveedores, "btnProveedores");
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.UseVisualStyleBackColor = true;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // btnClientes
            // 
            resources.ApplyResources(this.btnClientes, "btnClientes");
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProductos
            // 
            resources.ApplyResources(this.btnProductos, "btnProductos");
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(48)))), ((int)(((byte)(51)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.Name = "panelLogo";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panelFormularios, "panelFormularios");
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormularios_Paint);
            // 
            // PanelUserData
            // 
            this.PanelUserData.BackColor = System.Drawing.Color.DarkSlateBlue;
            resources.ApplyResources(this.PanelUserData, "PanelUserData");
            this.PanelUserData.Name = "PanelUserData";
            // 
            // frmPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelUserData);
            this.Controls.Add(this.panelFormularios);
            this.Controls.Add(this.panelMenu);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelAjustes.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelAjustes;
        private System.Windows.Forms.Button BtnTipoDocIdentidad;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnPrecio;
        private System.Windows.Forms.Button btnCategoriaProd;
        private System.Windows.Forms.Button btnPresupuesto;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelUserData;
        private System.Windows.Forms.Label lblIdioma;
        private MetroFramework.Controls.MetroComboBox cbIdioma;
        private System.Windows.Forms.Button btnAjustes;
    }
}

