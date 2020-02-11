namespace UI
{
    partial class Categoria
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
            this.DGVcategoria = new System.Windows.Forms.DataGridView();
            this.nmbCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVcategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVcategoria
            // 
            this.DGVcategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVcategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nmbCategoria});
            this.DGVcategoria.Location = new System.Drawing.Point(251, 225);
            this.DGVcategoria.Name = "DGVcategoria";
            this.DGVcategoria.Size = new System.Drawing.Size(143, 183);
            this.DGVcategoria.TabIndex = 0;
            this.DGVcategoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVcategoria_CellContentClick);
            // 
            // nmbCategoria
            // 
            this.nmbCategoria.HeaderText = "Categoria";
            this.nmbCategoria.Name = "nmbCategoria";
            // 
            // Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVcategoria);
            this.Name = "Categoria";
            this.Text = "Categoria";
            ((System.ComponentModel.ISupportInitialize)(this.DGVcategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmbCategoria;
    }
}