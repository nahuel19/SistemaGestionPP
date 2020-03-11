namespace UI
{
    partial class frmCategoria
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DataGridViewCategoria = new System.Windows.Forms.DataGridView();
            this.BtnCatNueva = new System.Windows.Forms.Button();
            this.BtnEditarCat = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CATEGORIAS";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BtnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.BtnEditarCat);
            this.splitContainer1.Panel1.Controls.Add(this.BtnCatNueva);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridViewCategoria);
            this.splitContainer1.Size = new System.Drawing.Size(819, 425);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 5;
            // 
            // DataGridViewCategoria
            // 
            this.DataGridViewCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewCategoria.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewCategoria.MultiSelect = false;
            this.DataGridViewCategoria.Name = "DataGridViewCategoria";
            this.DataGridViewCategoria.ReadOnly = true;
            this.DataGridViewCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewCategoria.Size = new System.Drawing.Size(819, 350);
            this.DataGridViewCategoria.TabIndex = 0;
            // 
            // BtnCatNueva
            // 
            this.BtnCatNueva.Location = new System.Drawing.Point(30, 26);
            this.BtnCatNueva.Name = "BtnCatNueva";
            this.BtnCatNueva.Size = new System.Drawing.Size(75, 23);
            this.BtnCatNueva.TabIndex = 0;
            this.BtnCatNueva.Text = "Nueva";
            this.BtnCatNueva.UseVisualStyleBackColor = true;
            this.BtnCatNueva.Click += new System.EventHandler(this.BtnCatNueva_Click);
            // 
            // BtnEditarCat
            // 
            this.BtnEditarCat.Location = new System.Drawing.Point(145, 26);
            this.BtnEditarCat.Name = "BtnEditarCat";
            this.BtnEditarCat.Size = new System.Drawing.Size(75, 23);
            this.BtnEditarCat.TabIndex = 1;
            this.BtnEditarCat.Text = "Editar";
            this.BtnEditarCat.UseVisualStyleBackColor = true;
            this.BtnEditarCat.Click += new System.EventHandler(this.BtnEditarCat_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(680, 26);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(75, 23);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // frmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 425);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "frmCategoria";
            this.Text = "Categoria";
            this.Load += new System.EventHandler(this.frmCategoria_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DataGridViewCategoria;
        private System.Windows.Forms.Button BtnCatNueva;
        private System.Windows.Forms.Button BtnEditarCat;
        private System.Windows.Forms.Button BtnEliminar;
    }
}