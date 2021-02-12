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
    public partial class frmProductoDetalle : MetroFramework.Forms.MetroForm
    {
        private Entities.Producto entity = null;
        private ProductoBLL bll = new ProductoBLL();
        private int id;
        public frmProductoDetalle(int _id)
        {
            id = _id;
            InitializeComponent();
            CargaDatosEnForm(_id);
        }

        private void CargaDatosEnForm(int id)
        {
            entity = bll.GetById(Convert.ToInt32(id));
            lblCodValue.Text = entity.codigo;
            lblNombreValue.Text = entity.nombre;
            lblDescripcionValue.Text = entity.descripcion;
            lblCategoriaValue.Text = entity.categoria;
            lblPesoValue.Text = entity.peso.ToString();
            lblAltoValue.Text = entity.alto.ToString();
            lblAnchoValue.Text = entity.ancho.ToString();
            lblProfValue.Text = entity.profundidad.ToString();
            lblPrecioValue.Text = entity.precio.ToString();
            lblCantValue.Text = entity.cantidad.ToString();
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            Producto.frmAddStock frm = new Producto.frmAddStock(entity.id);
            frm.ShowDialog();
            CargaDatosEnForm(id);
        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            Producto.frmPrecio frm = new Producto.frmPrecio(entity.id);
            frm.ShowDialog();
            CargaDatosEnForm(id);
        }
    }
}
