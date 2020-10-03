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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        #region helpers
        private void RefrescarTabla()
        {
            var bll = new ProductoBLL();
            dataGridView1.DataSource = bll.List().ToList();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void frmProducto_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Producto.frmProductoFormulario frm = new Producto.frmProductoFormulario();
            frm.ShowDialog();

            RefrescarTabla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                Producto.frmProductoFormulario frm = new Producto.frmProductoFormulario(id);
                frm.ShowDialog();

                RefrescarTabla();

            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {


                ProductoBLL cat = new ProductoBLL();

                cat.Delete(id);

                RefrescarTabla();

            }
        }
    }
}
