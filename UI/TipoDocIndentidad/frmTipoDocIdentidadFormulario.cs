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

namespace UI.TipoDoc_Indentidad
{
    public partial class frmTipoDocIdentidadFormulario : MetroFramework.Forms.MetroForm
    {

        public int? id;
        Entities.TipoDoc_identidad entidad = null;
        TipoDoc_identidadBLL bll = new TipoDoc_identidadBLL();

        public frmTipoDocIdentidadFormulario(int? id = null)
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

            entidad = bll.GetById(Convert.ToInt32(id));
            //TxtTipoDoc.Text = entidad.doc_identidad;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (id == null)
            {
                entidad = new Entities.TipoDoc_identidad();
            }
            //entidad.doc_identidad = TxtTipoDoc.Text;

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

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
