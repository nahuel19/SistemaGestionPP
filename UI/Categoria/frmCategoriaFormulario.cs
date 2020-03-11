using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ModeloEntidades;

namespace UI.Categoria
{
    public partial class frmCategoriaFormulario : Form
    {
        public int? id;
        ModeloEntidades.Categoria categoria = null;
        CategoriaBLL cat = new CategoriaBLL();

        public frmCategoriaFormulario(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if (id != null)
            {
                CargaDatos();
            }
        }

        private void CargaDatos()
        {

            categoria = cat.GetById(id);
            TxtCatNueva.Text = categoria.categoria;
        }


        private void BtnCatGuardarNueva_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                categoria = new ModeloEntidades.Categoria();
            }
            categoria.categoria = TxtCatNueva.Text;

            if (id == null)
            {
                cat.Insert(categoria);
            }else
            {
                cat.Update(categoria);
            }
                

            this.Close();

        }
    }
}
