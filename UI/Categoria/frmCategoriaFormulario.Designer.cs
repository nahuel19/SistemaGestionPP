namespace UI.Categoria
{
    partial class frmCategoriaFormulario
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
            this.labelCatNueva = new System.Windows.Forms.Label();
            this.TxtCatNueva = new System.Windows.Forms.TextBox();
            this.BtnCatGuardarNueva = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCatNueva
            // 
            this.labelCatNueva.AutoSize = true;
            this.labelCatNueva.Location = new System.Drawing.Point(47, 76);
            this.labelCatNueva.Name = "labelCatNueva";
            this.labelCatNueva.Size = new System.Drawing.Size(52, 13);
            this.labelCatNueva.TabIndex = 0;
            this.labelCatNueva.Text = "Categoria";
            // 
            // TxtCatNueva
            // 
            this.TxtCatNueva.Location = new System.Drawing.Point(122, 73);
            this.TxtCatNueva.Name = "TxtCatNueva";
            this.TxtCatNueva.Size = new System.Drawing.Size(143, 20);
            this.TxtCatNueva.TabIndex = 1;
            // 
            // BtnCatGuardarNueva
            // 
            this.BtnCatGuardarNueva.Location = new System.Drawing.Point(122, 129);
            this.BtnCatGuardarNueva.Name = "BtnCatGuardarNueva";
            this.BtnCatGuardarNueva.Size = new System.Drawing.Size(75, 23);
            this.BtnCatGuardarNueva.TabIndex = 2;
            this.BtnCatGuardarNueva.Text = "Guardar";
            this.BtnCatGuardarNueva.UseVisualStyleBackColor = true;
            this.BtnCatGuardarNueva.Click += new System.EventHandler(this.BtnCatGuardarNueva_Click);
            // 
            // frmCategoriaNueva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 229);
            this.Controls.Add(this.BtnCatGuardarNueva);
            this.Controls.Add(this.TxtCatNueva);
            this.Controls.Add(this.labelCatNueva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategoriaNueva";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Categoria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCatNueva;
        private System.Windows.Forms.TextBox TxtCatNueva;
        private System.Windows.Forms.Button BtnCatGuardarNueva;
    }
}