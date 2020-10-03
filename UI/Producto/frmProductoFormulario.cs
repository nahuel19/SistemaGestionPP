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

namespace UI.Producto
{
    public partial class frmProductoFormulario : Form
    {
        public int? id;
        ModeloEntidades.Producto entidad = null;
        ProductoBLL bll = new ProductoBLL();
        CategoriaBLL catBll = new CategoriaBLL();

        public frmProductoFormulario(int? id = null)
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
            entidad = bll.GetById(id);
            TxtNombre.Text = entidad.nombre;
            TxtDescrpcion.Text = entidad.descripcion;
            var cat = catBll.GetById(entidad.fk_id_categoria);
            TxtCatNomb.Text = cat.categoria;
        }

        private void frmProductoFormulario_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.LblHelp.Visible = true;
            AddOwnedForm(frmCategoria);
            frmCategoria.ShowDialog();

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                entidad = new ModeloEntidades.Producto();
            }
            entidad.nombre = TxtNombre.Text;
            entidad.descripcion = TxtDescrpcion.Text;
            entidad.fk_id_categoria = Convert.ToInt32(TxtCatId.Text);

            if (id == null)
            {
                bll.Insert(entidad);
            }
            else
            {
                bll.Update(entidad);
            }


            this.Close();
        }
    }
}
