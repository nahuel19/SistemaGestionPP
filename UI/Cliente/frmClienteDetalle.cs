using BLL;
using BLL.LogBitacora;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helps;

namespace UI.Cliente
{
    /// <summary>
    /// form cliente detalle
    /// </summary>
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
            try
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
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
        }


        private void ChangeLanguage()
        {
            this.Text = Helps.Language.SearchValue("tituloDetalle");
            Helps.Language.controles(this);
        }

        private void frmClienteDetalle_Load(object sender, EventArgs e)
        {
            HelpUser();
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Detalle cliente");
            helpProvider1.SetHelpKeyword(this, "Detalle cliente");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
