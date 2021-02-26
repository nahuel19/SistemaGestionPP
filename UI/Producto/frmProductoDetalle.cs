using BLL;
using BLL.LogBitacora;
using Services;
using Services.Cache;
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

namespace UI.Producto
{
    /// <summary>
    /// form productos detalle
    /// </summary>
    public partial class frmProductoDetalle : MetroFramework.Forms.MetroForm
    {
        private Entities.Producto entity = null;
        private ProductoBLL bll = new ProductoBLL();
        private int id;
        public frmProductoDetalle(int _id)
        {
            id = _id;
            InitializeComponent();
            ChangeLanguage();
            CargaDatosEnForm(_id);
        }

        private void CargaDatosEnForm(int id)
        {
            try
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
            catch (Exception ex)
            {

                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }
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

        private void ChangeLanguage()
        {
            Helps.Language.controles(this);
            this.Text = Helps.Language.SearchValue("producto");
            this.btnNuevoPrecio.Text = Helps.Language.SearchValue("btnNuevoPrecio");
        }

        private void CheckPermisos()
        {
            try
            {
                btnNuevoPrecio.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ProductoAjustarPrecio);
                BtnStock.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.ProductoAjustarStock);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error validación de permisos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorPermisos") + "\n" + ex.Message);
            }       
        }

        private void frmProductoDetalle_Load(object sender, EventArgs e)
        {
            CheckPermisos();
            HelpUser();
        }

        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Detalle producto");
            helpProvider1.SetHelpKeyword(this, "Detalle producto");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }
    }
}
