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

namespace UI.Proveedor
{
    public partial class frmProveedorDetalle : MetroFramework.Forms.MetroForm
    {
        private Entities.Proveedor entity = null;
        private ProveedorBLL bll = new ProveedorBLL();
        public frmProveedorDetalle(int id)
        {
            InitializeComponent();
            CargaDatosEnForm(id);
            ChangeLanguage();
        }

        private void CargaDatosEnForm(int id)
        {
            entity = bll.GetById(Convert.ToInt32(id));
            lblNombreValue.Text = entity.nombre;
            lblTipoDocValue.Text = entity.doc_identidad;
            lblDocValue.Text = entity.num_documento;
            lblDireccionValue.Text = entity.direccion;
            lblTelValue.Text = entity.telefono;
            lblMailValue.Text = entity.mail;
            lblUrlValue.Text = entity.url;
        }

        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["tituloDetalle"];
            Helps.Language.controles(this);
        }
    }
}
