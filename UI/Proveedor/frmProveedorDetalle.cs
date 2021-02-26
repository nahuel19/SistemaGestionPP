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

namespace UI.Proveedor
{
    /// <summary>
    /// form para mostar detalle de un proveedor
    /// </summary>
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
            try
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

        private void frmProveedorDetalle_Load(object sender, EventArgs e)
        {
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Detalle proveedor");
            helpProvider1.SetHelpKeyword(this, "Detalle proveedor");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
