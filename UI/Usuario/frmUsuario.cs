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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Helps;

namespace UI.Usuario
{
    /// <summary>
    /// form gestión de usuarios
    /// </summary>
    public partial class frmUsuario : Form
    {
        //UsuarioBLL bll = new UsuarioBLL();
        
        public frmUsuario()
        {
            InitializeComponent();
            ChangeLanguage();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Usuario.frmUsuarioFormulario frmNuevo = new Usuario.frmUsuarioFormulario();
            frmNuevo.ShowDialog();
            RefrescarTabla();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                string id = GetId();

                Usuario.frmUsuarioFormulario frmEditar = new Usuario.frmUsuarioFormulario(id);
                frmEditar.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEditar"));
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                string idEntity = GetId();

                Entities.UFP.Usuario entity = BLL.UFP.Usuario.GetAdapted(idEntity);

                try
                {
                    DialogResult confirmation = new Notifications.FrmQuestion(Helps.Language.SearchValue("preguntaEliminar")).ShowDialog();

                    if (confirmation == DialogResult.OK)
                    {
                        //bll.Delete(Convert.ToInt32(idEntity));
                        BLL.UFP.Usuario.Delete(entity);

                        InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Delete, 1, this.GetType().FullName, MethodInfo.GetCurrentMethod().Name, "Usuario: " + entity.Nombre, "", ""));

                        RefrescarTabla();
                        Notifications.FrmSuccess.SuccessForm(Helps.Language.SearchValue("eliminadoOK"));

                    }
                }
                catch (Exception ex)
                {
                    InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.DeleteError, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Usuario: " + entity.Nombre, ex.StackTrace, ex.Message));
                    RefrescarTabla();
                    Notifications.FrmError.ErrorForm(Helps.Language.SearchValue("eliminadoError") + "\n" + ex.Message);
                }
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEliminar"));
            }
        }


        #region helpers
        private void RefrescarTabla()
        {
            try
            {
                metroGrid1.DataSource = BLL.UFP.Usuario.GetAllAdapted();

                CaracteristicasGrid();
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error carga de datos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorBuscarDatos") + "\n" + ex.Message);
            }

            metroGrid1.ClearSelection();
            TxtBuscar.Focus();
        }

        private void CaracteristicasGrid()
        {
            metroGrid1.Columns["IdUsuario"].Visible = false;
            metroGrid1.Columns["Pass"].Visible = false;
        }

        private string GetId()
        {
            try
            {
                return metroGrid1.CurrentRow.Cells["IdUsuario"].Value.ToString();
            }
            catch
            {
                return null;
            }
        }

        #endregion

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            //metroGrid1.DataSource = bll.FindBy(TxtBuscar.Text);
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            RefrescarTabla();
            HelpUser();
        }
        private void HelpUser()
        {
            helpProvider1.HelpNamespace = Application.StartupPath + "/ManualUsuario.chm";
            helpProvider1.SetHelpString(this, "Usuarios");
            helpProvider1.SetHelpKeyword(this, "Usuarios");
            helpProvider1.SetHelpNavigator(this, HelpNavigator.KeywordIndex);
        }

        private void ChangeLanguage()
        {
            this.lblTituloUsuarios.Text = Helps.Language.info["lblTituloUsuarios"];
            Helps.Language.controles(this);
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            frmFamilias frmFamilias = new frmFamilias();
            frmFamilias.ShowDialog();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            if (metroGrid1.SelectedRows.Count > 0)
            {
                string id = GetId();

                Usuario.frmPermisos frmP = new Usuario.frmPermisos(id);
                frmP.ShowDialog();
                RefrescarTabla();
            }
            else
            {
                Notifications.FrmInformation.InformationForm(Helps.Language.SearchValue("infoSelecEditar"));
            }
        }


        private void CheckPermisos()
        {
            try
            {
                btnPermisos.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.Permisos);
                btnFamilias.Enabled = BLL.UFP.Usuario.ValidarPermiso(LoginCache.permisos, Entities.UFP.TipoPermiso.Perfiles);
            }
            catch (Exception ex)
            {
                InvokeCommand.InsertLog().Execute(CreateLog.Clog(ETipoLog.Error, 1, ex.TargetSite.DeclaringType.FullName, ex.TargetSite.Name, "Error validación de permisos", ex.StackTrace, ex.Message));
                Notifications.FrmError.ErrorForm(Language.SearchValue("errorPermisos") + "\n" + ex.Message);
            }       
        }
    }
}
