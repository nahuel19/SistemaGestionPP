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

namespace UI.TipoDoc_Indentidad
{
    public partial class frmTipoDocIdentidad : Form
    {
        public frmTipoDocIdentidad()
        {
            InitializeComponent();
        }

        #region helpers
        private void RefrescarTabla()
        {
            var bll = new TipoDoc_identidadBLL();
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

        private void frmTipoDocIdentidad_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            frmTipoDocIdentidadFormulario frm = new frmTipoDocIdentidadFormulario();
            frm.ShowDialog();

            RefrescarTabla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                frmTipoDocIdentidadFormulario frm = new frmTipoDocIdentidadFormulario(id);
                frm.ShowDialog();

                RefrescarTabla();

            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {


                TipoDoc_identidadBLL cat = new TipoDoc_identidadBLL();

                cat.Delete(Convert.ToInt32(id));

                RefrescarTabla();

            }
        }
    }
}
