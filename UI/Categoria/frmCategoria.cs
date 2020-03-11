using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }


        #region helpers
        private void RefrescarTabla()
        {
            var cat = new CategoriaBLL();
            DataGridViewCategoria.DataSource = cat.List().ToList();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(DataGridViewCategoria.Rows[DataGridViewCategoria.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void BtnCatNueva_Click(object sender, EventArgs e)
        {
            Categoria.frmCategoriaFormulario frmCatNueva = new Categoria.frmCategoriaFormulario();
            frmCatNueva.ShowDialog();

            RefrescarTabla();
        }

        private void BtnEditarCat_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Categoria.frmCategoriaFormulario frmCatNueva = new Categoria.frmCategoriaFormulario(id);
                frmCatNueva.ShowDialog();

                RefrescarTabla();
                
            }   

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                

                CategoriaBLL cat = new CategoriaBLL();

                cat.Delete(id);

                RefrescarTabla();

            }
        }
    }
}
