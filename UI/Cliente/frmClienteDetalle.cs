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

namespace UI.Cliente
{
    public partial class frmClienteDetalle : MetroFramework.Forms.MetroForm
    {
        private Entities.Cliente entity = null;
        private ClienteBLL bll = new ClienteBLL();
        public frmClienteDetalle(int id)
        {
            InitializeComponent();
            ChangeLanguage();
            CargaDatosEnForm(id);
        }

        private void CargaDatosEnForm(int id)
        {
            entity = bll.GetById(Convert.ToInt32(id));
            lblNombreValue.Text = entity.nombre;
            lblApellidoValue.Text = entity.apellido;
            lblTipoDocValue.Text = entity.doc_identidad;
            lblDocValue.Text = entity.num_documento;
            lblFechaValue.Text = entity.fecha_nacimiento.Date.ToString();
            lblDireccionValue.Text = entity.direccion;
            lblTelValue.Text = entity.telefono;
            lblMailValue.Text = entity.mail;
            lblEdadValue.Text = entity.edad.ToString();
        }


        private void ChangeLanguage()
        {
            this.Text = Helps.Language.info["tituloDetalle"];
            Helps.Language.controles(this);
        }
    }
}
